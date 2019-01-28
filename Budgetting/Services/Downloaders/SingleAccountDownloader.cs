using System;
using System.Collections.Generic;
using Budgetting.DbModels.BankAccounts;

namespace Budgetting.Services.Downloaders
{
  public abstract class SingleAccountDownloader<TWebPortalDriver>
  {
    public abstract Account Account { get; }
    public abstract List<AccountTransaction> FetchAllTransactions(TWebPortalDriver driver, DateTime startDate);
  }
}
