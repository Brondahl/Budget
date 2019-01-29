using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budgetting.DbModels.BankAccounts
{
  public enum AccountType
  {
    CurrentAccount,
    CreditCard,
    Savings,
    Other
  }

  public static class KnownAccounts
  {
    public static Account MikeTsbCurrentAccount;
    public static Account MikeTsbCreditCard;
    public static Account JointTsbCurrentAccount;
    public static Account CharlotteTsbCurrentAccount;
    public static Account CharlotteTsbCreditCard;
    public static Account TsbMortgage;

    public static Account MikeNationwideCurrentAccount;
    public static Account MikeNationwideCreditCard;

    public static Account CharlotteSantanderCurrentAccount;
    public static Account MikeSantanderCurrentAccount;
    public static Account MikeSantanderCreditCard;

    public static Account Sbcw;

    public static Account ManualEntry;

    public static void Populate()
    {
      MikeTsbCurrentAccount = new Account();
      MikeTsbCreditCard = new Account();
      JointTsbCurrentAccount = new Account();
      CharlotteTsbCurrentAccount = new Account();
      CharlotteTsbCreditCard = new Account();
      TsbMortgage = new Account();
     
      MikeNationwideCurrentAccount = new Account();
      MikeNationwideCreditCard = new Account();
     
      CharlotteSantanderCurrentAccount = new Account();
      MikeSantanderCurrentAccount = new Account();
      MikeSantanderCreditCard = new Account();
     
      Sbcw = new Account();
     
      ManualEntry = new Account();
    }
  }

  public class Account
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public AccountType Type { get; set; }
  }
}
