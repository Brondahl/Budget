using Budgetting.DbModels.Budgets;
using Budgetting.DbModels.Helpers;

namespace Budgetting.DbModels.BudgetAllowances
{
  public class DiscretionaryBudgetTransfer
  {
    public int Id { get; set; }
    public virtual Budget OriginBudget { get; set; }
    public virtual Budget DestinationBudget { get; set; }
    [MoneyColumn] public decimal Amount { get; set; }
    public virtual BudgetMonth Month { get; set; }
    public string Notes { get; set; }
  }
}
