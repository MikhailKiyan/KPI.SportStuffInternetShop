using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KPI.SportStuffInternetShop.Domains;

namespace KPI.SportStuffInternetShop.Data.Configurations {
    public class ProductBrandConfiguration : IEntityTypeConfiguration<ProductBrand> {
        public void Configure(EntityTypeBuilder<ProductBrand> builder) {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(126);
        }
    }
}
