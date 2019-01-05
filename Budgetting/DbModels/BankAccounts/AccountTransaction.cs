using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Budgetting.DbModels.Helpers;

namespace Budgetting.DbModels.BankAccounts
{
  public class AccountTransaction
  {
    public int Id { get; set; }
    public virtual Account Account { get; set; }
    public string ImportHash { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    [MoneyColumn] public decimal Amount { get; set; }
    [DateColumn] public DateTime DateOfTransaction { get; set; }
    [DateColumn] public DateTime DateOfImport { get; set; }
  }
}
