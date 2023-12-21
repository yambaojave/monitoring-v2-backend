using Microsoft.EntityFrameworkCore;
using Monitoring4M1Ev2.Model.Framework_4M_1E;
using Monitoring4M1Ev2.Model.Matrix;
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

        /*
         *  User Dataset
         */
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<UserLine> UserLines { get; set; }

        /*
         *  Operator Dataset
         */
        public DbSet<OperatorDetail> OperatorDetails { get; set; }
        public DbSet<OperatorEvaluation> OperatorEvaluations { get; set; }
        public DbSet<OperatorQualification> OperatorQualifications { get; set; }
        public DbSet<OperatorSafetyAnswer> OperatorSafetyAnswers { get; set; }
        public DbSet<OperatorEvaluationPcs> OperatorEvaluationPcs { get; set; }

        /*
         *  4M1E Framework Dataset
         */ 
        public DbSet<Model.Framework_4M_1E.Environment> Environments { get; set; }
        public DbSet<M4EHeader> M4EHeaders { get; set; }
        public DbSet<M4EHeaderRemark> M4EHeaderRemarks { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<MachineSystemRemark> MachineSystemRemarks { get; set; }
        public DbSet<Man> Mans { get; set; }
        public DbSet<ManRemark> ManRemarks { get; set; }
        public DbSet<ManSystemRemark> ManSystemRemarks { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialRemark> MaterialRemarks { get; set; }
        public DbSet<MaterialSystemRemark> MaterialSystemRemarks { get; set; }
        public DbSet<Method> Methods { get; set; }
        public DbSet<MethodRemark> MethodRemarks { get; set; }
        public DbSet<MethodSystemRemark> MethodSystemRemarks { get; set; }
         
        /*
         *  Matrix 
         */
        public DbSet<OperationProcess> OperationProcesses { get; set; }
        public DbSet<ProductionModel> ProductionModels { get; set; }
        public DbSet<WIMatrix> WIMatrices { get; set; }

    }
}
