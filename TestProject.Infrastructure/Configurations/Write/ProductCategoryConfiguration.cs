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
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("product_category");
            builder.HasKey(pc => pc.Id);

            builder.Property(pc => pc.Name)
               .IsRequired()
               .HasMaxLength(Constraints.SHORT_TITLE_LENGTH);

            builder.Property(pc => pc.Description)
               .IsRequired()
               .HasMaxLength(Constraints.MEDIUM_TITLE_LENGTH);

            builder.HasMany(pc => pc.Products).WithOne().IsRequired();
        }
    }
}
