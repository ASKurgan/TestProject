using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestProject.Infrastructure.ReadModels;

namespace TestProject.Infrastructure.Configurations.Read
{
    public class PCReadConfiguration : IEntityTypeConfiguration<PCReadModel>
    {
        public void Configure(EntityTypeBuilder<PCReadModel> builder)
        {
            builder.ToTable("product_category");
            builder.HasKey(pc => pc.Id);

            builder.Property(pc => pc.Name).HasColumnName("name");
            builder.Property(pc => pc.Description).HasColumnName("description");

            builder
              .HasMany(pc => pc.Products)
              .WithOne()
              .HasForeignKey(p => p.ProductCategoryId)
              .IsRequired();
        }
    }
}
