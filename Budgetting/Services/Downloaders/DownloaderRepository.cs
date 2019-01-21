using System.Collections.Generic;

namespace Budgetting.Services.Downloaders
{
  public interface IDownloaderRepository
  {
    IEnumerable<ITransactionDownloader> GetAll();
  }

  public class DownloaderRepository : IDownloaderRepository
  {
    private readonly IEnumerable<ITransactionDownloader> downloaders;
    public DownloaderRepository(IEnumerable<ITransactionDownloader> codedDownloaders) // Bound by Autofac magic
    {
      downloaders = codedDownloaders;
    }

    public IEnumerable<ITransactionDownloader> GetAll()
    {
      return downloaders;
    }
  }
}
