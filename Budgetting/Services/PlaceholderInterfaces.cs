using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Budgetting.DbModels.BankAccounts;
using Budgetting.Helpers;

namespace Budgetting.Services
{
  public interface IAccountCredentials
  {
    string this[string indexer] { get; }
  }

  public interface IAccountsService
  {
    IEnumerable<Account> GetAll();
  }

  public interface IAccountTransactionsService
  {
    List<AccountTransaction> GetMostRecentTransactionForEachAccount();
    List<AccountTransaction> GetAllTransactionsSince(DateTime startDate);
    void SaveNewTransactions(List<AccountTransaction> newlyImportedTxs);
    void RecordTransactionsForUserAttention(List<AccountTransaction> newlyImportedTxs);
    void UpdateExistingTransaction(AccountTransaction existingTxnToUpdate);
  }
}