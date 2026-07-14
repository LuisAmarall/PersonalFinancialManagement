using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalFinancialManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTableNameOfTransferToUSer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transfers",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "ToReceive");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "ToPay");

            migrationBuilder.RenameTable(
                name: "Transfers",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Transfers");

            migrationBuilder.AddColumn<Guid>(
                name: "TransactionId",
                table: "ToReceive",
                type: "UNIQUEIDENTIFIER",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TransactionId",
                table: "ToPay",
                type: "UNIQUEIDENTIFIER",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transfers",
                table: "Transfers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToPayId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    ToReceiveId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    UserId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Amount = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    Details = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    Installments = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    Modality = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    TransactionDate = table.Column<DateTime>(name: "Transaction Date", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                });
        }
    }
}
