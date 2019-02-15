using LabTest.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LabTest.Repository.Configurations
{
    public class PatientEntityTypeConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("tblPatients");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                            .IsRequired()
                            .HasColumnName("Id")
                            .HasDefaultValueSql("(newsequentialid())")
                            .ValueGeneratedOnAdd();
            builder
                .Property(patient => patient.FirstName)
                .IsRequired();

            builder
                .Property(patient => patient.LastName)
                .IsRequired();

            builder
                .Property(patient => patient.BloodGroup)
                .IsRequired();
        }
    }
}
