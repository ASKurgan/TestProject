using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Domain.Base;
using TestProject.Domain.Entities;

namespace TestProject.Infrastructure.Configurations.Write
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
              .IsRequired()
              .HasMaxLength(Constraints.MEDIUM_TITLE_LENGTH);

            builder.Property(p => p.Description)
               .IsRequired()
               .HasMaxLength(Constraints.LONG_TITLE_LENGTH);

            builder.Property(p => p.Price)
                .IsRequired();

            builder.Property(p => p.Amount)
                .IsRequired();

            builder.Property(p => p.DateCreate)
                .IsRequired();

            builder.Property(p => p.ExpirationDate)
               .IsRequired();
        }
    }
}
