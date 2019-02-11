using System;
using System.Collections.Generic;
using Budgetting.DbModels.BankAccounts;

namespace Budgetting.Services.Downloaders.TSB
{
  public class TsbMortgageDownloader : SingleAccountDownloader<TsbPortalDriver>
  {
    public override Account Account => KnownAccounts.TsbMortgage;

    public override List<AccountTransaction> FetchAllTransactions(TsbPortalDriver driver, DateTime startDate)
    {
      return new List<AccountTransaction>();
    }

    public override decimal GetCurrentBalance(TsbPortalDriver driver)
    {
      throw new NotImplementedException();
    }
  }
}