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
    private readonly IDrawdownService drawdown;
    private readonly ICredentialsService credentialsService;

    public DrawdownController(IDrawdownService drawdown, ICredentialsService credentialsService)
    {
      this.drawdown = drawdown;
      this.credentialsService = credentialsService;
    }

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
