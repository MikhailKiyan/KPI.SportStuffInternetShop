using System;

namespace KPI.SportStuffInternetShop.Domains.Orders {
    public class ProductItemOrdered : BaseEntity<Guid> {
        public string ProductName { get; set; }

        public string PictureUrl { get; set; }
    }
}
