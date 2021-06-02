using System;
using System.Collections.Generic;

namespace KPI.SportStuffInternetShop.Domains.Orders {
    public class Order : BaseEntity<Guid> {
        public string BuyerEmail { get; set; }

        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;

        public OrderAddress ShipAddress { get; set; }

        public DeliveryMethod DeliveryMethod { get; set; }

        public IReadOnlyList<OrderItem> OrderItems { get; set; }

        public decimal Subtotal { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public string PaymentIntentId { get; set; }

        public decimal GetTotal() {
            return this.Subtotal + this.DeliveryMethod.Price;
        }
    }
}
