using System;
using System.Collections.Generic;
using System.Linq;
using Budgetting.DbModels.BankAccounts;

namespace Budgetting.Services.Downloaders
{
  public interface ITransactionDownloader
  {
    DateTime DetermineLoadDate(IAccountTransactionsService txnService);
    IEnumerable<AccountTransaction> GetAllNewTransactions(IAccountCredentials credentials, DateTime startDate);
  }

  public abstract class TransactionDownloader<TSpecificAccountCredentials> : ITransactionDownloader where TSpecificAccountCredentials : class
  {
    protected DateTime loadDate = DateTime.MinValue;
    protected TSpecificAccountCredentials credentials = null;

    protected abstract TSpecificAccountCredentials LoadSpecificCredentials(IAccountCredentials credentials);
    protected abstract IEnumerable<Account> ListTargetAccounts();
    protected abstract List<AccountTransaction> FetchAllTransactions();

    public virtual DateTime DetermineLoadDate(IAccountTransactionsService txnService)
    {
      var mostRecentTransactionsPerAccount = txnService.GetMostRecentTransactionForEachAccount();
      return ListTargetAccounts()
        .Select(acc => mostRecentTransactionsPerAccount.SingleOrDefault(txn => txn.Account == acc))
        .Min(txn => txn.DateOfImport)
        .AddDays(-10);
    }

    public IEnumerable<AccountTransaction> GetAllNewTransactions(IAccountCredentials allCredentials, DateTime startDate)
    {
      loadDate = startDate;
      credentials = LoadSpecificCredentials(allCredentials);
      var allDownloadedTxns = FetchAllTransactions();
      MarkHashCollisionsAsNotDuplicates(allDownloadedTxns);
      throw new NotImplementedException();
    }


    protected void MarkHashCollisionsAsNotDuplicates(List<AccountTransaction> allDownloadedTxns)
    {
      var hashLookup = allDownloadedTxns.ToLookup(txn => txn.AccountPlusImportHash);
      var collisionHashGroups = hashLookup.Where(hashGroup => hashGroup.Count() > 1);

      foreach (var txnGroup in collisionHashGroups)
      {
        int counter = 1;
        foreach (var txn in txnGroup)
        {
          txn.IdenticalTransactionDiscriminator = counter;
          counter++;
        }
      }
    }


  }
}
