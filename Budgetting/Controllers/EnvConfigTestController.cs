using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using StartupPlugins;

namespace Budgetting.Controllers
{
  /*
   * Demonstrates reading config for different environments.
   */
  [Route("api/[controller]")]
  [ApiController]
  public class EnvConfigTestController : ControllerBase
  {
    private readonly SettingsTest testConfig;
    private readonly IConfiguration config;
    public EnvConfigTestController(IOptions<SettingsTest> testConfig, IConfiguration generalConfig)
    {
      this.testConfig = testConfig.Value;
      this.config = generalConfig;
    }

    [HttpGet("ShowConfigValues")]
    public ActionResult<string> Get()
    {
      return $"Global: {testConfig.SettingGlobal} | Per Env: {testConfig.SettingPerEnv}";
    }

    [HttpGet("ShowConnectionString")]
    public ActionResult<string> GetCononString(string connectionName)
    {
      return $"ConnectionName: {connectionName} | ConnectionString: {config.GetConnectionString(connectionName)}";
    }
  }
}
