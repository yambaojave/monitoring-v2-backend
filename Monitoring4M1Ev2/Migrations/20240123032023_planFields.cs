using Microsoft.EntityFrameworkCore.Migrations;

namespace Monitoring4M1Ev2.Migrations
{
    public partial class planFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ControlNumber",
                table: "PlanDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Machines",
                table: "PlanDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ControlNumber",
                table: "PlanDetails");

            migrationBuilder.DropColumn(
                name: "Machines",
                table: "PlanDetails");
        }
    }
}
