using System;
using System.Collections.Generic;
using Budgetting.DbModels.BankAccounts;
using Budgetting.WebScrapers;

namespace Budgetting.Services.Downloaders.TSB
{
  public class TsbMortgageDownloader : SingleAccountDownloader<ITsbPortalDriver>
  {
    public override Account Account => KnownAccounts.TsbMortgage;

    public override List<AccountTransaction> FetchAllTransactions(ITsbPortalDriver driver, DateTime startDate)
    {
      return new List<AccountTransaction>();
    }

    public override decimal GetCurrentBalance(ITsbPortalDriver driver)
    {
      throw new NotImplementedException();
    }
  }
}