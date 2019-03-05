using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Budgetting.WebScrapers;

namespace Budgetting.Services.Downloaders.TSB
{
  public class TsbMikeDownloader : WebPortalTransactionDownloader<TsbCredentials, ITsbPortalDriver>
  {
    public TsbMikeDownloader(ITsbPortalDriver tsbDriver) : base(tsbDriver) { }

    protected override IEnumerable<SingleAccountDownloader<ITsbPortalDriver>> InternalDownloaders
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
