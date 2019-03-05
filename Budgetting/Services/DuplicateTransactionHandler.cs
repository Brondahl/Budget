using System;
using System.Linq;
using Budgetting.Common;
using Budgetting.Helpers;
using TransactionList = System.Collections.Generic.List<Budgetting.DbModels.BankAccounts.AccountTransaction>;

namespace Budgetting.Services
{
  public interface IDuplicateTransactionHandler
  {
    void SynchroniseDistinguishedDuplicates(TransactionList allDownloadedTxns, TransactionList existingRecentTxns);
  }

  public class DuplicateTransactionHandler : IDuplicateTransactionHandler
  {
    private readonly IAccountTransactionsService txnService;

    public DuplicateTransactionHandler(
      IAccountTransactionsService txnService)
    {
      this.txnService = txnService;
    }

    public void SynchroniseDistinguishedDuplicates(TransactionList allDownloadedTxns, TransactionList existingRecentTxns)
    {
      var downloadTxnsByAccAndHash = allDownloadedTxns.ToLookup(txn => txn.AccountPlusImportHash);
      var existingTxnsByAccAndHash = existingRecentTxns.ToLookup(txn => txn.AccountPlusImportHash);

      foreach (var downloadedTxnsAccHashGroup in downloadTxnsByAccAndHash)
      {
        var hashDownloadedTxns = downloadedTxnsAccHashGroup.ToList();
        var hashExistingTxns = existingTxnsByAccAndHash[downloadedTxnsAccHashGroup.Key].ToList();
        if (hashDownloadedTxns.Count <= 1) { continue; }
        if (hashExistingTxns.Count == 0) { continue; }

        SynchroniseDistinguishedDuplicatesInSingleAccountHashGroup(hashDownloadedTxns, hashExistingTxns);
      }
    }

    /// <summary>
    /// Receives 2 sets of txns which are in the same account and have the same Hashes.
    /// Ensures that any discriminators are consistent between the two sets.
    /// Updates existing Txns in DB where appropriate.
    /// </summary>
    /// <param name="downloadedTxns"></param>
    /// <param name="existingTxns"></param>
    /// <returns></returns>
    private void SynchroniseDistinguishedDuplicatesInSingleAccountHashGroup(
      TransactionList downloadedTxns,
      TransactionList existingTxns)
    {
      var existingCount = existingTxns.Count();
      var downloadedCount = downloadedTxns.Count();
      var txnDetailsText = ContextualErrorMessageComparisonInfo(downloadedTxns, existingTxns);
      if (existingCount == 0)
      {
        throw new Exception("Matched Existing Txn Set is empty. errrr ... wat!?" + txnDetailsText);
      }

      if (downloadedCount == 0)
      {
        throw new Exception("Matched Downloaded Txn Set is empty. errrr ... wat!?" + txnDetailsText);
      }

      if (downloadedCount == 1)
      {
        throw new Exception("Matched Existing Txn Set is singleton. errrr ... wat!?" + txnDetailsText);
      }

      if (downloadedCount < existingCount)
      {
        throw new Exception("Number of identical Txns has decreased. errrr ... wat!?." + txnDetailsText);
      }

      if (existingCount == 1)
      {
        var txn = existingTxns.Single();
        if (txn.IdenticalTransactionDiscriminator.HasValue)
        {
          throw new Exception("Singleton existing Txn has non-NULL discriminator. errrr ... wat!?" + txnDetailsText);
        }
        txn.IdenticalTransactionDiscriminator = 1;
        txnService.UpdateExistingTransaction(txn);
        return;
      }

      // We now know that there a multiple downloaded, and multiple existing,
      // and that there are at least as many downloaded as existing.
      //
      // All that's left to check is that Existing is a subset of Downloaded,
      // and that Downloaded discriminators are all distinct.
      var downloadedDiscriminators = downloadedTxns.Select(txn => txn.IdenticalTransactionDiscriminator).ToList();
      var existingDiscriminators = existingTxns.Select(txn => txn.IdenticalTransactionDiscriminator).ToList();

      if (downloadedDiscriminators.Distinct().Count() != downloadedDiscriminators.Count)
      {
        throw new Exception("Downloaded Discriminators were not unique." + txnDetailsText);
      }

      foreach (var existingDiscriminator in existingDiscriminators)
      {
        if (!downloadedDiscriminators.Contains(existingDiscriminator))
        {
          throw new Exception("Downloaded Discriminators do not cover Existing Discriminators." + txnDetailsText);
        }
      }
    }

    private string ContextualErrorMessageComparisonInfo(TransactionList downloadedTxns, TransactionList existingTxns)
    {
      return $@"
Downloaded:
{TransactionSetSummaryText(downloadedTxns)}

Existing:
{TransactionSetSummaryText(existingTxns)}
";
    }

    private string TransactionSetSummaryText(TransactionList txns)
    {
      return
$@"Count: {txns.Count}
Discriminators: {txns.Select(txn => txn.IdenticalTransactionDiscriminator.ToString()).StringJoin(", ")}
Accounts: {txns.Select(txn => txn.Account.Id.ToString()).Distinct().StringJoin(",")}
Import Date Range: {txns.Select(txn => txn.DateOfImport).Min()} - {txns.Select(txn => txn.DateOfImport).Max()}
Transaction Date Range: {txns.Select(txn => txn.DateOfTransaction).Min()} - {txns.Select(txn => txn.DateOfTransaction).Max()}
";
    }
  }
}
