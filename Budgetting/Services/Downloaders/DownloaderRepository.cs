using System.Collections.Generic;

namespace Budgetting.Services.Downloaders
{
  public interface IDownloaderRepository
  {
    IEnumerable<IWebPortalTransactionDownloader> GetAll();
  }

  public class DownloaderRepository : IDownloaderRepository
  {
    private readonly IEnumerable<IWebPortalTransactionDownloader> downloaders;
    public DownloaderRepository(IEnumerable<IWebPortalTransactionDownloader> codedDownloaders) // Bound by Autofac magic
    {
      downloaders = codedDownloaders;
    }

    public IEnumerable<IWebPortalTransactionDownloader> GetAll()
    {
      return downloaders;
    }
  }
}
