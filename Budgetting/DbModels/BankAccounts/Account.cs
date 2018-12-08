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

  public class Account
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public AccountType Type { get; set; }
  }
}
