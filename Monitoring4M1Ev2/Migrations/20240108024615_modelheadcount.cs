using Microsoft.EntityFrameworkCore.Migrations;

namespace Monitoring4M1Ev2.Migrations
{
    public partial class modelheadcount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModelHeadCount",
                table: "ProductionModels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModelHeadCount",
                table: "ProductionModels");
        }
    }
}
