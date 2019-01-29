using System;
using System.Collections.Generic;
using Budgetting.DbModels.BankAccounts;

namespace Budgetting.Services.Downloaders.TSB
{
  public class TsbCharlotteCreditCardDownloader : TsbCreditCardDownloader
  {
    public override Account Account { get; }
  }

  public class TsbMikeCreditCardDownloader : TsbCreditCardDownloader
  {
    public override Account Account { get; }
  }

  public abstract class TsbCreditCardDownloader : SingleAccountDownloader<TsbPortalDriver>
  {
    public override List<AccountTransaction> FetchAllTransactions(TsbPortalDriver driver, DateTime startDate)
    {
      throw new NotImplementedException();
    }
  }

}