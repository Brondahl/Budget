using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budgetting.DbModels.Budgets
{
  public class Budget
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public bool HasCategories { get; set; }
    public virtual IEnumerable<BudgetCategory> Categories { get; set; }
    public bool IsIncome { get; set; }
  }

  //public class SpendBudget : Budget { }
  //public class IncomeBudget : Budget { }
}
