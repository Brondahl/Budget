using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budgetting.Services.Downloaders.TSB
{
  public class TsbDownloader : WebPortalTransactionDownloader<TsbCredentials, TsbPortalDriver>
  {
    protected override IEnumerable<SingleAccountDownloader<TsbPortalDriver>> InternalDownloaders
    {
      get
      {
        return;
      }
    }

    protected override TsbCredentials LoadSpecificCredentials(IAccountCredentials credentials)
    {
      throw new NotImplementedException();
    }
  }
}
