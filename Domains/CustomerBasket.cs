using System;
using System.Collections.Generic;

namespace KPI.SportStuffInternetShop.Domains {
    public class CustomerBasket : BaseEntity<Guid> {
        public CustomerBasket() : this(Guid.NewGuid()) { }

        public CustomerBasket(Guid id) {
            this.Id = id;
            this.Items = new List<CustomerBasketItem>();
        }

        public Guid? DeliveryMethodId { get; set; }

        public string ClientSecret { get; set; }

        public string PaymentIntentId { get; set; }

        public List<CustomerBasketItem> Items { get; set; }
    }
}
