using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Budgetting.Services.Downloaders.TSB
{
  public class TsbPortalDriver : BaseWebDriver, IWebPortalDriver<TsbCredentials>
  {
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

      var indexInstructions = ".memorable-information-select-size span";
      var indexInstructionsText = new string[3];

      for (int i = 0; i < 2; i++)
      {
        //"Character xx:"
        var ithIndexInstruction = indexInstructionsText[i];
        var matchingRegex = new Regex(@"Character (\d*):");
        var ithIndexString = matchingRegex.Match(ithIndexInstruction).Captures.Single().Value;
        passCodeIndexes[i] = int.Parse(ithIndexString);
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
      var selectCssSelectors = new[] { "X", "Y", "Z" }.Select(index => $"select#char{index}Pos");

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
