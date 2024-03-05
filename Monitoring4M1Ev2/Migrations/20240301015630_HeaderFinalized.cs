using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monitoring4M1Ev2.Migrations
{
    public partial class HeaderFinalized : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Template_OperationProcesses_MachineId",
                table: "Template");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Template",
                table: "Template");

            migrationBuilder.RenameTable(
                name: "Template",
                newName: "Templates");

            migrationBuilder.RenameIndex(
                name: "IX_Template_MachineId",
                table: "Templates",
                newName: "IX_Templates_MachineId");

            migrationBuilder.AddColumn<bool>(
                name: "Finalized",
                table: "M4EHeaders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FinalizedDate",
                table: "M4EHeaders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Templates",
                table: "Templates",
                column: "TemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Templates_OperationProcesses_MachineId",
                table: "Templates",
                column: "MachineId",
                principalTable: "OperationProcesses",
                principalColumn: "MachineId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Templates_OperationProcesses_MachineId",
                table: "Templates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Templates",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "Finalized",
                table: "M4EHeaders");

            migrationBuilder.DropColumn(
                name: "FinalizedDate",
                table: "M4EHeaders");

            migrationBuilder.RenameTable(
                name: "Templates",
                newName: "Template");

            migrationBuilder.RenameIndex(
                name: "IX_Templates_MachineId",
                table: "Template",
                newName: "IX_Template_MachineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Template",
                table: "Template",
                column: "TemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Template_OperationProcesses_MachineId",
                table: "Template",
                column: "MachineId",
                principalTable: "OperationProcesses",
                principalColumn: "MachineId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
