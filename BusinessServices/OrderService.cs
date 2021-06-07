using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using KPI.SportStuffInternetShop.Contracts.Services;
using KPI.SportStuffInternetShop.Data.Specifications;
using KPI.SportStuffInternetShop.Domains.Orders;

using Domain = KPI.SportStuffInternetShop.Domains;
using Model = KPI.SportStuffInternetShop.Models;
using RequestModel = KPI.SportStuffInternetShop.Models.RequestModels;
using ResponseModel = KPI.SportStuffInternetShop.Models.ResponseModels;

namespace KPI.SportStuffInternetShop.BusinessServices {
    public class OrderService : IOrderService {
        private readonly IUnitOfWork unitOfWork;
        private readonly IBasketRepository basketRepository;
        private readonly IMapper mapper;

        public OrderService(
                IUnitOfWork unitOfWork,
                IBasketRepository basketRepository,
                IMapper mapper) {
            this.unitOfWork = unitOfWork;
            this.basketRepository = basketRepository;
            this.mapper = mapper;
        }

        private async Task<Domain.Orders.Order> CreateOrderAsync(
                string buyerEmail,
                Guid deliveryMethodId,
                Guid basketId,
                Model.Address shippingAddress,
                CancellationToken ct = default) {

            var basket = await this.basketRepository.GetBasketAsync(basketId);
            var items = new List<Domain.Orders.OrderItem>();
            foreach (var item in basket.Items) {
                var productItem = await this.unitOfWork.Repository<Domain.Product, Guid>().FineByKeyAsync(item.Id);
                var itemOrder = new Domain.Orders.ProductItemOrdered {
                    Id = productItem.Id,
                    PictureUrl = productItem.PictureUrl,
                    ProductName = productItem.Name
                };
                var orderItem = new Domain.Orders.OrderItem {
                    ItemOrdered = itemOrder,
                    Price = productItem.Price,
                    Quantity = item.Quantity
                };
                items.Add(orderItem);
            }
            var deliveryMethod = await this.unitOfWork.Repository<Domain.Orders.DeliveryMethod, Guid>()
                .FineByKeyAsync(deliveryMethodId);
            var subtotal = items.Sum(item => item.Price * item.Quantity);
            var order = new Domain.Orders.Order {
                OrderItems = items,
                DeliveryMethod = deliveryMethod,
                BuyerEmail = buyerEmail,
                ShipAddress = this.mapper.Map<Domain.Orders.OrderAddress>(shippingAddress),
                Subtotal = subtotal
            };
            this.unitOfWork.Repository<Domain.Orders.Order, Guid>().Add(order);
            if (await this.unitOfWork.CompleteAsync(ct) <= 0) return null;
            await this.basketRepository.DeleteBasketAsync(basketId);
            return order;
        }

        public async Task<ResponseModel.Order> CreateOrderAsync(
                RequestModel.OrderRequestModel model,
                string userEmail,
                CancellationToken ct = default) {
            var orderFromDb = await this.CreateOrderAsync(userEmail, model.DeliveryMethodId, model.BasketId,
                model.ShipToAddress, ct);
            return this.mapper.Map<ResponseModel.Order>(orderFromDb);
        }

        public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethods(CancellationToken ct = default) {
            return this.unitOfWork.Repository<DeliveryMethod, Guid>()
                .GetAllEntitiesAsync(ct);
        }

        public async Task<ResponseModel.Order> GetOrderByIdAsync(
                Guid id,
                string buyerEmail,
                CancellationToken ct = default) {
            var specification = new OrdersWithItemsAndOrderingSpecification(id, buyerEmail);
            var orderFromDb = await this.unitOfWork.Repository<Order, Guid>()
                .GetEntityWithSpecificationAsync(specification, ct);
            return this.mapper.Map<ResponseModel.Order>(orderFromDb);
        }

        public async Task<IReadOnlyList<ResponseModel.Order>> GetOrdersForUserAsync(
                string buyerEmail,
                CancellationToken ct = default) {
            var specification = new OrdersWithItemsAndOrderingSpecification(buyerEmail);
            var ordersFromDb = await this.unitOfWork.Repository<Order, Guid>()
                .GetEntitiesWithSpecificationAsync(specification, ct);
            return this.mapper.Map<IReadOnlyList<Domain.Orders.Order>, IReadOnlyList<ResponseModel.Order>>(ordersFromDb);
        }
    }
}
