namespace Budgetting.Services
{
  public interface IWebPortalDriver<in TCredentials>
  {
    void Login(TCredentials credentials);
    void GoToHomePage();
    void VerifyLoggedInOnHomePage();
  }
}