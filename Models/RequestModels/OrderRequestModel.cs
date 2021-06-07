using System;
using Model = KPI.SportStuffInternetShop.Models;

namespace KPI.SportStuffInternetShop.Models.RequestModels {
    public class OrderRequestModel {
        public Guid BasketId { get; set; }

        public Guid DeliveryMethodId { get; set; }

        public Model.Address ShipToAddress { get; set; }
    }
}
