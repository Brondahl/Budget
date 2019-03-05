﻿using System;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace Budgetting.WebScrapers
{
  public interface ITsbPortalDriver : IWebPortalDriver<TsbCredentials>
  {
    void TestIndexEntry(TsbCredentials credentials);
  }

  public class TsbPortalDriver : BaseWebDriver, ITsbPortalDriver
  {
    public TsbPortalDriver(IWebDriverFactory factory) : base(factory) { }
    public void TestIndexEntry(TsbCredentials credentials)
    {
      CurrentPage.Url = @"file:///C:/Work/Budget/Bank%20pages/TSB/Login.html#";
      System.Threading.Thread.Sleep(2500);//WaitForPageLoad();

      var passCodeIndexes = ReadPassCodeSelection();
      EnterPassCodeSelection(passCodeIndexes, credentials.PassCode);
      ClickContinue_Mem();
      //WaitForPageLoad();

      VerifyLoggedInOnHomePage();
    }

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
      ClickContinue_Mem();
      //WaitForPageLoad();

      VerifyLoggedInOnHomePage();
    }

    private void GoToSiteLoginPage()
    {
      CurrentPage.Url = @"https://internetbanking.tsb.co.uk/personal/logon/login/#/login";
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

    private void ClickContinue_Mem()
    {
      var continueButton = "form[name=memorableInformationForm] button[type=submit]";
    }

    private int[] ReadPassCodeSelection()
    {
      var passCodeIndexes = new int[3];
      var memorableDataForm = CurrentPage.FindByCss("form[name=memorableInformationForm]");

      var indexInstructions = memorableDataForm.FindMultipelByCss(".memorable-information-select-size span");
      var indexInstructionsText = indexInstructions.Select(el => el.Text).ToArray();

      for (int i = 0; i < 3; i++)
      {
        //"Character xx:"
        var ithIndexInstruction = indexInstructionsText[i];
        var matchingRegex = new Regex(@"Character (\d*):");
        var ithIndexString = matchingRegex.Match(ithIndexInstruction).Groups.Last().Value;
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