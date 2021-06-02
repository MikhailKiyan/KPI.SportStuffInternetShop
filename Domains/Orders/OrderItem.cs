using System;

namespace KPI.SportStuffInternetShop.Domains.Orders {
    public class OrderItem : BaseEntity<Guid> {
        public ProductItemOrdered ItemOrdered { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
