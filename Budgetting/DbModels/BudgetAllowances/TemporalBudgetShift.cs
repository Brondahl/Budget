using Budgetting.DbModels.Budgets;

namespace Budgetting.DbModels.BudgetAllowances
{
  public class TemporalBudgetShift
  {
    public int Id { get; set; }
    public virtual Budget AssignedBudget { get; set; }
    public decimal Amount { get; set; }
    public virtual BudgetMonth InitialMonth { get; set; }
    public int PaybackLength { get; set; }
  }
}
