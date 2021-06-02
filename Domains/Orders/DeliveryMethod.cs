using System;

namespace KPI.SportStuffInternetShop.Domains.Orders {
    public class DeliveryMethod : BaseEntity<Guid> {
        public string ShortName { get; set; }

        public string DeliveryTime { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
