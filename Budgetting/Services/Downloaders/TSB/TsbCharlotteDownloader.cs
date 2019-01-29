using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budgetting.Services.Downloaders.TSB
{
  public class TsbCharlotteDownloader : WebPortalTransactionDownloader<TsbCredentials, TsbPortalDriver>
  {
    protected override IEnumerable<SingleAccountDownloader<TsbPortalDriver>> InternalDownloaders
    {
      get
      {
        yield return new TsbCharlotteCurrentAccountDownloader();
        yield return new TsbCharlotteCreditCardDownloader();
      }
    }

    protected override TsbCredentials LoadSpecificCredentials(IAccountCredentials credentials)
    {
      return new TsbCredentials
      {
        UserName = credentials["CharlotteTsbUserName"],
        Password = credentials["CharlotteTsbPassword"],
        PassCode = credentials["CharlotteTsbPassCode"].ToCharArray()
      };
    }
  }
}
