using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monitoring4M1Ev2.Migrations
{
    public partial class reassessment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ForReassessment",
                table: "OperatorQualifications",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ForReassessmentUpdate",
                table: "OperatorQualifications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForReassessment",
                table: "OperatorQualifications");

            migrationBuilder.DropColumn(
                name: "ForReassessmentUpdate",
                table: "OperatorQualifications");
        }
    }
}
