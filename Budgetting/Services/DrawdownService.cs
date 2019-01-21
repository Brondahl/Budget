using System;
using System.Collections.Generic;
using System.Linq;
using Budgetting.DbModels.BankAccounts;
using Budgetting.Services.Downloaders;
using TransactionList = System.Collections.Generic.List<Budgetting.DbModels.BankAccounts.AccountTransaction>;

namespace Budgetting.Services
{
  public interface IDrawdownService
  {
    void BeginDrawdown(IAccountCredentials credentials);
  }

  public class DrawdownService : IDrawdownService
  {
    private readonly IDownloaderRepository downloaders;
    private readonly IAccountTransactionsService txnService;
    private readonly IDuplicateTransactionHandler duplicateHandler;

    public DrawdownService(
      IDownloaderRepository downloaders,
      IAccountTransactionsService txnService,
      IDuplicateTransactionHandler duplicateHandler)
    {
      this.downloaders = downloaders;
      this.txnService = txnService;
      this.duplicateHandler = duplicateHandler;
    }

    public void BeginDrawdown(IAccountCredentials credentials)
    {
      var txDownloaders = downloaders.GetAll();
      var earliestLoadDate = DateTime.MaxValue;
      var allDownloadedTxns = new TransactionList();

      foreach (var downloader in txDownloaders)
      {
        var loadDate = downloader.DetermineLoadDate(txnService);
        earliestLoadDate = loadDate < earliestLoadDate ? loadDate : earliestLoadDate;
        allDownloadedTxns.AddRange(downloader.GetAllNewTransactions(credentials, loadDate));
      }
      
      var existingRecentTxns = txnService.GetAllTransactionsSince(earliestLoadDate.AddMonths(-1));
      duplicateHandler.SynchroniseDistinguishedDuplicates(allDownloadedTxns, existingRecentTxns);
      var newTxnsImported = IdentifyNewTransactions(allDownloadedTxns, existingRecentTxns).ToList();
      var surpiseTxns = IdentifySurpriseTransactions(newTxnsImported, existingRecentTxns);

      txnService.SaveNewTransactions(newTxnsImported.ToList());
      txnService.RecordTransactionsForUserAttention(surpiseTxns.ToList());
    }

    private IEnumerable<AccountTransaction> IdentifyNewTransactions(TransactionList allDownloadedTxns, TransactionList existingRecentTxns)
    {
      //Hash of: AccountId, ImportHash, Discriminator.
      var existingGloballyUniqueHashes = new HashSet<string>(existingRecentTxns.Select(txn => txn.GloballyUniqueHash));
      foreach (var txn in allDownloadedTxns)
      {
        if (!existingGloballyUniqueHashes.Contains(txn.GloballyUniqueHash))
        {
          yield return txn;
        }
      }
    }

    private IEnumerable<AccountTransaction> IdentifySurpriseTransactions(TransactionList newTxns, TransactionList existingRecentTxns)
    {
      var newTxnsByAcc = newTxns.ToLookup(txn => txn.Account);
      var existingTxnsByAcc = existingRecentTxns.ToLookup(txn => txn.Account);

      foreach (var newTxnGroup in newTxnsByAcc)
      {
        var affectedAccount = newTxnGroup.Key;
        var existingMatchingTxns = existingTxnsByAcc[affectedAccount];
        var existingTxnsMostRecentDate = existingMatchingTxns.Min(txn => txn.DateOfTransaction);
        foreach (var newTxn in newTxnGroup)
        {
          if (newTxn.DateOfTransaction < existingTxnsMostRecentDate)
          {
            yield return newTxn;
          }
        }
      }
    }
  }
}
