using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalFinancialManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
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
                    CreatedAt = table.Column<byte[]>(type: "TIMESTAMP", nullable: false),
                    DeletedAt = table.Column<byte[]>(type: "TIMESTAMP", nullable: true)
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
                    OriginalValue = table.Column<decimal>(name: "Original Value", type: "DECIMAL(0,0)", nullable: false),
                    AmountPaid = table.Column<decimal>(name: "Amount Paid", type: "DECIMAL(0,0)", nullable: false),
                    DueDate = table.Column<byte[]>(name: "Due Date", type: "TIMESTAMP", nullable: false),
                    ReferenceDate = table.Column<byte[]>(name: "Reference Date", type: "TIMESTAMP", nullable: false),
                    PaymentDate = table.Column<byte[]>(name: "Payment Date", type: "TIMESTAMP", nullable: false),
                    CreatedAt = table.Column<byte[]>(name: "Created At", type: "TIMESTAMP", nullable: false)
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
                    OriginalValue = table.Column<decimal>(name: "Original Value", type: "DECIMAL(0,0)", nullable: false),
                    AmountReceived = table.Column<decimal>(name: "Amount Received", type: "DECIMAL(0,0)", nullable: false),
                    DueDate = table.Column<byte[]>(name: "Due Date", type: "TIMESTAMP", nullable: false),
                    ReferenceDate = table.Column<byte[]>(name: "Reference Date", type: "TIMESTAMP", nullable: false),
                    DateReceipt = table.Column<byte[]>(name: "Date Receipt", type: "TIMESTAMP", nullable: false),
                    CreatedAt = table.Column<byte[]>(name: "Created At", type: "TIMESTAMP", nullable: false)
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
                    Amount = table.Column<decimal>(type: "DECIMAL(0,0)", nullable: false),
                    Modality = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Details = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    Installments = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    TransactionDate = table.Column<byte[]>(name: "Transaction Date", type: "TIMESTAMP", nullable: false)
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
                    CreatedAt = table.Column<byte[]>(type: "TIMESTAMP", nullable: false),
                    DeletedAt = table.Column<byte[]>(type: "TIMESTAMP", nullable: true)
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
