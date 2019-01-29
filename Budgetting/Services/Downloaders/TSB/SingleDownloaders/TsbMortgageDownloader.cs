using System;
using System.Collections.Generic;
using Budgetting.DbModels.BankAccounts;

namespace Budgetting.Services.Downloaders.TSB
{
  public class TsbMortgageDownloader : SingleAccountDownloader<TsbPortalDriver>
  {
    public override Account Account { get; }
    public override List<AccountTransaction> FetchAllTransactions(TsbPortalDriver driver, DateTime startDate)
    {
      throw new NotImplementedException();
    }
  }
}