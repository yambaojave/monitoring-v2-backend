﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Monitoring4M1Ev2.Context;

namespace Monitoring4M1Ev2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240225224150_ManChanges")]
    partial class ManChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.Environment", b =>
                {
                    b.Property<int>("EnvironmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded");

                    b.Property<int>("HeaderId");

                    b.Property<string>("Lighting")
                        .HasMaxLength(5);

                    b.Property<string>("Remark")
                        .HasMaxLength(255);

                    b.Property<decimal>("Temperature")
                        .HasColumnType("decimal(4,1)");

                    b.HasKey("EnvironmentId");

                    b.HasIndex("HeaderId");

                    b.ToTable("Environments");
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.M4EHeader", b =>
                {
                    b.Property<int>("HeaderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Line");

                    b.Property<string>("Model");

                    b.Property<int>("OperationCount");

                    b.Property<int>("OperatorCount");

                    b.Property<int>("PlanId");

                    b.Property<int>("ShiftCode");

                    b.Property<string>("Type");

                    b.Property<int>("WorkGroupId");

                    b.HasKey("HeaderId");

                    b.ToTable("M4EHeaders");
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.M4EHeaderRemark", b =>
                {
                    b.Property<int>("HeaderRemarkId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EnvironmentRemark")
                        .HasMaxLength(255);

                    b.Property<TimeSpan>("EnvironmentRemarkUpdate");

                    b.Property<int>("HeaderId");

                    b.Property<string>("MachineRemark")
                        .HasMaxLength(255);

                    b.Property<TimeSpan>("MachineRemarkUpdate");

                    b.Property<string>("ManRemark")
                        .HasMaxLength(255);

                    b.Property<TimeSpan>("ManRemarkTimeUpdate");

                    b.Property<string>("MaterialRemark")
                        .HasMaxLength(255);

                    b.Property<TimeSpan>("MaterialRemarkUpdate");

                    b.Property<string>("MethodRemark")
                        .HasMaxLength(255);

                    b.Property<TimeSpan>("MethodRemarkUpdate");

                    b.HasKey("HeaderRemarkId");

                    b.HasIndex("HeaderId")
                        .IsUnique();

                    b.ToTable("M4EHeaderRemarks");
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.Machine", b =>
                {
                    b.Property<int>("MachineId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded");

                    b.Property<int>("HeaderId");

                    b.Property<string>("MachineName");

                    b.Property<string>("Status");

                    b.HasKey("MachineId");

                    b.HasIndex("HeaderId");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.MachineSystemRemark", b =>
                {
                    b.Property<int>("MachineSystemRemarkId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MachineId");

                    b.Property<string>("SystemRemark")
                        .HasMaxLength(255);

                    b.Property<TimeSpan>("TimeAdded");

                    b.HasKey("MachineSystemRemarkId");

                    b.HasIndex("MachineId");

                    b.ToTable("MachineSystemRemarks");
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.Man", b =>
                {
                    b.Property<int>("ManId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("EmployeeId");

                    b.Property<int>("HeaderId");

                    b.Property<string>("OperatorReplacementId");

                    b.Property<TimeSpan>("ReplacementTimeChange");

                    b.Property<string>("Status");

                    b.HasKey("ManId");

                    b.HasIndex("HeaderId");

                    b.ToTable("Mans");
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.ManRemark", b =>
                {
                    b.Property<int>("ManRemarkId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ManId");

                    b.Property<string>("Remark")
                        .HasMaxLength(255);

                    b.Property<TimeSpan>("TimeAdded");

                    b.HasKey("ManRemarkId");

                    b.HasIndex("ManId");

                    b.ToTable("ManRemarks");
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.ManSystemRemark", b =>
                {
                    b.Property<int>("ManSystemRemarkId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ManId");

                    b.Property<string>("SystemRemark")
                        .HasMaxLength(255);

                    b.Property<TimeSpan>("TimeAdded");

                    b.HasKey("ManSystemRemarkId");

                    b.HasIndex("ManId");

                    b.ToTable("ManSystemRemarks");
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.Material", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Component")
                        .HasMaxLength(100);

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Description")
                        .HasMaxLength(150);

                    b.Property<int>("HeaderId");

                    b.Property<string>("Status")
                        .HasMaxLength(5);

                    b.Property<string>("Type")
                        .HasMaxLength(10);

                    b.HasKey("MaterialId");

                    b.HasIndex("HeaderId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.MaterialRemark", b =>
                {
                    b.Property<int>("MaterialRemarkId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaterialId");

                    b.Property<string>("Remark")
                        .HasMaxLength(255);

                    b.Property<TimeSpan>("TimeAdded");

                    b.HasKey("MaterialRemarkId");

                    b.HasIndex("MaterialId");

                    b.ToTable("MaterialRemarks");
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.MaterialSystemRemark", b =>
                {
                    b.Property<int>("MaterialSystemRemarkId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaterialId");

                    b.Property<string>("SystemRemark")
                        .HasMaxLength(255);

                    b.Property<TimeSpan>("TimeAdded");

                    b.HasKey("MaterialSystemRemarkId");

                    b.HasIndex("MaterialId");

                    b.ToTable("MaterialSystemRemarks");
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.Method", b =>
                {
                    b.Property<int>("MethodId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ControlNumber")
                        .HasMaxLength(50);

                    b.Property<DateTime>("DateAdded");

                    b.Property<int>("HeaderId");

                    b.Property<string>("Status")
                        .HasMaxLength(5);

                    b.HasKey("MethodId");

                    b.HasIndex("HeaderId");

                    b.ToTable("Methods");
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.MethodRemark", b =>
                {
                    b.Property<int>("MethodRemarkId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MethodId");

                    b.Property<string>("Remark")
                        .HasMaxLength(255);

                    b.Property<TimeSpan>("TimeAdded");

                    b.HasKey("MethodRemarkId");

                    b.HasIndex("MethodId");

                    b.ToTable("MethodRemarks");
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.MethodSystemRemark", b =>
                {
                    b.Property<int>("MethodSystemRemarkId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MethodId");

                    b.Property<string>("SystemRemark")
                        .HasMaxLength(255);

                    b.Property<TimeSpan>("TimeAdded");

                    b.HasKey("MethodSystemRemarkId");

                    b.HasIndex("MethodId");

                    b.ToTable("MethodSystemRemarks");
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.MonitoringResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category");

                    b.Property<DateTime>("DateAdded");

                    b.Property<int>("HeaderId");

                    b.Property<string>("Machine");

                    b.Property<string>("Man");

                    b.Property<string>("Method");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("HeaderId");

                    b.ToTable("MonitoringResults");
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.Output", b =>
                {
                    b.Property<int>("OutputId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Actual");

                    b.Property<int>("Difference");

                    b.Property<int>("HeaderId");

                    b.Property<int>("Plan");

                    b.Property<string>("Remarks");

                    b.Property<string>("TimeRange");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<bool>("Updated");

                    b.Property<int>("UserInput");

                    b.HasKey("OutputId");

                    b.HasIndex("HeaderId");

                    b.ToTable("Outputs");
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.Trainee", b =>
                {
                    b.Property<int>("TraineeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("EmployeeId");

                    b.Property<int>("ManId");

                    b.Property<string>("Name");

                    b.HasKey("TraineeId");

                    b.HasIndex("ManId");

                    b.ToTable("Trainees");
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Matrix.OperationProcess", b =>
                {
                    b.Property<int>("MachineId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<bool>("IsActive");

                    b.Property<string>("OperationName");

                    b.Property<int>("WIId");

                    b.HasKey("MachineId");

                    b.HasIndex("WIId");

                    b.ToTable("OperationProcesses");
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Matrix.ProductionModel", b =>
                {
                    b.Property<int>("PModelId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<bool>("IsActive");

                    b.Property<string>("ModelDescription")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("ModelHeadCount");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("OutputPerHour");

                    b.HasKey("PModelId");

                    b.ToTable("ProductionModels");
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Matrix.WIMatrix", b =>
                {
                    b.Property<int>("WIId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ControlNumber");

                    b.Property<DateTime>("DateAdded");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<bool>("IsActive");

                    b.Property<int>("PModelId");

                    b.Property<string>("ProcessNumber");

                    b.HasKey("WIId");

                    b.HasIndex("PModelId");

                    b.ToTable("WIMatrices");
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Operator.OperatorDetail", b =>
                {
                    b.Property<int>("OperatorDetailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<DateTime>("DateAdded");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<string>("OperatorEmployeeId")
                        .HasMaxLength(50);

                    b.Property<string>("OperatorName")
                        .HasMaxLength(100);

                    b.HasKey("OperatorDetailId");

                    b.ToTable("OperatorDetails");
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Operator.OperatorEvaluation", b =>
                {
                    b.Property<int>("EvaluationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CheckName")
                        .HasMaxLength(100);

                    b.Property<DateTime>("DateAdded");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<bool>("Pc1");

                    b.Property<bool>("Pc10");

                    b.Property<bool>("Pc11");

                    b.Property<bool>("Pc12");

                    b.Property<bool>("Pc13");

                    b.Property<bool>("Pc14");

                    b.Property<bool>("Pc15");

                    b.Property<bool>("Pc16");

                    b.Property<bool>("Pc17");

                    b.Property<bool>("Pc18");

                    b.Property<bool>("Pc19");

                    b.Property<bool>("Pc2");

                    b.Property<bool>("Pc20");

                    b.Property<bool>("Pc21");

                    b.Property<bool>("Pc22");

                    b.Property<bool>("Pc23");

                    b.Property<bool>("Pc24");

                    b.Property<bool>("Pc25");

                    b.Property<bool>("Pc26");

                    b.Property<bool>("Pc27");

                    b.Property<bool>("Pc28");

                    b.Property<bool>("Pc29");

                    b.Property<bool>("Pc3");

                    b.Property<bool>("Pc30");

                    b.Property<bool>("Pc4");

                    b.Property<bool>("Pc5");

                    b.Property<bool>("Pc6");

                    b.Property<bool>("Pc7");

                    b.Property<bool>("Pc8");

                    b.Property<bool>("Pc9");

                    b.Property<int>("QualificationId");

                    b.Property<string>("Remarks");

                    b.HasKey("EvaluationId");

                    b.HasIndex("QualificationId");

                    b.ToTable("OperatorEvaluations");
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Operator.OperatorEvaluationPcs", b =>
                {
                    b.Property<int>("PcsId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded");

                    b.Property<int>("EvaluationId");

                    b.Property<string>("PcsNo");

                    b.Property<string>("Result");

                    b.HasKey("PcsId");

                    b.HasIndex("EvaluationId");

                    b.ToTable("OperatorEvaluationPcs");
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Operator.OperatorQualification", b =>
                {
                    b.Property<int>("QualificationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("DateAdded");

                    b.Property<bool>("ForReassessment");

                    b.Property<DateTime>("ForReassessmentUpdate");

                    b.Property<string>("Model")
                        .HasMaxLength(50);

                    b.Property<int>("OperatorDetailId");

                    b.Property<bool>("OverallAssessment");

                    b.Property<DateTime>("OverallAssessmentUpdate");

                    b.Property<string>("Process")
                        .HasMaxLength(50);

                    b.Property<string>("Trainer")
                        .HasMaxLength(50);

                    b.HasKey("QualificationId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("OperatorDetailId");

                    b.ToTable("OperatorQualifications");
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Operator.OperatorSafetyAnswer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer")
                        .HasMaxLength(1000);

                    b.Property<DateTime>("DateAdded");

                    b.Property<int>("QualificationId");

                    b.HasKey("AnswerId");

                    b.HasIndex("QualificationId")
                        .IsUnique();

                    b.ToTable("OperatorSafetyAnswers");
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Plan.PlanDetail", b =>
                {
                    b.Property<int>("PlanDetailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Condition");

                    b.Property<string>("ControlNumber");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Machines");

                    b.Property<string>("Operator");

                    b.Property<int>("PlanHeaderId");

                    b.Property<string>("Process");

                    b.HasKey("PlanDetailId");

                    b.HasIndex("PlanHeaderId");

                    b.ToTable("PlanDetails");
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Plan.PlanHeader", b =>
                {
                    b.Property<int>("PlanHeaderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsUsed");

                    b.Property<string>("Line");

                    b.Property<string>("Model");

                    b.Property<DateTime>("PlanDate");

                    b.Property<int>("Shift");

                    b.Property<string>("Type");

                    b.Property<DateTime>("UsedDate");

                    b.HasKey("PlanHeaderId");

                    b.ToTable("PlanHeaders");
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.User.Lines", b =>
                {
                    b.Property<int>("LineId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LineName");

                    b.HasKey("LineId");

                    b.ToTable("Lines");
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.User.UserDetail", b =>
                {
                    b.Property<int>("UserDetailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName");

                    b.Property<string>("OperatorEmployeeId");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("Role");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<string>("Username");

                    b.HasKey("UserDetailId");

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.User.UserLine", b =>
                {
                    b.Property<int>("UserLineId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Line");

                    b.Property<int>("UserDetailId");

                    b.HasKey("UserLineId");

                    b.HasIndex("UserDetailId");

                    b.ToTable("UserLines");
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.Environment", b =>
                {
                    b.HasOne("Monitoring4M1Ev2.Model.Framework_4M_1E.M4EHeader")
                        .WithMany("Environments")
                        .HasForeignKey("HeaderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.M4EHeaderRemark", b =>
                {
                    b.HasOne("Monitoring4M1Ev2.Model.Framework_4M_1E.M4EHeader")
                        .WithOne("M4EHeaderRemarks")
                        .HasForeignKey("Monitoring4M1Ev2.Model.Framework_4M_1E.M4EHeaderRemark", "HeaderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.Machine", b =>
                {
                    b.HasOne("Monitoring4M1Ev2.Model.Framework_4M_1E.M4EHeader")
                        .WithMany("Machines")
                        .HasForeignKey("HeaderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.MachineSystemRemark", b =>
                {
                    b.HasOne("Monitoring4M1Ev2.Model.Framework_4M_1E.Machine")
                        .WithMany("MachineSystemRemarks")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.Man", b =>
                {
                    b.HasOne("Monitoring4M1Ev2.Model.Framework_4M_1E.M4EHeader")
                        .WithMany("Mans")
                        .HasForeignKey("HeaderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.ManRemark", b =>
                {
                    b.HasOne("Monitoring4M1Ev2.Model.Framework_4M_1E.Man")
                        .WithMany("ManRemarks")
                        .HasForeignKey("ManId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.ManSystemRemark", b =>
                {
                    b.HasOne("Monitoring4M1Ev2.Model.Framework_4M_1E.Man")
                        .WithMany("ManSystemRemarks")
                        .HasForeignKey("ManId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.Material", b =>
                {
                    b.HasOne("Monitoring4M1Ev2.Model.Framework_4M_1E.M4EHeader")
                        .WithMany("Materials")
                        .HasForeignKey("HeaderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.MaterialRemark", b =>
                {
                    b.HasOne("Monitoring4M1Ev2.Model.Framework_4M_1E.Material")
                        .WithMany("MaterialRemarks")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.MaterialSystemRemark", b =>
                {
                    b.HasOne("Monitoring4M1Ev2.Model.Framework_4M_1E.Material")
                        .WithMany("MaterialSystemRemarks")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.Method", b =>
                {
                    b.HasOne("Monitoring4M1Ev2.Model.Framework_4M_1E.M4EHeader")
                        .WithMany("Methods")
                        .HasForeignKey("HeaderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.MethodRemark", b =>
                {
                    b.HasOne("Monitoring4M1Ev2.Model.Framework_4M_1E.Method")
                        .WithMany("MethodRemarks")
                        .HasForeignKey("MethodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.MethodSystemRemark", b =>
                {
                    b.HasOne("Monitoring4M1Ev2.Model.Framework_4M_1E.Method")
                        .WithMany("MethodSystemRemarks")
                        .HasForeignKey("MethodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.MonitoringResult", b =>
                {
                    b.HasOne("Monitoring4M1Ev2.Model.Framework_4M_1E.M4EHeader")
                        .WithMany("MonitoringResults")
                        .HasForeignKey("HeaderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.Output", b =>
                {
                    b.HasOne("Monitoring4M1Ev2.Model.Framework_4M_1E.M4EHeader")
                        .WithMany("Outputs")
                        .HasForeignKey("HeaderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Framework_4M_1E.Trainee", b =>
                {
                    b.HasOne("Monitoring4M1Ev2.Model.Framework_4M_1E.Man")
                        .WithMany("Trainees")
                        .HasForeignKey("ManId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Matrix.OperationProcess", b =>
                {
                    b.HasOne("Monitoring4M1Ev2.Model.Matrix.WIMatrix", "WIMatrix")
                        .WithMany("OperationProcesses")
                        .HasForeignKey("WIId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Matrix.WIMatrix", b =>
                {
                    b.HasOne("Monitoring4M1Ev2.Model.Matrix.ProductionModel", "ProductionModel")
                        .WithMany("WIMatrices")
                        .HasForeignKey("PModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Operator.OperatorEvaluation", b =>
                {
                    b.HasOne("Monitoring4M1Ev2.Model.Operator.OperatorQualification")
                        .WithMany("OperatorEvaluations")
                        .HasForeignKey("QualificationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Operator.OperatorEvaluationPcs", b =>
                {
                    b.HasOne("Monitoring4M1Ev2.Model.Operator.OperatorEvaluation")
                        .WithMany("OperatorQualificationPcs")
                        .HasForeignKey("EvaluationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Operator.OperatorQualification", b =>
                {
                    b.HasOne("Monitoring4M1Ev2.Model.User.UserDetail", "InChargeDetails")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Monitoring4M1Ev2.Model.Operator.OperatorDetail", "OperatorDetail")
                        .WithMany("OperatorQualifications")
                        .HasForeignKey("OperatorDetailId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Operator.OperatorSafetyAnswer", b =>
                {
                    b.HasOne("Monitoring4M1Ev2.Model.Operator.OperatorQualification")
                        .WithOne("OperatorSafetyAnswers")
                        .HasForeignKey("Monitoring4M1Ev2.Model.Operator.OperatorSafetyAnswer", "QualificationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.Plan.PlanDetail", b =>
                {
                    b.HasOne("Monitoring4M1Ev2.Model.Plan.PlanHeader", "PlanHeader")
                        .WithMany("PlanDetails")
                        .HasForeignKey("PlanHeaderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monitoring4M1Ev2.Model.User.UserLine", b =>
                {
                    b.HasOne("Monitoring4M1Ev2.Model.User.UserDetail")
                        .WithMany("UserLines")
                        .HasForeignKey("UserDetailId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
