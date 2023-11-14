﻿using Microsoft.EntityFrameworkCore;
using Monitoring4M1Ev2.Model.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Context
{
    public class JsphDbContext : DbContext
    {
        public JsphDbContext(DbContextOptions<JsphDbContext> options) : base(options) { }

        public DbSet<Employee> employee { get; set; }
    }
}
