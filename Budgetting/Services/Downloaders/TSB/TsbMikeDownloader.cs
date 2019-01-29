using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budgetting.Services.Downloaders.TSB
{
  public class TsbMikeDownloader : WebPortalTransactionDownloader<TsbCredentials, TsbPortalDriver>
  {
    protected override IEnumerable<SingleAccountDownloader<TsbPortalDriver>> InternalDownloaders
    {
      get
      {
        yield return new TsbMikeCurrentAccountDownloader();
        yield return new TsbJointCurrentAccountFromMikeLoginDownloader();
        yield return new TsbMikeCreditCardDownloader();
        yield return new TsbMortgageDownloader();
      }
    }

    protected override TsbCredentials LoadSpecificCredentials(IAccountCredentials credentials)
    {
      return new TsbCredentials
      {
        UserName = credentials["MikeTsbUserName"],
        Password = credentials["MikeTsbPassword"],
        PassCode = credentials["MikeTsbPassCode"].ToCharArray()
      };
    }
  }
}
