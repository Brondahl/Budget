using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Budgetting.DbModels.BankAccounts;
using Budgetting.DbModels.BudgetAllowances;
using Budgetting.DbModels.Budgets;
using Budgetting.DbModels.Helpers;
using Budgetting.DbModels.Predictors;
using Microsoft.EntityFrameworkCore;

namespace Budgetting.DbModels
{
  public class BudgettingDbContext : DbContext
  {
    public BudgettingDbContext(DbContextOptions<BudgettingDbContext> options)
      : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountTransaction> AccountTransactions { get; set; }
    public DbSet<RefundTransaction> RefundTransaction { get; set; }
    public DbSet<TransferTransaction> TransferTransaction { get; set; }

    public DbSet<Budget> Budgets { get; set; }
    public DbSet<BudgetCategory> BudgetCategories { get; set; }
    public DbSet<BudgetMonth> BudgetMonths { get; set; }
    public DbSet<BudgetTransaction> BudgetTransactions { get; set; }

    public DbSet<DiscretionaryBudgetTransfer> BudgetTransfers { get; set; }
    public DbSet<TemporalBudgetShift> TemporalBudgetShifts { get; set; }
    public DbSet<WindfallBudgetDivision> WindfallDivisions { get; set; }

    public DbSet<TransactionPredictor> TransactionPredictors { get; set; }
    public DbSet<SplittableTransactionPredictor> SplittableTransactionPredictors { get; set; }
    public DbSet<TransactionBudgetPredictor> TransactionBudgetPredictors { get; set; }
    public DbSet<PartialTransferPredictor> PartialTransferPredictors { get; set; }
    public DbSet<TransferPairPredictor> TransferPairPredictors { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.ApplyColumTypeConventions(
        new EfSqlColumnTypeConvention<decimal>("decimal(9,2)"),
        new EfSqlColumnTypeConvention<DateTime>("date")
      );
    }

  }
}
