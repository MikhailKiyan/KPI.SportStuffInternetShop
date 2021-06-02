using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain = KPI.SportStuffInternetShop.Domains.Orders;

namespace KPI.SportStuffInternetShop.Data.Configurations.Orders {
    public class DeliveryMethodConfiguration : IEntityTypeConfiguration<Domain.DeliveryMethod> {
        public void Configure(EntityTypeBuilder<Domain.DeliveryMethod> builder) {
            builder.Property(d => d.Price)
                   .HasColumnType("decimal(18,2)");
        }
    }
}
