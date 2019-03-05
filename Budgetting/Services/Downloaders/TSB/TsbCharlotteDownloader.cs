using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Budgetting.WebScrapers;

namespace Budgetting.Services.Downloaders.TSB
{
  public class TsbCharlotteDownloader : WebPortalTransactionDownloader<TsbCredentials, ITsbPortalDriver>
  {
    public TsbCharlotteDownloader(ITsbPortalDriver tsbDriver) : base(tsbDriver) {}

    protected override IEnumerable<SingleAccountDownloader<ITsbPortalDriver>> InternalDownloaders
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
