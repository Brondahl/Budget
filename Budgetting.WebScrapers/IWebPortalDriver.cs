namespace Budgetting.WebScrapers
{
  public interface IWebPortalDriver<in TCredentials>
  {
    void Login(TCredentials credentials);
    void GoToHomePage();
    void VerifyLoggedInOnHomePage();
  }
}