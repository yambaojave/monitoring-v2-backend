﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Monitoring4M1Ev2.Context;
using Monitoring4M1Ev2.Interfaces;
using Monitoring4M1Ev2.Services;

namespace Monitoring4M1Ev2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Monitoring")));
            services.AddDbContext<BarcodeDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("Barcode")));
            services.AddDbContext<ContractorDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("Contractor")));
            services.AddDbContext<JsphDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("JSPH")));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOperatorService, OperatorService>();
            services.AddScoped<IBarcodeService, BarcodeService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IM4EService, M4EService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(m => m
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseMvc();
        }
    }
}


//$env:ASPNETCORE_ENVIRONMENT='Development'  -> in order to update the selected environment make sure to change .env builder environment
//add-migration -> add new migration 
//update-datebase -> update database base on migration
// Due to many context be specific on what context to update
// add-migration InitialDbCreation -context ApplicationDbContext
// update-database -context ApplicationDbContext