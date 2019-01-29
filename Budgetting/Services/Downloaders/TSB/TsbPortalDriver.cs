using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budgetting.Services.Downloaders.TSB
{
  public class TsbPortalDriver : IWebPortalDriver<TsbCredentials>
  {
    public void Login(TsbCredentials credentials)
    {
      GoToSiteLoginPage();
      WaitForPageLoad();

      EnterUserName(credentials.UserName);
      EnterPassword(credentials.Password);
      ClickLogin();
      WaitForPageLoad();

      var passCodeIndexes = ReadPassCodeSelection();
      EnterPassCodeSelection(passCodeIndexes, credentials.PassCode);
      ClickLogin();
      WaitForPageLoad();

      VerifyLoggedInOnHomePage();
    }

    public void GoToHomePage()
    {
      var button = LocateReturnToHomePageButton();
      if (button != null)
      {
        Click(button);
      }
      else
      {
        throw new NotImplementedException();
      }
      VerifyLoggedInOnHomePage();
    }

  }
}
