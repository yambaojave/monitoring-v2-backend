using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monitoring4M1Ev2.Migrations
{
    public partial class Plan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlanHeaders",
                columns: table => new
                {
                    PlanHeaderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Model = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    Line = table.Column<string>(nullable: true),
                    PlanDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanHeaders", x => x.PlanHeaderId);
                });

            migrationBuilder.CreateTable(
                name: "PlanDetails",
                columns: table => new
                {
                    PlanDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Operator = table.Column<string>(nullable: true),
                    Condition = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    PlanHeaderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanDetails", x => x.PlanDetailId);
                    table.ForeignKey(
                        name: "FK_PlanDetails_PlanHeaders_PlanHeaderId",
                        column: x => x.PlanHeaderId,
                        principalTable: "PlanHeaders",
                        principalColumn: "PlanHeaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanDetails_PlanHeaderId",
                table: "PlanDetails",
                column: "PlanHeaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanDetails");

            migrationBuilder.DropTable(
                name: "PlanHeaders");
        }
    }
}
