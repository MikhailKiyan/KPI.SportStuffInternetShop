using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using KPI.SportStuffInternetShop.Domains.Orders;
using KPI.SportStuffInternetShop.Models.RequestModels;

namespace KPI.SportStuffInternetShop.Contracts.Services {
    public interface IOrderService {
        Task<Order> CreateOrderAsync(
            string buyerEmail,
            Guid deliveryMethodId,
            Guid basketId,
            OrderAddress shippingAddress);

        Task<IReadOnlyList<Order>> GetOrdersForUserAsync(
            string buyerEmail);

        Task<Order> GetOrderByIdAsync(
            Guid id,
            string buyerEmail);

        Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethods();

        Task<Domains.Orders.Order> CreateOrderAsync(
            OrderRequestModel model,
            string userEmail,
            CancellationToken ct = default);
    }
}
