using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Budgetting.DbModels;
using Microsoft.AspNetCore.Mvc;

namespace Budgetting.Controllers
{
  /*
   * Demonstrates basic path routing.
   */
  [Route("api/[controller]")]
  [ApiController]
  public class DbAccessTestController : ControllerBase
  {
    private readonly BudgettingDbContext db;
    public DbAccessTestController(BudgettingDbContext db)
    {
      this.db = db;
    }

    // GET api/values
    [HttpGet]
    public ActionResult<int> Get()
    {
      return db.Accounts.Count();
    }
  }
}
