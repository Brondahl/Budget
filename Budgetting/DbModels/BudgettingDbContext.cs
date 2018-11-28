using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Budgetting.DbModels
{
  public class BudgettingDbContext : DbContext
  {
    public BudgettingDbContext(DbContextOptions<BudgettingDbContext> options)
      : base(options)
    {
    }

  }
}
