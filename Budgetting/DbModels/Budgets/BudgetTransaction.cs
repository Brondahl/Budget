using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Budgetting.DbModels.Budgets
{
  public class BudgetTransaction
  {
    public int Id { get; set; }
    public virtual BudgetMonth Month { get; set; }
    public decimal Amount { get; set; }
    public virtual Budget Budget { get; set; }
    public virtual BudgetCategory Category { get; set; }
    public string Description { get; set; }
    public string Notes { get; set; }
    public bool IsExpectingRefund { get; set; }

    public bool IsIncome => Budget.IsIncome;
  }
}
