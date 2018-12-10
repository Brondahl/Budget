namespace Budgetting.DbModels.Predictors
{
  public class TransferPairPredictor
  {
    public int Id { get; set; }
    public virtual TransactionPredictor OutboundTransfer { get; set; }
    public virtual TransactionPredictor InboundTransfer { get; set; }
  }
}
