using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain = KPI.SportStuffInternetShop.Domains.Orders;

namespace KPI.SportStuffInternetShop.Data.Configurations.Orders {
    public class OrderConfiguration : IEntityTypeConfiguration<Domain.Order> {
        public void Configure(EntityTypeBuilder<Domain.Order> builder) {
            builder.OwnsOne(o => o.ShipAddress, a => a.WithOwner());

            builder.Property(s => s.Status)
                   .HasConversion(
                        o => o.ToString(),
                        o => (Domain.OrderStatus) Enum.Parse(typeof(Domain.OrderStatus), o));

            builder.HasMany(o => o.OrderItems)
                   .WithOne()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(o => o.Subtotal)
                   .HasColumnType("decimal(18,2)");
        }
    }
}
