﻿// <auto-generated />
using System;
using Budgetting.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Budgetting.Migrations
{
    [DbContext(typeof(BudgettingDbContext))]
    partial class BudgettingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Budgetting.DbModels.BankAccounts.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Budgetting.DbModels.BankAccounts.AccountTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountId");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(9,2)");

                    b.Property<DateTime>("DateOfImport")
                        .HasColumnType("date");

                    b.Property<DateTime>("DateOfTransaction")
                        .HasColumnType("date");

                    b.Property<string>("Description");

                    b.Property<string>("ImportHash");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("AccountTransactions");
                });

            modelBuilder.Entity("Budgetting.DbModels.BankAccounts.RefundTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("OriginalTransactionId");

                    b.Property<int?>("RefundingTransactionId");

                    b.HasKey("Id");

                    b.HasIndex("OriginalTransactionId");

                    b.HasIndex("RefundingTransactionId");

                    b.ToTable("RefundTransaction");
                });

            modelBuilder.Entity("Budgetting.DbModels.BankAccounts.TransferTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("InboundTransactionId");

                    b.Property<int?>("OutboundTransactionId");

                    b.HasKey("Id");

                    b.HasIndex("InboundTransactionId");

                    b.HasIndex("OutboundTransactionId");

                    b.ToTable("TransferTransaction");
                });

            modelBuilder.Entity("Budgetting.DbModels.BudgetAllowances.DiscretionaryBudgetTransfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(9,2)");

                    b.Property<int?>("DestinationBudgetId");

                    b.Property<int?>("MonthId");

                    b.Property<string>("Notes");

                    b.Property<int?>("OriginBudgetId");

                    b.HasKey("Id");

                    b.HasIndex("DestinationBudgetId");

                    b.HasIndex("MonthId");

                    b.HasIndex("OriginBudgetId");

                    b.ToTable("BudgetTransfers");
                });

            modelBuilder.Entity("Budgetting.DbModels.BudgetAllowances.TemporalBudgetShift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(9,2)");

                    b.Property<int?>("AssignedBudgetId");

                    b.Property<int?>("InitialMonthId");

                    b.Property<int>("PaybackLength");

                    b.HasKey("Id");

                    b.HasIndex("AssignedBudgetId");

                    b.HasIndex("InitialMonthId");

                    b.ToTable("TemporalBudgetShifts");
                });

            modelBuilder.Entity("Budgetting.DbModels.BudgetAllowances.WindfallBudgetDivision", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(9,2)");

                    b.Property<int?>("AssignedBudgetId");

                    b.Property<int?>("WindfallTransactionId");

                    b.HasKey("Id");

                    b.HasIndex("AssignedBudgetId");

                    b.HasIndex("WindfallTransactionId");

                    b.ToTable("WindfallDivisions");
                });

            modelBuilder.Entity("Budgetting.DbModels.Budgets.Budget", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("HasCategories");

                    b.Property<bool>("IsIncome");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Budgets");
                });

            modelBuilder.Entity("Budgetting.DbModels.Budgets.BudgetCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BudgetId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.ToTable("BudgetCategories");
                });

            modelBuilder.Entity("Budgetting.DbModels.Budgets.BudgetMonth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Month");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.ToTable("BudgetMonths");
                });

            modelBuilder.Entity("Budgetting.DbModels.Budgets.BudgetTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(9,2)");

                    b.Property<int?>("BudgetId");

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<bool>("IsExpectingRefund");

                    b.Property<int?>("MonthId");

                    b.Property<string>("Notes");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("MonthId");

                    b.ToTable("BudgetTransactions");
                });

            modelBuilder.Entity("Budgetting.DbModels.Predictors.TransactionPredictor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountId");

                    b.Property<decimal>("Confidence")
                        .HasColumnType("decimal(9,2)");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<bool?>("PatternIsRegex");

                    b.Property<string>("TransactionPattern");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("TransactionPredictors");

                    b.HasDiscriminator<string>("Discriminator").HasValue("TransactionPredictor");
                });

            modelBuilder.Entity("Budgetting.DbModels.Predictors.TransferPairPredictor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("InboundTransferId");

                    b.Property<int?>("OutboundTransferId");

                    b.HasKey("Id");

                    b.HasIndex("InboundTransferId");

                    b.HasIndex("OutboundTransferId");

                    b.ToTable("TransferPairPredictors");
                });

            modelBuilder.Entity("Budgetting.DbModels.Predictors.PartialTransferPredictor", b =>
                {
                    b.HasBaseType("Budgetting.DbModels.Predictors.TransactionPredictor");

                    b.Property<int?>("PredictedDestinationAccountId");

                    b.HasIndex("PredictedDestinationAccountId");

                    b.ToTable("PartialTransferPredictor");

                    b.HasDiscriminator().HasValue("PartialTransferPredictor");
                });

            modelBuilder.Entity("Budgetting.DbModels.Predictors.SplittableTransactionPredictor", b =>
                {
                    b.HasBaseType("Budgetting.DbModels.Predictors.TransactionPredictor");


                    b.ToTable("SplittableTransactionPredictor");

                    b.HasDiscriminator().HasValue("SplittableTransactionPredictor");
                });

            modelBuilder.Entity("Budgetting.DbModels.Predictors.TransactionBudgetPredictor", b =>
                {
                    b.HasBaseType("Budgetting.DbModels.Predictors.TransactionPredictor");

                    b.Property<int?>("PredictedBudgetCategoryId");

                    b.Property<int?>("PredictedBudgetId");

                    b.Property<string>("PredictedDescription");

                    b.HasIndex("PredictedBudgetCategoryId");

                    b.HasIndex("PredictedBudgetId");

                    b.ToTable("TransactionBudgetPredictor");

                    b.HasDiscriminator().HasValue("TransactionBudgetPredictor");
                });

            modelBuilder.Entity("Budgetting.DbModels.BankAccounts.AccountTransaction", b =>
                {
                    b.HasOne("Budgetting.DbModels.BankAccounts.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");
                });

            modelBuilder.Entity("Budgetting.DbModels.BankAccounts.RefundTransaction", b =>
                {
                    b.HasOne("Budgetting.DbModels.BankAccounts.AccountTransaction", "OriginalTransaction")
                        .WithMany()
                        .HasForeignKey("OriginalTransactionId");

                    b.HasOne("Budgetting.DbModels.BankAccounts.AccountTransaction", "RefundingTransaction")
                        .WithMany()
                        .HasForeignKey("RefundingTransactionId");
                });

            modelBuilder.Entity("Budgetting.DbModels.BankAccounts.TransferTransaction", b =>
                {
                    b.HasOne("Budgetting.DbModels.BankAccounts.AccountTransaction", "InboundTransaction")
                        .WithMany()
                        .HasForeignKey("InboundTransactionId");

                    b.HasOne("Budgetting.DbModels.BankAccounts.AccountTransaction", "OutboundTransaction")
                        .WithMany()
                        .HasForeignKey("OutboundTransactionId");
                });

            modelBuilder.Entity("Budgetting.DbModels.BudgetAllowances.DiscretionaryBudgetTransfer", b =>
                {
                    b.HasOne("Budgetting.DbModels.Budgets.Budget", "DestinationBudget")
                        .WithMany()
                        .HasForeignKey("DestinationBudgetId");

                    b.HasOne("Budgetting.DbModels.Budgets.BudgetMonth", "Month")
                        .WithMany()
                        .HasForeignKey("MonthId");

                    b.HasOne("Budgetting.DbModels.Budgets.Budget", "OriginBudget")
                        .WithMany()
                        .HasForeignKey("OriginBudgetId");
                });

            modelBuilder.Entity("Budgetting.DbModels.BudgetAllowances.TemporalBudgetShift", b =>
                {
                    b.HasOne("Budgetting.DbModels.Budgets.Budget", "AssignedBudget")
                        .WithMany()
                        .HasForeignKey("AssignedBudgetId");

                    b.HasOne("Budgetting.DbModels.Budgets.BudgetMonth", "InitialMonth")
                        .WithMany()
                        .HasForeignKey("InitialMonthId");
                });

            modelBuilder.Entity("Budgetting.DbModels.BudgetAllowances.WindfallBudgetDivision", b =>
                {
                    b.HasOne("Budgetting.DbModels.Budgets.Budget", "AssignedBudget")
                        .WithMany()
                        .HasForeignKey("AssignedBudgetId");

                    b.HasOne("Budgetting.DbModels.Budgets.BudgetTransaction", "WindfallTransaction")
                        .WithMany()
                        .HasForeignKey("WindfallTransactionId");
                });

            modelBuilder.Entity("Budgetting.DbModels.Budgets.BudgetCategory", b =>
                {
                    b.HasOne("Budgetting.DbModels.Budgets.Budget", "Budget")
                        .WithMany("Categories")
                        .HasForeignKey("BudgetId");
                });

            modelBuilder.Entity("Budgetting.DbModels.Budgets.BudgetTransaction", b =>
                {
                    b.HasOne("Budgetting.DbModels.Budgets.Budget", "Budget")
                        .WithMany()
                        .HasForeignKey("BudgetId");

                    b.HasOne("Budgetting.DbModels.Budgets.BudgetCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("Budgetting.DbModels.Budgets.BudgetMonth", "Month")
                        .WithMany()
                        .HasForeignKey("MonthId");
                });

            modelBuilder.Entity("Budgetting.DbModels.Predictors.TransactionPredictor", b =>
                {
                    b.HasOne("Budgetting.DbModels.BankAccounts.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");
                });

            modelBuilder.Entity("Budgetting.DbModels.Predictors.TransferPairPredictor", b =>
                {
                    b.HasOne("Budgetting.DbModels.Predictors.TransactionPredictor", "InboundTransfer")
                        .WithMany()
                        .HasForeignKey("InboundTransferId");

                    b.HasOne("Budgetting.DbModels.Predictors.TransactionPredictor", "OutboundTransfer")
                        .WithMany()
                        .HasForeignKey("OutboundTransferId");
                });

            modelBuilder.Entity("Budgetting.DbModels.Predictors.PartialTransferPredictor", b =>
                {
                    b.HasOne("Budgetting.DbModels.BankAccounts.Account", "PredictedDestinationAccount")
                        .WithMany()
                        .HasForeignKey("PredictedDestinationAccountId");
                });

            modelBuilder.Entity("Budgetting.DbModels.Predictors.TransactionBudgetPredictor", b =>
                {
                    b.HasOne("Budgetting.DbModels.Budgets.BudgetCategory", "PredictedBudgetCategory")
                        .WithMany()
                        .HasForeignKey("PredictedBudgetCategoryId");

                    b.HasOne("Budgetting.DbModels.Budgets.Budget", "PredictedBudget")
                        .WithMany()
                        .HasForeignKey("PredictedBudgetId");
                });
#pragma warning restore 612, 618
        }
    }
}