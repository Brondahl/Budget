using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budgetting.DbModels.Budgets
{
  public class BudgetCategory
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual Budget Budget { get; set; }
  }
}
