using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monitoring4M1Ev2.Migrations
{
    public partial class matrix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductionModels",
                columns: table => new
                {
                    PModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModelName = table.Column<string>(nullable: true),
                    ModelDescription = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionModels", x => x.PModelId);
                });

            migrationBuilder.CreateTable(
                name: "WIMatrices",
                columns: table => new
                {
                    WIId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessNumber = table.Column<string>(nullable: true),
                    ControlNumber = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    PModelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WIMatrices", x => x.WIId);
                    table.ForeignKey(
                        name: "FK_WIMatrices_ProductionModels_PModelId",
                        column: x => x.PModelId,
                        principalTable: "ProductionModels",
                        principalColumn: "PModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationProcesses",
                columns: table => new
                {
                    MachineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OperationName = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    IsAcive = table.Column<bool>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    WIId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationProcesses", x => x.MachineId);
                    table.ForeignKey(
                        name: "FK_OperationProcesses_WIMatrices_WIId",
                        column: x => x.WIId,
                        principalTable: "WIMatrices",
                        principalColumn: "WIId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OperationProcesses_WIId",
                table: "OperationProcesses",
                column: "WIId");

            migrationBuilder.CreateIndex(
                name: "IX_WIMatrices_PModelId",
                table: "WIMatrices",
                column: "PModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperationProcesses");

            migrationBuilder.DropTable(
                name: "WIMatrices");

            migrationBuilder.DropTable(
                name: "ProductionModels");
        }
    }
}
