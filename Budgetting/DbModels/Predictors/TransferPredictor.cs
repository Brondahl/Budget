using Budgetting.DbModels.BankAccounts;

namespace Budgetting.DbModels.Predictors
{
  public class PartialTransferPredictor : TransactionPredictor
  {
    public virtual Account PredictedDestinationAccount { get; set; }
  }
}
