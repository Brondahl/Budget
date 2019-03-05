using System;
using System.Collections.Generic;
using Budgetting.DbModels.BankAccounts;

namespace Budgetting.Services.Downloaders.TSB
{
  public class TsbCharlotteCreditCardDownloader : TsbCreditCardDownloader
  {
    public override Account Account => KnownAccounts.CharlotteTsbCreditCard;
  }

  public class TsbMikeCreditCardDownloader : TsbCreditCardDownloader
  {
    public override Account Account => KnownAccounts.MikeTsbCreditCard;
  }

  public abstract class TsbCreditCardDownloader : SingleAccountDownloader<ITsbPortalDriver>
  {
    public override List<AccountTransaction> FetchAllTransactions(ITsbPortalDriver driver, DateTime startDate)
    {
      driver.VerifyLoggedInOnHomePage();
      throw new NotImplementedException();
    }

    public override decimal GetCurrentBalance(ITsbPortalDriver driver)
    {
      driver.VerifyLoggedInOnHomePage();
      throw new NotImplementedException();
    }
  }
}