using LabTest.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LabTest.Repository.Configurations
{
    public class PathologyTestEntityTypeConfiguration : IEntityTypeConfiguration<PathologyTest>
    {
        public void Configure(EntityTypeBuilder<PathologyTest> builder)
        {
            builder.ToTable("tblPathologyTests");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                            .IsRequired()
                            .HasColumnName("Id")
                            .HasDefaultValueSql("(newsequentialid())")
                            .ValueGeneratedOnAdd();
            builder
                .Property(test => test.Name)
                .IsRequired();

            builder
                .HasOne(test => test.Type)
                .WithMany(type => type.Tests)
                .HasForeignKey(test => test.TestTypeId);
        }
    }
}
