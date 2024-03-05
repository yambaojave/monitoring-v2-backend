using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monitoring4M1Ev2.Migrations
{
    public partial class InitialDbCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lines",
                columns: table => new
                {
                    LineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LineName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lines", x => x.LineId);
                });

            migrationBuilder.CreateTable(
                name: "M4EHeaders",
                columns: table => new
                {
                    HeaderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WorkGroupId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    Line = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    OperatorCount = table.Column<int>(nullable: false),
                    OperationCount = table.Column<int>(nullable: false),
                    ShiftCode = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    PlanId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M4EHeaders", x => x.HeaderId);
                });

            migrationBuilder.CreateTable(
                name: "OperatorDetails",
                columns: table => new
                {
                    OperatorDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OperatorEmployeeId = table.Column<string>(maxLength: 50, nullable: true),
                    OperatorName = table.Column<string>(maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateUpdate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatorDetails", x => x.OperatorDetailId);
                });

            migrationBuilder.CreateTable(
                name: "PlanHeaders",
                columns: table => new
                {
                    PlanHeaderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Model = table.Column<string>(nullable: true),
                    Shift = table.Column<int>(nullable: false),
                    Line = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    IsUsed = table.Column<bool>(nullable: false),
                    UsedDate = table.Column<DateTime>(nullable: false),
                    PlanDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanHeaders", x => x.PlanHeaderId);
                });

            migrationBuilder.CreateTable(
                name: "ProductionModels",
                columns: table => new
                {
                    PModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModelName = table.Column<string>(maxLength: 50, nullable: false),
                    ModelDescription = table.Column<string>(maxLength: 50, nullable: false),
                    ModelHeadCount = table.Column<int>(nullable: true),
                    OutputPerHour = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionModels", x => x.PModelId);
                });

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    UserDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OperatorEmployeeId = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.UserDetailId);
                });

            migrationBuilder.CreateTable(
                name: "Environments",
                columns: table => new
                {
                    EnvironmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Temperature = table.Column<decimal>(type: "decimal(4,1)", nullable: false),
                    Lighting = table.Column<string>(maxLength: 5, nullable: true),
                    Remark = table.Column<string>(maxLength: 255, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    HeaderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Environments", x => x.EnvironmentId);
                    table.ForeignKey(
                        name: "FK_Environments_M4EHeaders_HeaderId",
                        column: x => x.HeaderId,
                        principalTable: "M4EHeaders",
                        principalColumn: "HeaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "M4EHeaderRemarks",
                columns: table => new
                {
                    HeaderRemarkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ManRemark = table.Column<string>(maxLength: 255, nullable: true),
                    ManRemarkTimeUpdate = table.Column<TimeSpan>(nullable: false),
                    MachineRemark = table.Column<string>(maxLength: 255, nullable: true),
                    MachineRemarkUpdate = table.Column<TimeSpan>(nullable: false),
                    MethodRemark = table.Column<string>(maxLength: 255, nullable: true),
                    MethodRemarkUpdate = table.Column<TimeSpan>(nullable: false),
                    MaterialRemark = table.Column<string>(maxLength: 255, nullable: true),
                    MaterialRemarkUpdate = table.Column<TimeSpan>(nullable: false),
                    EnvironmentRemark = table.Column<string>(maxLength: 255, nullable: true),
                    EnvironmentRemarkUpdate = table.Column<TimeSpan>(nullable: false),
                    HeaderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M4EHeaderRemarks", x => x.HeaderRemarkId);
                    table.ForeignKey(
                        name: "FK_M4EHeaderRemarks_M4EHeaders_HeaderId",
                        column: x => x.HeaderId,
                        principalTable: "M4EHeaders",
                        principalColumn: "HeaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    MachineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MachineName = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    HeaderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.MachineId);
                    table.ForeignKey(
                        name: "FK_Machines_M4EHeaders_HeaderId",
                        column: x => x.HeaderId,
                        principalTable: "M4EHeaders",
                        principalColumn: "HeaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mans",
                columns: table => new
                {
                    ManId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    OperatorReplacementId = table.Column<string>(nullable: true),
                    OperatorReplacementName = table.Column<string>(nullable: true),
                    ReplacementTimeChange = table.Column<TimeSpan>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    HeaderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mans", x => x.ManId);
                    table.ForeignKey(
                        name: "FK_Mans_M4EHeaders_HeaderId",
                        column: x => x.HeaderId,
                        principalTable: "M4EHeaders",
                        principalColumn: "HeaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    MaterialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Component = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    Type = table.Column<string>(maxLength: 10, nullable: true),
                    Status = table.Column<string>(maxLength: 5, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    HeaderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.MaterialId);
                    table.ForeignKey(
                        name: "FK_Materials_M4EHeaders_HeaderId",
                        column: x => x.HeaderId,
                        principalTable: "M4EHeaders",
                        principalColumn: "HeaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Methods",
                columns: table => new
                {
                    MethodId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ControlNumber = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<string>(maxLength: 5, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    HeaderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Methods", x => x.MethodId);
                    table.ForeignKey(
                        name: "FK_Methods_M4EHeaders_HeaderId",
                        column: x => x.HeaderId,
                        principalTable: "M4EHeaders",
                        principalColumn: "HeaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Outputs",
                columns: table => new
                {
                    OutputId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TimeRange = table.Column<string>(nullable: true),
                    Actual = table.Column<int>(nullable: false),
                    Difference = table.Column<int>(nullable: false),
                    HeaderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outputs", x => x.OutputId);
                    table.ForeignKey(
                        name: "FK_Outputs_M4EHeaders_HeaderId",
                        column: x => x.HeaderId,
                        principalTable: "M4EHeaders",
                        principalColumn: "HeaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanDetails",
                columns: table => new
                {
                    PlanDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Operator = table.Column<string>(nullable: true),
                    Process = table.Column<string>(nullable: true),
                    ControlNumber = table.Column<string>(nullable: true),
                    Machines = table.Column<string>(nullable: true),
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
                name: "OperatorQualifications",
                columns: table => new
                {
                    QualificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OperatorDetailId = table.Column<int>(nullable: false),
                    Model = table.Column<string>(maxLength: 50, nullable: true),
                    Process = table.Column<string>(maxLength: 50, nullable: true),
                    Trainer = table.Column<string>(maxLength: 50, nullable: true),
                    OverallAssessment = table.Column<bool>(nullable: false),
                    OverallAssessmentUpdate = table.Column<DateTime>(nullable: false),
                    ForReassessment = table.Column<bool>(nullable: false),
                    ForReassessmentUpdate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatorQualifications", x => x.QualificationId);
                    table.ForeignKey(
                        name: "FK_OperatorQualifications_UserDetails_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UserDetails",
                        principalColumn: "UserDetailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperatorQualifications_OperatorDetails_OperatorDetailId",
                        column: x => x.OperatorDetailId,
                        principalTable: "OperatorDetails",
                        principalColumn: "OperatorDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLines",
                columns: table => new
                {
                    UserLineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Line = table.Column<string>(nullable: true),
                    UserDetailId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLines", x => x.UserLineId);
                    table.ForeignKey(
                        name: "FK_UserLines_UserDetails_UserDetailId",
                        column: x => x.UserDetailId,
                        principalTable: "UserDetails",
                        principalColumn: "UserDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MachineSystemRemarks",
                columns: table => new
                {
                    MachineSystemRemarkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SystemRemark = table.Column<string>(maxLength: 255, nullable: true),
                    TimeAdded = table.Column<TimeSpan>(nullable: false),
                    MachineId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineSystemRemarks", x => x.MachineSystemRemarkId);
                    table.ForeignKey(
                        name: "FK_MachineSystemRemarks_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManRemarks",
                columns: table => new
                {
                    ManRemarkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Remark = table.Column<string>(maxLength: 255, nullable: true),
                    TimeAdded = table.Column<TimeSpan>(nullable: false),
                    ManId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManRemarks", x => x.ManRemarkId);
                    table.ForeignKey(
                        name: "FK_ManRemarks_Mans_ManId",
                        column: x => x.ManId,
                        principalTable: "Mans",
                        principalColumn: "ManId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManSystemRemarks",
                columns: table => new
                {
                    ManSystemRemarkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SystemRemark = table.Column<string>(maxLength: 255, nullable: true),
                    TimeAdded = table.Column<TimeSpan>(nullable: false),
                    ManId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManSystemRemarks", x => x.ManSystemRemarkId);
                    table.ForeignKey(
                        name: "FK_ManSystemRemarks_Mans_ManId",
                        column: x => x.ManId,
                        principalTable: "Mans",
                        principalColumn: "ManId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainees",
                columns: table => new
                {
                    TraineeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    ManId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainees", x => x.TraineeId);
                    table.ForeignKey(
                        name: "FK_Trainees_Mans_ManId",
                        column: x => x.ManId,
                        principalTable: "Mans",
                        principalColumn: "ManId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialRemarks",
                columns: table => new
                {
                    MaterialRemarkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Remark = table.Column<string>(maxLength: 255, nullable: true),
                    TimeAdded = table.Column<TimeSpan>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialRemarks", x => x.MaterialRemarkId);
                    table.ForeignKey(
                        name: "FK_MaterialRemarks_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialSystemRemarks",
                columns: table => new
                {
                    MaterialSystemRemarkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SystemRemark = table.Column<string>(maxLength: 255, nullable: true),
                    TimeAdded = table.Column<TimeSpan>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialSystemRemarks", x => x.MaterialSystemRemarkId);
                    table.ForeignKey(
                        name: "FK_MaterialSystemRemarks_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MethodRemarks",
                columns: table => new
                {
                    MethodRemarkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Remark = table.Column<string>(maxLength: 255, nullable: true),
                    TimeAdded = table.Column<TimeSpan>(nullable: false),
                    MethodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MethodRemarks", x => x.MethodRemarkId);
                    table.ForeignKey(
                        name: "FK_MethodRemarks_Methods_MethodId",
                        column: x => x.MethodId,
                        principalTable: "Methods",
                        principalColumn: "MethodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MethodSystemRemarks",
                columns: table => new
                {
                    MethodSystemRemarkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SystemRemark = table.Column<string>(maxLength: 255, nullable: true),
                    TimeAdded = table.Column<TimeSpan>(nullable: false),
                    MethodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MethodSystemRemarks", x => x.MethodSystemRemarkId);
                    table.ForeignKey(
                        name: "FK_MethodSystemRemarks_Methods_MethodId",
                        column: x => x.MethodId,
                        principalTable: "Methods",
                        principalColumn: "MethodId",
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
                    IsActive = table.Column<bool>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "OperatorEvaluations",
                columns: table => new
                {
                    EvaluationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CheckName = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Pc1 = table.Column<bool>(nullable: false),
                    Pc2 = table.Column<bool>(nullable: false),
                    Pc3 = table.Column<bool>(nullable: false),
                    Pc4 = table.Column<bool>(nullable: false),
                    Pc5 = table.Column<bool>(nullable: false),
                    Pc6 = table.Column<bool>(nullable: false),
                    Pc7 = table.Column<bool>(nullable: false),
                    Pc8 = table.Column<bool>(nullable: false),
                    Pc9 = table.Column<bool>(nullable: false),
                    Pc10 = table.Column<bool>(nullable: false),
                    Pc11 = table.Column<bool>(nullable: false),
                    Pc12 = table.Column<bool>(nullable: false),
                    Pc13 = table.Column<bool>(nullable: false),
                    Pc14 = table.Column<bool>(nullable: false),
                    Pc15 = table.Column<bool>(nullable: false),
                    Pc16 = table.Column<bool>(nullable: false),
                    Pc17 = table.Column<bool>(nullable: false),
                    Pc18 = table.Column<bool>(nullable: false),
                    Pc19 = table.Column<bool>(nullable: false),
                    Pc20 = table.Column<bool>(nullable: false),
                    Pc21 = table.Column<bool>(nullable: false),
                    Pc22 = table.Column<bool>(nullable: false),
                    Pc23 = table.Column<bool>(nullable: false),
                    Pc24 = table.Column<bool>(nullable: false),
                    Pc25 = table.Column<bool>(nullable: false),
                    Pc26 = table.Column<bool>(nullable: false),
                    Pc27 = table.Column<bool>(nullable: false),
                    Pc28 = table.Column<bool>(nullable: false),
                    Pc29 = table.Column<bool>(nullable: false),
                    Pc30 = table.Column<bool>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    QualificationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatorEvaluations", x => x.EvaluationId);
                    table.ForeignKey(
                        name: "FK_OperatorEvaluations_OperatorQualifications_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "OperatorQualifications",
                        principalColumn: "QualificationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperatorSafetyAnswers",
                columns: table => new
                {
                    AnswerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Answer = table.Column<string>(maxLength: 1000, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    QualificationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatorSafetyAnswers", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_OperatorSafetyAnswers_OperatorQualifications_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "OperatorQualifications",
                        principalColumn: "QualificationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperatorEvaluationPcs",
                columns: table => new
                {
                    PcsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PcsNo = table.Column<string>(nullable: true),
                    Result = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    EvaluationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatorEvaluationPcs", x => x.PcsId);
                    table.ForeignKey(
                        name: "FK_OperatorEvaluationPcs_OperatorEvaluations_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "OperatorEvaluations",
                        principalColumn: "EvaluationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Environments_HeaderId",
                table: "Environments",
                column: "HeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_M4EHeaderRemarks_HeaderId",
                table: "M4EHeaderRemarks",
                column: "HeaderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Machines_HeaderId",
                table: "Machines",
                column: "HeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineSystemRemarks_MachineId",
                table: "MachineSystemRemarks",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_ManRemarks_ManId",
                table: "ManRemarks",
                column: "ManId");

            migrationBuilder.CreateIndex(
                name: "IX_Mans_HeaderId",
                table: "Mans",
                column: "HeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_ManSystemRemarks_ManId",
                table: "ManSystemRemarks",
                column: "ManId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialRemarks_MaterialId",
                table: "MaterialRemarks",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_HeaderId",
                table: "Materials",
                column: "HeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialSystemRemarks_MaterialId",
                table: "MaterialSystemRemarks",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MethodRemarks_MethodId",
                table: "MethodRemarks",
                column: "MethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Methods_HeaderId",
                table: "Methods",
                column: "HeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_MethodSystemRemarks_MethodId",
                table: "MethodSystemRemarks",
                column: "MethodId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationProcesses_WIId",
                table: "OperationProcesses",
                column: "WIId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatorEvaluationPcs_EvaluationId",
                table: "OperatorEvaluationPcs",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatorEvaluations_QualificationId",
                table: "OperatorEvaluations",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatorQualifications_CreatedBy",
                table: "OperatorQualifications",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_OperatorQualifications_OperatorDetailId",
                table: "OperatorQualifications",
                column: "OperatorDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatorSafetyAnswers_QualificationId",
                table: "OperatorSafetyAnswers",
                column: "QualificationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Outputs_HeaderId",
                table: "Outputs",
                column: "HeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanDetails_PlanHeaderId",
                table: "PlanDetails",
                column: "PlanHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_ManId",
                table: "Trainees",
                column: "ManId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLines_UserDetailId",
                table: "UserLines",
                column: "UserDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_WIMatrices_PModelId",
                table: "WIMatrices",
                column: "PModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Environments");

            migrationBuilder.DropTable(
                name: "Lines");

            migrationBuilder.DropTable(
                name: "M4EHeaderRemarks");

            migrationBuilder.DropTable(
                name: "MachineSystemRemarks");

            migrationBuilder.DropTable(
                name: "ManRemarks");

            migrationBuilder.DropTable(
                name: "ManSystemRemarks");

            migrationBuilder.DropTable(
                name: "MaterialRemarks");

            migrationBuilder.DropTable(
                name: "MaterialSystemRemarks");

            migrationBuilder.DropTable(
                name: "MethodRemarks");

            migrationBuilder.DropTable(
                name: "MethodSystemRemarks");

            migrationBuilder.DropTable(
                name: "OperationProcesses");

            migrationBuilder.DropTable(
                name: "OperatorEvaluationPcs");

            migrationBuilder.DropTable(
                name: "OperatorSafetyAnswers");

            migrationBuilder.DropTable(
                name: "Outputs");

            migrationBuilder.DropTable(
                name: "PlanDetails");

            migrationBuilder.DropTable(
                name: "Trainees");

            migrationBuilder.DropTable(
                name: "UserLines");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Methods");

            migrationBuilder.DropTable(
                name: "WIMatrices");

            migrationBuilder.DropTable(
                name: "OperatorEvaluations");

            migrationBuilder.DropTable(
                name: "PlanHeaders");

            migrationBuilder.DropTable(
                name: "Mans");

            migrationBuilder.DropTable(
                name: "ProductionModels");

            migrationBuilder.DropTable(
                name: "OperatorQualifications");

            migrationBuilder.DropTable(
                name: "M4EHeaders");

            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.DropTable(
                name: "OperatorDetails");
        }
    }
}
