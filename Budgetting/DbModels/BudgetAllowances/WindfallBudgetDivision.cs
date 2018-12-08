using Budgetting.DbModels.Budgets;

namespace Budgetting.DbModels.BudgetAllowances
{
  public class WindfallBudgetDivision
  {
    public int Id { get; set; }
    public virtual BudgetTransaction WindfallTransaction { get; set; }
    public virtual Budget AssignedBudget { get; set; }
    public decimal Amount { get; set; }
  }
}
