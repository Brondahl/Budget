//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using Budgetting.DbModels.BankAccounts;

//namespace Budgetting.Helpers
//{
//  public class TransactionList : IList<AccountTransaction>, IEnumerable<AccountTransaction>
//  {
//    private List<AccountTransaction> txns;
//    #region IList interface
//    public int Count => txns.Count;

//    public bool IsReadOnly => false;

//    public AccountTransaction this[int index] { get => txns[index]; set => txns[index] = value; }

//    public int IndexOf(AccountTransaction item)
//    {
//      return txns.IndexOf(item);
//    }

//    public void Insert(int index, AccountTransaction item)
//    {
//      txns.Insert(index, item);
//    }

//    public void RemoveAt(int index)
//    {
//      txns.RemoveAt(index);
//    }

//    public void Add(AccountTransaction item)
//    {
//      txns.Add(item);
//    }

//    public void AddRange(IEnumerable<AccountTransaction> items)
//    {
//      txns.AddRange(items);
//    }

//    public void Clear()
//    {
//      txns.Clear();
//    }

//    public bool Contains(AccountTransaction item)
//    {
//      return txns.Contains(item);
//    }

//    public void CopyTo(AccountTransaction[] array, int arrayIndex)
//    {
//      txns.CopyTo(array, arrayIndex);
//    }

//    public bool Remove(AccountTransaction item)
//    {
//      return txns.Remove(item);
//    }
//    #endregion
//    #region IEnumerable interface
//    public IEnumerator<AccountTransaction> GetEnumerator()
//    {
//      return txns.GetEnumerator();
//    }

//    IEnumerator IEnumerable.GetEnumerator()
//    {
//      return txns.GetEnumerator();
//    }
//    #endregion

//    public TransactionList() { this.txns = new List<AccountTransaction>(); }
//    public TransactionList(IEnumerable<AccountTransaction> txns) { this.txns = txns.ToList(); }
//    public static implicit operator TransactionList(List<AccountTransaction> listOfTxnsToConvert)
//    {
//      return new TransactionList(listOfTxnsToConvert);
//    }

//    public static implicit operator List<AccountTransaction> (TransactionList txnListToConvert)
//    {
//      return txnListToConvert.txns;
//    }


//    public string SummaryText()
//    {
//      return
//        $@"Count: {txns.Count}
//Discriminators: {txns.Select(txn => txn.IdenticalTransactionDiscriminator.ToString()).StringJoin(", ")}
//Accounts: {txns.Select(txn => txn.Account.Id.ToString()).Distinct().StringJoin(",")}
//Import Date Range: {txns.Select(txn => txn.DateOfImport).Min()} - {txns.Select(txn => txn.DateOfImport).Max()}
//Transaction Date Range: {txns.Select(txn => txn.DateOfTransaction).Min()} - {txns.Select(txn => txn.DateOfTransaction).Max()}
//";
//    }
//  }
//}
