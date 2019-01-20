using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Budgetting.WebScrapers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Budgetting.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ScraperController : ControllerBase
  {
    [HttpGet]
    public ActionResult Test()
    {
      return Ok(new Class1().OpenGoogle());
    }
  }
}