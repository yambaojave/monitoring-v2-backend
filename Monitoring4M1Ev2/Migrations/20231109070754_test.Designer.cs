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
    [Migration("20231109070754_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Monitoring4M1Ev2.Model.User.UserDetail", b =>
                {
                    b.Property<int>("UserDetailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName");

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

            modelBuilder.Entity("Monitoring4M1Ev2.Model.User.UserLine", b =>
                {
                    b.HasOne("Monitoring4M1Ev2.Model.User.UserDetail", "UserDetail")
                        .WithMany("UserLines")
                        .HasForeignKey("UserDetailId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
