using LabTest.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LabTest.Repository.Configurations
{
    public class TestTypeEntityTypeConfiguration : IEntityTypeConfiguration<TestType>
    {
        public void Configure(EntityTypeBuilder<TestType> builder)
        {
            builder.ToTable("tblTestTypes");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                            .IsRequired()
                            .HasColumnName("Id")
                            .HasDefaultValueSql("(newsequentialid())")
                            .ValueGeneratedOnAdd();
            builder
                .Property(type => type.Name)
                .IsRequired();
        }
    }
}
