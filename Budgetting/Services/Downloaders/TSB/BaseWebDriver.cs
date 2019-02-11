using System;

namespace Budgetting.Services.Downloaders.TSB
{
  internal class BaseWebDriver
  {
    protected object CurrentPage;
    protected void ClickButton(string cssSelector)
    {
      throw new NotImplementedException();
    }

    protected void FillSimpleTextInput(string textToEnter, string cssSelector)
    {
      throw new NotImplementedException();
    }

    protected void WaitForPageToLoad(string url, string identifyingCssSelector)
    {
      throw new NotImplementedException();
    }

  }
}