using System;
using System.Collections.Generic;

namespace KPI.SportStuffInternetShop.Domains {
    public class CustomerBasket : BaseEntity<Guid> {
        public CustomerBasket() : this(Guid.NewGuid()) { }

        public CustomerBasket(Guid id) {
            this.Id = id;
            this.Items = new List<CustomerBasketItem>();
        }

        public List<CustomerBasketItem> Items { get; set; }
    }
}
