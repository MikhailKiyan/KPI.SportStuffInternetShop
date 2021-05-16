using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KPI.SportStuffInternetShop.Domains;
/*
namespace KPI.SportStuffInternetShop.Data.Configurations {
    public class ProductConfiguration : IEntityTypeConfiguration<Product> {
        public void Configure(EntityTypeBuilder<Product> builder) {
            builder.ToTable(nameof(Product))
                   .HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .HasDefaultValueSql("NEWID()");

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(126);

            builder.Property(p => p.Description)
                   .IsRequired()
                   .HasMaxLength(1024);

            builder.Property(p => p.Price)
                   .HasColumnType("decimal(18,2)");

            builder.Property(p => p.PictureUrl)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.HasOne(p => p.ProductBrand)
                   .WithMany()
                   .HasForeignKey(p => p.ProductBrandId);

            builder.HasOne(p => p.ProductType)
                   .WithMany()
                   .HasForeignKey(p => p.ProductTypeId);
        }
    }
}
*/