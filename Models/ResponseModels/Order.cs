using System;
using System.Collections.Generic;

namespace KPI.SportStuffInternetShop.Models.ResponseModels {
    public class Order {
        public Guid Id { get; set; }

        public string BuyerEmail { get; set; }

        public DateTimeOffset OrderDate { get; set; }

        public Address ShipAddress { get; set; }

        public string DeliveryMethod { get; set; }

        public decimal ShippingPrice { get; set; }

        public IReadOnlyList<OrderItem> OrderItems { get; set; }

        public decimal Subtotal { get; set; }

        public decimal Total { get; set; }

        public string Status { get; set; }
    }
}
