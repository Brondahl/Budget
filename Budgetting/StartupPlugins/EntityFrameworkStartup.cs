﻿using Budgetting.DbModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace StartupPlugins
{
  public static class EntityFrameworkStartup
  {
    public static IServiceCollection ConfigureDbConnection(this IServiceCollection services, IConfiguration config, bool useInMemory = false)
    {
      if (useInMemory)
      {
        //This sets up a transient in-memory DB. Useful for tests, perhaps?
        //Data is persisted whilst the API is running, but is lost when the API is restarted.
        services.AddDbContext<BudgettingDbContext>(options => options.UseInMemoryDatabase("BudgettingDb"));
      }
      else
      {
        var connectionString = config.GetConnectionString("BudgettingDbConn");
        services.AddDbContext<BudgettingDbContext>(options => options.UseSqlServer(connectionString));
      }
      return services;
    }

    public static IWebHost MigrateDatabase(this IWebHost webHost)
    {
      var serviceScopeFactory = (IServiceScopeFactory)webHost.Services.GetService(typeof(IServiceScopeFactory));

      using (var scope = serviceScopeFactory.CreateScope())
      {
        var services = scope.ServiceProvider;
        var dbContext = services.GetRequiredService<BudgettingDbContext>();

        dbContext.Database.Migrate();
      }

      return webHost;
    }
  }
}
