using KPI.SportStuffInternetShop.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KPI.SportStuffInternetShop.Data.Configurations {
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType> {
        public void Configure(EntityTypeBuilder<ProductType> builder) {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(126);
        }
    }
}
