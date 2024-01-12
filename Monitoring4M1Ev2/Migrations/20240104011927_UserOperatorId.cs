using Microsoft.EntityFrameworkCore.Migrations;

namespace Monitoring4M1Ev2.Migrations
{
    public partial class UserOperatorId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OperatorEmployeeId",
                table: "UserDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OperatorEmployeeId",
                table: "UserDetails");
        }
    }
}
