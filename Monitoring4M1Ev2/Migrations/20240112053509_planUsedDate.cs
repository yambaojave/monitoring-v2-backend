using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monitoring4M1Ev2.Migrations
{
    public partial class planUsedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUsed",
                table: "PlanHeaders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UsedDate",
                table: "PlanHeaders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUsed",
                table: "PlanHeaders");

            migrationBuilder.DropColumn(
                name: "UsedDate",
                table: "PlanHeaders");
        }
    }
}
