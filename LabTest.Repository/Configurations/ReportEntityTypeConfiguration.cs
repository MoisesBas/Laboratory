using LabTest.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LabTest.Repository.Configurations
{
    public class ReportEntityTypeConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder
                .ToTable("tblReports");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                            .IsRequired()
                            .HasColumnName("Id")
                            .HasDefaultValueSql("(newsequentialid())")
                            .ValueGeneratedOnAdd();
            builder
                .HasOne(report => report.Patient)
                .WithMany(patient => patient.Reports)
                .HasForeignKey(report => report.PatientId);

            builder
                .HasOne(report => report.Test)
                .WithMany();
        }
    }
}
