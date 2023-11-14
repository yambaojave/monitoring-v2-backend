using Microsoft.EntityFrameworkCore;
using Monitoring4M1Ev2.Model.Barcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Context
{
    public class BarcodeDbContext : DbContext
    {
        public BarcodeDbContext(DbContextOptions<BarcodeDbContext> options) : base(options) { }
        public DbSet<B2MACHINE> B2MACHINE { get; set; }
        public DbSet<B2BOM> B2BOM { get; set; }
        public DbSet<B2WORKGROUP> B2WORKGROUP { get; set; }
        public DbSet<B2WORKGROUPDETAIL> B2WORKGROUPDETAIL { get; set; }
    }
}
