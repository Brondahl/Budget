using Budgetting.DbModels.Budgets;

namespace Budgetting.DbModels.Predictors
{
  public class TransactionBudgetPredictor : TransactionPredictor
  {
    public virtual Budget PredictedBudget { get; set; }
    public virtual BudgetCategory PredictedBudgetCategory { get; set; }
    public string PredictedDescription { get; set; }
  }
}
