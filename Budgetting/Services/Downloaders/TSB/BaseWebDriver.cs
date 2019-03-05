using System;
using System.Linq;
using Budgetting.Helpers;
using Budgetting.WebScrapers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Budgetting.WebScrapers
{
  public interface IWebDriverFactory
  {

  }
}

namespace Budgetting.Services.Downloaders.TSB
{
  public abstract class BaseWebDriver
  {
    protected BaseWebDriver(IWebDriverFactory driverFactory) { CurrentPage = driver; }
    protected IWebDriver CurrentPage;

    protected void ClickButton(string cssSelector)
    {
      var clickableElement = FindElementWithExpectation(cssSelector, "button", "a");
      clickableElement.Click();
    }

    protected void FillSimpleTextInput(string cssSelector, string textToEnter)
    {
      throw new NotImplementedException();
    }

    protected void SetDropdown(string cssSelector, string textToEnter)
    {
      var selectElement = FindElementWithExpectation(cssSelector, "select");
      var selectObject = new SelectElement(selectElement);
      selectObject.SelectByText(textToEnter);
    }

    protected void WaitForPageToLoad(string url, string identifyingCssSelector)
    {
      throw new NotImplementedException();
    }

    private IWebElement FindElementWithExpectation(string cssSelector, params string[] expectedTagNames)
    {
      var element = FindElementWithExpectation(cssSelector, "select");

      if (element == null)
      {
        throw new Exception($"No element found matching selector: '{cssSelector}'");
      }

      if (!expectedTagNames.Contains(element.TagName))
      {
        throw new Exception(
$@"Element found was not the expected type.
Selector: '{cssSelector}'.
Expected Tags: '{expectedTagNames.StringJoin(",")}'.
Element: '{element.ToString()}'.");
      }
      return element;
    }
  }
}