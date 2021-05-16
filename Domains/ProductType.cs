using System;
using System.ComponentModel.DataAnnotations;

namespace KPI.SportStuffInternetShop.Domains {
    public class ProductType : BaseEntity<Guid> {
        public string Name { get; set; }
    }
}
