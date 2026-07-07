using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalFinancialManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Category",
                newName: "Created At");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Created At",
                table: "Category",
                newName: "CreatedAt");
        }
    }
}
