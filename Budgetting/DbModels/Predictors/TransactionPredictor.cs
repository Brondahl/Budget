using Budgetting.DbModels.BankAccounts;

namespace Budgetting.DbModels.Predictors
{
  public class TransactionPredictor
  {
    public int Id { get; set; }
    public virtual Account Account { get; set; }
    public string TransactionPattern { get; set; }
    public bool? PatternIsRegex { get; set; }
    public decimal Confidence { get; set; }
  }
}
