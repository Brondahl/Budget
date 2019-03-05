using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Budgetting.Services.Downloaders.TSB;
using Budgetting.WebScrapers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Budgetting.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ScraperController : ControllerBase
  {
    [HttpGet("Google")]
    public ActionResult Test()
    {
      return Ok(SeleniumExtensions.OpenGoogle());
    }
    [HttpGet("DropdownsOnFile")]
    public ActionResult DropdownsOnFile()
    {
      new TsbPortalDriver(new WebDriverFactory()).TestIndexEntry(new TsbCredentials {PassCode = "abcdefg".ToCharArray()});
      return Ok();
    }
  }
}