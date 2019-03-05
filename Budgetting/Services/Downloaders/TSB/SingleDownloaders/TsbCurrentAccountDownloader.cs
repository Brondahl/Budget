using System;
using System.Collections.Generic;
using Budgetting.DbModels.BankAccounts;

namespace Budgetting.Services.Downloaders.TSB
{
  public class TsbCharlotteCurrentAccountDownloader : TsbCurrentAccountDownloader
  {
    public override Account Account => KnownAccounts.CharlotteTsbCurrentAccount;
  }

  public class TsbJointCurrentAccountFromMikeLoginDownloader : TsbCurrentAccountDownloader
  {
    public override Account Account => KnownAccounts.JointTsbCurrentAccount;
  }

  public class TsbMikeCurrentAccountDownloader : TsbCurrentAccountDownloader
  {
    public override Account Account => KnownAccounts.MikeTsbCurrentAccount;
  }

  public abstract class TsbCurrentAccountDownloader : SingleAccountDownloader<ITsbPortalDriver>
  {
    public override List<AccountTransaction> FetchAllTransactions(ITsbPortalDriver driver, DateTime startDate)
    {
      throw new NotImplementedException();
    }

    public override decimal GetCurrentBalance(ITsbPortalDriver driver)
    {
      throw new NotImplementedException();
    }
  }
}