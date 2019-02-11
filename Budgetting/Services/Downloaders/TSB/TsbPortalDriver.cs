using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budgetting.Services.Downloaders.TSB
{
  public class TsbPortalDriver : IWebPortalDriver<TsbCredentials>, BaseWebDriver
  {
    private object CurrentPage;
    public void Login(TsbCredentials credentials)
    {
      GoToSiteLoginPage();
      //WaitForPageLoad();

      EnterUserName(credentials.UserName);
      EnterPassword(credentials.Password);
      ClickContinue();
      //WaitForPageLoad();

      var passCodeIndexes = ReadPassCodeSelection();
      EnterPassCodeSelection(passCodeIndexes, credentials.PassCode);
      //ClickLogin();
      //WaitForPageLoad();

      VerifyLoggedInOnHomePage();
    }

    private void GoToSiteLoginPage()
    {
      CurrentPage = "https://internetbanking.tsb.co.uk/personal/logon/login/#/login";
    }

    private void EnterUserName(string credentialsUserName)
    {
      var inputBox = "div#userIdInput input";
    }

    private void EnterPassword(string credentialsUserName)
    {
      var passwordBox = "div#password input";
    }

    private void ClickContinue()
    {
      var continueButton = "form[name=loginForm] button.login";
    }

    private int[] ReadPassCodeSelection()
    {
      var passCodeIndexes = new int[3];
      var memorableDataForm = "form[name=memorableInformationForm]";

      var indexInstructions = "";
      for (int i = 0; i < 2; i++)
      {
        var ithIndexInstruction = indexInstructions[i]; 
        passCodeIndexes[i] = ithIndexInstruction;
      }

      return passCodeIndexes;
    }

    private void EnterPassCodeSelection(int[] passCodeIndexes, char[] credentialsPassCode)
    {
      var passCodeInputs = GetMemorableInformationInputs();

      for (int i = 0; i < 2; i++)
      {
        var inputSelect = passCodeInputs[i];
        var passCodeIndex = passCodeIndexes[i];
        var passCodeCharacter = credentialsPassCode[passCodeIndex];

        SetMemorableInformationInput(inputSelect, passCodeCharacter);
      }
    }

    private object[] GetMemorableInformationInputs()
    {
      throw new NotImplementedException();
    }

    private void SetMemorableInformationInput(object inputSelect, char passCodeCharacter)
    {
      throw new NotImplementedException();
    }

    public void GoToHomePage()
    {
      //var button = LocateReturnToHomePageButton();
      //if (button != null)
      //{
      //  Click(button);
      //}
      //else
      //{
      //  throw new NotImplementedException();
      //}
      VerifyLoggedInOnHomePage();
    }

    public void VerifyLoggedInOnHomePage()
    {
    }
  }
}
