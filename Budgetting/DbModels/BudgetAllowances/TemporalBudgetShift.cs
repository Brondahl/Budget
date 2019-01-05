using Budgetting.DbModels.Budgets;
using Budgetting.DbModels.Helpers;

namespace Budgetting.DbModels.BudgetAllowances
{
  public class TemporalBudgetShift
  {
    public int Id { get; set; }
    public virtual Budget AssignedBudget { get; set; }
    [MoneyColumn] public decimal Amount { get; set; }
    public virtual BudgetMonth InitialMonth { get; set; }
    public int PaybackLength { get; set; }
  }
}
