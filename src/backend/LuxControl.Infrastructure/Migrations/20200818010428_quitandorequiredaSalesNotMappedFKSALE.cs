using Microsoft.EntityFrameworkCore.Migrations;

namespace LuxControl.Infrastructure.Migrations
{
    public partial class quitandorequiredaSalesNotMappedFKSALE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Item");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Item",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
