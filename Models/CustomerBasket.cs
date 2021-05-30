using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KPI.SportStuffInternetShop.Models {
    public class CustomerBasket {
        [Required]
        public Guid Id { get; set; }

        public List<CustomerBasketItem> Items { get; set; }
    }
}
