using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using KPI.SportStuffInternetShop.Domains.Orders;
using Model = KPI.SportStuffInternetShop.Models;
using RequestModel = KPI.SportStuffInternetShop.Models.RequestModels;
using ResponseModel = KPI.SportStuffInternetShop.Models.ResponseModels;

namespace KPI.SportStuffInternetShop.Contracts.Services {
    public interface IOrderService {
        Task<IReadOnlyList<ResponseModel.Order>> GetOrdersForUserAsync(
            string buyerEmail,
            CancellationToken ct = default);

        Task<ResponseModel.Order> GetOrderByIdAsync(
            Guid id,
            string buyerEmail,
            CancellationToken ct = default);

        Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethods(CancellationToken ct = default);

        Task<ResponseModel.Order> CreateOrderAsync(
            RequestModel.OrderRequestModel model,
            string userEmail,
            CancellationToken ct = default);
    }
}
