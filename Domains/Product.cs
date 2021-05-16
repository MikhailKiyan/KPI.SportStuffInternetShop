using System;

namespace KPI.SportStuffInternetShop.Domains {

    public class Product : BaseEntity<Guid> {
        public string Name { get; set; }
    }
}
