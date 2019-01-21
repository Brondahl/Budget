using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Budgetting.Services;
using Microsoft.AspNetCore.Mvc;

namespace Budgetting.Controllers
{
  /*
   * Demonstrates basic path routing.
   */
  [Route("api/[controller]")]
  [ApiController]
  public class DrawdownController : ControllerBase
  {
    private IDrawdownService drawdown;
    private ICredentialsService credentialsService;

    [HttpPost]
    //qq Make this Async with UI Updates - SignalR.
    public ActionResult InitiateDrawdown([FromBody]string credentialsUserAuthorisation)
    {
      var credentials = credentialsService.GetCredentials(credentialsUserAuthorisation);
      drawdown.BeginDrawdown(credentials);

      return Ok();
    }
  }
}
