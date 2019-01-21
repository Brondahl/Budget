using System;

namespace Budgetting.Services
{
  public interface ICredentialsService
  {
    IAccountCredentials GetCredentials(string userCredentialAuthorisation);
  }

  public class CredentialsService : ICredentialsService
  {
    public IAccountCredentials GetCredentials(string userCredentialAuthorisation)
    {
      throw new NotImplementedException();
    }
  }
}
