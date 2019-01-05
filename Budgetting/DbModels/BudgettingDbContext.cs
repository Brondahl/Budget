using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Budgetting.DbModels.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Budgetting.DbModels
{
  public class BudgettingDbContext : DbContext
  {
    public BudgettingDbContext(DbContextOptions<BudgettingDbContext> options)
      : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.ApplyColumTypeConventions(
        new EfSqlColumnTypeConvention<decimal>("decimal(9,2)"),
        new EfSqlColumnTypeConvention<DateTime>("date")
      );
    }

  }
}
