using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalFinancialManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DecimalFixInTheMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    Observation = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToPay",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    CategoryId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    TransactionId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    OriginalValue = table.Column<decimal>(name: "Original Value", type: "DECIMAL(18,2)", nullable: false),
                    AmountPaid = table.Column<decimal>(name: "Amount Paid", type: "DECIMAL(18,2)", nullable: false),
                    DueDate = table.Column<DateTime>(name: "Due Date", type: "datetime2", nullable: false),
                    ReferenceDate = table.Column<DateTime>(name: "Reference Date", type: "datetime2", nullable: false),
                    PaymentDate = table.Column<DateTime>(name: "Payment Date", type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToPay", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToReceive",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    CategoryId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    TransactionId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    Observation = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    OriginalValue = table.Column<decimal>(name: "Original Value", type: "DECIMAL(18,2)", nullable: false),
                    AmountReceived = table.Column<decimal>(name: "Amount Received", type: "DECIMAL(18,2)", nullable: false),
                    DueDate = table.Column<DateTime>(name: "Due Date", type: "datetime2", nullable: false),
                    ReferenceDate = table.Column<DateTime>(name: "Reference Date", type: "datetime2", nullable: false),
                    DateReceipt = table.Column<DateTime>(name: "Date Receipt", type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(name: "Created At", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToReceive", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    ToPayId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    ToReceiveId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Amount = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Modality = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Details = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    Installments = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    TransactionDate = table.Column<DateTime>(name: "Transaction Date", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "ToPay");

            migrationBuilder.DropTable(
                name: "ToReceive");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Transfers");
        }
    }
}
