using System;

using Domain = KPI.SportStuffInternetShop.Domains;

namespace KPI.SportStuffInternetShop.Data.Specifications {
    public class OrdersWithItemsAndOrderingSpecification : BaseSpecifcation<Domain.Orders.Order>{
        public OrdersWithItemsAndOrderingSpecification(string email) : base(o => o.BuyerEmail == email) {
            this.AddInclude(o => o.OrderItems);
            this.AddInclude(o => o.DeliveryMethod);
            this.AddOrderByDescending(o => o.OrderDate);

        }

        public OrdersWithItemsAndOrderingSpecification(Guid id, string email)
                : base(o => o.Id == id && o.BuyerEmail == email) {
            this.AddInclude(o => o.OrderItems);
            this.AddInclude(o => o.DeliveryMethod);
        }
    }
}
