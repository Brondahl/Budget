using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Budgetting.WebScrapers
{
  public enum Browser
  {
    Firefox,
    Chrome
  }

  public interface IWebDriverFactory
  {
    IWebDriver Build(Browser browser);
  }

  public class WebDriverFactory
  {
    public IWebDriver Build(Browser browser)
    {
      var thisDllLocation = Path.GetDirectoryName(Assembly.GetAssembly(this.GetType()).Location);
      var webDriverExeLocations = Path.Combine(thisDllLocation, "WebDriverExes");

      switch (browser)
      {
        case Browser.Firefox: return new FirefoxDriver(webDriverExeLocations);
        case Browser.Chrome: return new ChromeDriver(webDriverExeLocations);
      }
    }
  }
}
