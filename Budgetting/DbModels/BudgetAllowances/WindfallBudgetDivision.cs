using Budgetting.DbModels.Budgets;
using Budgetting.DbModels.Helpers;

namespace Budgetting.DbModels.BudgetAllowances
{
  public class WindfallBudgetDivision
  {
    public int Id { get; set; }
    public virtual BudgetTransaction WindfallTransaction { get; set; }
    public virtual Budget AssignedBudget { get; set; }
    [MoneyColumn] public decimal Amount { get; set; }
  }
}
