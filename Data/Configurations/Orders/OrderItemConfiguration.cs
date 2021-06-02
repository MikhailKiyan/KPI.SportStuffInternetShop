using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain = KPI.SportStuffInternetShop.Domains.Orders;

namespace KPI.SportStuffInternetShop.Data.Configurations.Orders {
    public class OrderItemConfiguration : IEntityTypeConfiguration<Domain.OrderItem> {
        public void Configure(EntityTypeBuilder<Domain.OrderItem> builder) {
            builder.OwnsOne(i => i.ItemOrdered, io => io.WithOwner());

            builder.Property(i => i.Price)
                   .HasColumnType("decimal(18,2)");
        }
    }
}
