using LabTest.Domain;
using LabTest.Domain.Core;
using LabTest.Repository.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LabTest.Repository
{
   public class LabTestDbContext: IdentityDbContext<LabTestUser, IdentityRole<Guid>,Guid>
    {
        public virtual DbSet<Patient> Patients { get; set; }

        public virtual DbSet<PathologyTest> PathologyTests { get; set; }

        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<TestType> TestTypes { get; set; }

        public LabTestDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new PathologyTestEntityTypeConfiguration());
            builder.ApplyConfiguration(new PatientEntityTypeConfiguration());
            builder.ApplyConfiguration(new ReportEntityTypeConfiguration());
            builder.ApplyConfiguration(new TestTypeEntityTypeConfiguration());
        }
    }
}
