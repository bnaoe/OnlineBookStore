using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBookStore.DataAccess.Migrations
{
    public partial class updateCompanyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsAuthorized",
                table: "Companies",
                newName: "IsAuthorizedCompany");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsAuthorizedCompany",
                table: "Companies",
                newName: "IsAuthorized");
        }
    }
}
