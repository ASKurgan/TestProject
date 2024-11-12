using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Infrastructure.ReadModels;

namespace TestProject.Infrastructure.Configurations.Read
{
    public class ProductReadConfiguration : IEntityTypeConfiguration<ProductReadModel>
    {
        public void Configure(EntityTypeBuilder<ProductReadModel> builder)
        {
            builder.ToTable("product");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).HasColumnName("name");
            builder.Property(p => p.Description).HasColumnName("description");
            builder.Property(p => p.ExpirationDate).HasColumnName("expiration_date");
            builder.Property(p => p.Price).HasColumnName("price");
            builder.Property(p => p.Amount).HasColumnName("amount");
            builder.Property(p => p.DateCreate).HasColumnName("date_create");


            builder.HasOne<PCReadModel>()
              .WithMany(pc => pc.Products)
              .HasForeignKey(p => p.ProductCategoryId)
              .IsRequired();
        }
    }
}
