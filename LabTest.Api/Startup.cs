using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using LabTest.Api.Helper;
using LabTest.Domain;
using LabTest.Model.Core;
using LabTest.Model.Validator;
using LabTest.Repository;
using LabTest.Repository.Helper;
using LabTest.Service.Core;
using LabTest.Service.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace LabTest.Api
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
            services.AddAutoMapper();
            services
            .AddScoped(typeof(IRepository<,>), typeof(Repository<,>))
            .AddScoped(typeof(IService<,,,,>), typeof(Service<,,,,>));
            services.AddSingleton(Configuration);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
               .AddJsonOptions(o =>
               {
                   o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                   o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
               }).AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<PatientModelValidator>());
            services.ConfigureSwaggerGen();
            services.LabTestCors();
           services
                .AddDbContext<LabTestDbContext>(options =>
                    options.UseSqlServer(this.Configuration.GetConnectionString("Default")))
                .AddIdentity<LabTestUser, IdentityRole<Guid>>(option => option.Lockout.MaxFailedAccessAttempts = 5)
                .AddEntityFrameworkStores<LabTestDbContext>();
           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowAll");
            app.UseMiddleware<JsonExceptionMiddleware>();
            app.ConfigureSwaggerUi();
            app.UseDefaultFiles();
            app.UseStaticFiles();   
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                if (!serviceScope.ServiceProvider.GetService<LabTestDbContext>().AllMigrationsApplied())
                {
                    serviceScope.ServiceProvider.GetService<LabTestDbContext>().Database.Migrate();
                }

            }
            app.UseMvcWithDefaultRoute();
        }
    }
}
