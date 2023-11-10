using Microsoft.EntityFrameworkCore;
using Monitoring4M1Ev2.Model.Operator;
using Monitoring4M1Ev2.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // User Dataset
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<UserLine> UserLines { get; set; }

        //Operator Dataset
        public DbSet<OperatorDetail> OperatorDetails { get; set; }
        public DbSet<OperatorEvaluation> OperatorEvaluations { get; set; }
        public DbSet<OperatorQualification> OperatorQualifications { get; set; }
        public DbSet<OperatorSafetyAnswer> OperatorSafetyAnswers { get; set; }



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<UserLine>()
        //        .HasOne(d => d.UserDetail)
        //        .WithMany(a => a.UserLines)
        //        .HasForeignKey(d => d.UserDetailId);
        //}
    }
}
