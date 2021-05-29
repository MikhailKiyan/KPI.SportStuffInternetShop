using System;

namespace KPI.SportStuffInternetShop.Domains {
    public class CustomerBasketItem : BaseEntity<Guid> {
        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string PictureUrl { get; set; }

        public string Brand { get; set; }

        public string Type { get; set; }
    }
}