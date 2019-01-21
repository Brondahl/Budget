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
    }

    public interface IAccountsService
    {
      IEnumerable<Account> GetAll();
    }

    public interface IAccountTransactionsService
    {
      TransactionList GetMostRecentTransactionForEachAccount();
      TransactionList GetAllTransactionsSince(DateTime startDate);
      void SaveNewTransactions(TransactionList newlyImportedTxs);
      void RecordTransactionsForUserAttention(TransactionList newlyImportedTxs);
      void UpdateExistingTransaction(AccountTransaction existingTxnToUpdate);
    }
}
