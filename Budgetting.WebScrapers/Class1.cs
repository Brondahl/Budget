using System;
using System.IO;
using System.Reflection;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Budgetting.WebScrapers
{
  /*
   ---------------------------
Microsoft Visual Studio
---------------------------
Unable to start process C:\Program Files\dotnet\dotnet.exe. The web server request failed with status code 502, Bad Gateway. The full response has been written to C:\Users\Brondahl\AppData\Local\Temp\HttpFailure_11-49-18.html.
---------------------------
OK   
---------------------------


    driver exes are currently manually copied into Nuget package folder. Seems wrong.
    Nuget isn't creating a packages folder in my project. Seems Wrong.
    WebDriver looks in packages but not in project - which is where the WebDriver NuGet packages put stuff. Seems Wrong.
    WebDriver doesn't tell you where it's looking.
    Probably none of this will work on Azure.
    Chrome seems to know it's being controlled by Selenium.
     */
  public class Class1
  {
    public string OpenGoogle()
    {
      var dir1 = Environment.CurrentDirectory;
      var dir2 = Directory.GetCurrentDirectory();
      IWebDriver driver = new ChromeDriver();
      IWebDriver driver2 = new ChromeDriver(Path.GetDirectoryName(Assembly.GetAssembly(typeof(Class1)).Location));
      IWebDriver driver3 = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
      Thread.Sleep(2500);
      driver.Url = "http://www.google.com";
      Thread.Sleep(2500);
      var chromeTitle = driver.Title;
      Thread.Sleep(2500);
      driver.Close();

      Thread.Sleep(2500);
      driver = new FirefoxDriver();
      Thread.Sleep(2500);
      driver.Url = "http://www.google.com";
      Thread.Sleep(2500);
      var searchBox = driver.FindElement(By.CssSelector("input[aria-label=Search]"));
      Thread.Sleep(2500);
      searchBox.SendKeys("test");
      Thread.Sleep(2500);
      var searchButton = driver.FindElement(By.CssSelector("input[aria-label=\"Google Search\"]"));
      Thread.Sleep(2500);
      searchButton.Click();
      Thread.Sleep(2500);
      var ffxTitle = driver.Title;
      Thread.Sleep(2500);
      driver.Close();
      Thread.Sleep(2500);

      return chromeTitle + "|" + ffxTitle;
    }
  }
}
