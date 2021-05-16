using System;
using System.ComponentModel.DataAnnotations;

namespace KPI.SportStuffInternetShop.Domains {
    public class ProductBrand : BaseEntity<Guid> {
        public string Name { get; set; }
    }
}
