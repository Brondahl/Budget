using System;
using System.Collections.Generic;
using Budgetting.DbModels.BankAccounts;

namespace Budgetting.Services.Downloaders.TSB
{
  public class TsbCharlotteCurrentAccountDownloader : TsbCurrentAccountDownloader
  {
    public override Account Account { get; }
  }

  public class TsbJointCurrentAccountFromMikeLoginDownloader : TsbCurrentAccountDownloader
  {
    public override Account Account { get; }
  }

  public class TsbMikeCurrentAccountDownloader : TsbCurrentAccountDownloader
  {
    public override Account Account { get; }
  }

  public abstract class TsbCurrentAccountDownloader : SingleAccountDownloader<TsbPortalDriver>
  {
    public override List<AccountTransaction> FetchAllTransactions(TsbPortalDriver driver, DateTime startDate)
    {
      throw new NotImplementedException();
    }
  }

}