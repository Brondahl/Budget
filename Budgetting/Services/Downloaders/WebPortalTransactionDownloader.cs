using System;
using System.Collections.Generic;
using System.Linq;
using Budgetting.DbModels.BankAccounts;
using Budgetting.WebScrapers;
using TransactionList = System.Collections.Generic.List<Budgetting.DbModels.BankAccounts.AccountTransaction>;

namespace Budgetting.Services.Downloaders
{
  public interface IWebPortalTransactionDownloader
  {
    DateTime DetermineLoadDate(IAccountTransactionsService txnService);
    IEnumerable<AccountTransaction> GetAllNewTransactions(IAccountCredentials credentials, DateTime startDate);
  }

  public abstract class WebPortalTransactionDownloader<TCredentials, TWebPortalDriver> : IWebPortalTransactionDownloader
    where TCredentials : class
    where TWebPortalDriver : IWebPortalDriver<TCredentials>
  {
    protected WebPortalTransactionDownloader(TWebPortalDriver dedicatedDriver)
    {
      WebPortalDriver = dedicatedDriver;
    }

    protected abstract IEnumerable<SingleAccountDownloader<TWebPortalDriver>> InternalDownloaders { get; }
    protected abstract TCredentials LoadSpecificCredentials(IAccountCredentials credentials);

    public virtual DateTime DetermineLoadDate(IAccountTransactionsService txnService)
    {
      var mostRecentTransactionsPerAccount = txnService.GetMostRecentTransactionForEachAccount();
      return AccountsToDownload
        .Select(acc => mostRecentTransactionsPerAccount.SingleOrDefault(txn => txn.Account == acc))
        .Min(txn => txn.DateOfImport)
        .AddDays(-10);
    }

    protected TWebPortalDriver WebPortalDriver;
    protected IEnumerable<Account> AccountsToDownload
    {
      get { return InternalDownloaders.Select(dl => dl.Account); }
    }

    public IEnumerable<AccountTransaction> GetAllNewTransactions(IAccountCredentials allCredentials, DateTime startDate)
    {
      var allDownloadedTxns = new TransactionList();

      var credentials = LoadSpecificCredentials(allCredentials);
      WebPortalDriver.Login(credentials);
      foreach (var singleAccountDownloader in InternalDownloaders)
      {
        WebPortalDriver.GoToHomePage();
        WebPortalDriver.VerifyLoggedInOnHomePage();
        var txns = singleAccountDownloader.FetchAllTransactions(WebPortalDriver, startDate);
        MarkHashCollisionsAsNotDuplicates(txns);
        allDownloadedTxns.AddRange(txns);
      }

      return allDownloadedTxns;
    }

    protected void MarkHashCollisionsAsNotDuplicates(List<AccountTransaction> allDownloadedTxns)
    {
      var hashLookup = allDownloadedTxns.ToLookup(txn => txn.ImportHash);
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
