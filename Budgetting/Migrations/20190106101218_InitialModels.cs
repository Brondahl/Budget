using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Budgetting.Migrations
{
    public partial class InitialModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BudgetMonths",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetMonths", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    HasCategories = table.Column<bool>(nullable: false),
                    IsIncome = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<int>(nullable: true),
                    ImportHash = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    DateOfTransaction = table.Column<DateTime>(type: "date", nullable: false),
                    DateOfImport = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountTransactions_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BudgetCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    BudgetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetCategories_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BudgetTransfers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OriginBudgetId = table.Column<int>(nullable: true),
                    DestinationBudgetId = table.Column<int>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    MonthId = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetTransfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetTransfers_Budgets_DestinationBudgetId",
                        column: x => x.DestinationBudgetId,
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BudgetTransfers_BudgetMonths_MonthId",
                        column: x => x.MonthId,
                        principalTable: "BudgetMonths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BudgetTransfers_Budgets_OriginBudgetId",
                        column: x => x.OriginBudgetId,
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TemporalBudgetShifts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssignedBudgetId = table.Column<int>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    InitialMonthId = table.Column<int>(nullable: true),
                    PaybackLength = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemporalBudgetShifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemporalBudgetShifts_Budgets_AssignedBudgetId",
                        column: x => x.AssignedBudgetId,
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TemporalBudgetShifts_BudgetMonths_InitialMonthId",
                        column: x => x.InitialMonthId,
                        principalTable: "BudgetMonths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RefundTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OriginalTransactionId = table.Column<int>(nullable: true),
                    RefundingTransactionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefundTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefundTransaction_AccountTransactions_OriginalTransactionId",
                        column: x => x.OriginalTransactionId,
                        principalTable: "AccountTransactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RefundTransaction_AccountTransactions_RefundingTransactionId",
                        column: x => x.RefundingTransactionId,
                        principalTable: "AccountTransactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransferTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OutboundTransactionId = table.Column<int>(nullable: true),
                    InboundTransactionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransferTransaction_AccountTransactions_InboundTransactionId",
                        column: x => x.InboundTransactionId,
                        principalTable: "AccountTransactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferTransaction_AccountTransactions_OutboundTransactionId",
                        column: x => x.OutboundTransactionId,
                        principalTable: "AccountTransactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BudgetTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MonthId = table.Column<int>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    BudgetId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    IsExpectingRefund = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetTransactions_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BudgetTransactions_BudgetCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "BudgetCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BudgetTransactions_BudgetMonths_MonthId",
                        column: x => x.MonthId,
                        principalTable: "BudgetMonths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransactionPredictors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<int>(nullable: true),
                    TransactionPattern = table.Column<string>(nullable: true),
                    PatternIsRegex = table.Column<bool>(nullable: true),
                    Confidence = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    PredictedDestinationAccountId = table.Column<int>(nullable: true),
                    PredictedBudgetId = table.Column<int>(nullable: true),
                    PredictedBudgetCategoryId = table.Column<int>(nullable: true),
                    PredictedDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionPredictors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionPredictors_Accounts_PredictedDestinationAccountId",
                        column: x => x.PredictedDestinationAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionPredictors_BudgetCategories_PredictedBudgetCategoryId",
                        column: x => x.PredictedBudgetCategoryId,
                        principalTable: "BudgetCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionPredictors_Budgets_PredictedBudgetId",
                        column: x => x.PredictedBudgetId,
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionPredictors_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WindfallDivisions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WindfallTransactionId = table.Column<int>(nullable: true),
                    AssignedBudgetId = table.Column<int>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(9,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WindfallDivisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WindfallDivisions_Budgets_AssignedBudgetId",
                        column: x => x.AssignedBudgetId,
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WindfallDivisions_BudgetTransactions_WindfallTransactionId",
                        column: x => x.WindfallTransactionId,
                        principalTable: "BudgetTransactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransferPairPredictors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OutboundTransferId = table.Column<int>(nullable: true),
                    InboundTransferId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferPairPredictors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransferPairPredictors_TransactionPredictors_InboundTransferId",
                        column: x => x.InboundTransferId,
                        principalTable: "TransactionPredictors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferPairPredictors_TransactionPredictors_OutboundTransferId",
                        column: x => x.OutboundTransferId,
                        principalTable: "TransactionPredictors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransactions_AccountId",
                table: "AccountTransactions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetCategories_BudgetId",
                table: "BudgetCategories",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetTransactions_BudgetId",
                table: "BudgetTransactions",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetTransactions_CategoryId",
                table: "BudgetTransactions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetTransactions_MonthId",
                table: "BudgetTransactions",
                column: "MonthId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetTransfers_DestinationBudgetId",
                table: "BudgetTransfers",
                column: "DestinationBudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetTransfers_MonthId",
                table: "BudgetTransfers",
                column: "MonthId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetTransfers_OriginBudgetId",
                table: "BudgetTransfers",
                column: "OriginBudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_RefundTransaction_OriginalTransactionId",
                table: "RefundTransaction",
                column: "OriginalTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_RefundTransaction_RefundingTransactionId",
                table: "RefundTransaction",
                column: "RefundingTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_TemporalBudgetShifts_AssignedBudgetId",
                table: "TemporalBudgetShifts",
                column: "AssignedBudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_TemporalBudgetShifts_InitialMonthId",
                table: "TemporalBudgetShifts",
                column: "InitialMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionPredictors_PredictedDestinationAccountId",
                table: "TransactionPredictors",
                column: "PredictedDestinationAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionPredictors_PredictedBudgetCategoryId",
                table: "TransactionPredictors",
                column: "PredictedBudgetCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionPredictors_PredictedBudgetId",
                table: "TransactionPredictors",
                column: "PredictedBudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionPredictors_AccountId",
                table: "TransactionPredictors",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferPairPredictors_InboundTransferId",
                table: "TransferPairPredictors",
                column: "InboundTransferId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferPairPredictors_OutboundTransferId",
                table: "TransferPairPredictors",
                column: "OutboundTransferId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferTransaction_InboundTransactionId",
                table: "TransferTransaction",
                column: "InboundTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferTransaction_OutboundTransactionId",
                table: "TransferTransaction",
                column: "OutboundTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_WindfallDivisions_AssignedBudgetId",
                table: "WindfallDivisions",
                column: "AssignedBudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_WindfallDivisions_WindfallTransactionId",
                table: "WindfallDivisions",
                column: "WindfallTransactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgetTransfers");

            migrationBuilder.DropTable(
                name: "RefundTransaction");

            migrationBuilder.DropTable(
                name: "TemporalBudgetShifts");

            migrationBuilder.DropTable(
                name: "TransferPairPredictors");

            migrationBuilder.DropTable(
                name: "TransferTransaction");

            migrationBuilder.DropTable(
                name: "WindfallDivisions");

            migrationBuilder.DropTable(
                name: "TransactionPredictors");

            migrationBuilder.DropTable(
                name: "AccountTransactions");

            migrationBuilder.DropTable(
                name: "BudgetTransactions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "BudgetCategories");

            migrationBuilder.DropTable(
                name: "BudgetMonths");

            migrationBuilder.DropTable(
                name: "Budgets");
        }
    }
}
