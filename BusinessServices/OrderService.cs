using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using KPI.SportStuffInternetShop.Contracts.Services;
using Domain = KPI.SportStuffInternetShop.Domains;
using KPI.SportStuffInternetShop.Models;
using KPI.SportStuffInternetShop.Models.RequestModels;
using KPI.SportStuffInternetShop.Services.Contracts;

namespace KPI.SportStuffInternetShop.BusinessServices {
    public class OrderService : IOrderService {
        private readonly IGenericRepository<Domain.Orders.Order, Guid> orderRepository;
        private readonly IGenericRepository<Domain.Orders.DeliveryMethod, Guid> deliveryMethodRepository;
        private readonly IGenericRepository<Domain.Product, Guid> productRepository;
        private readonly IBasketRepository basketRepository;
        private readonly IMapper mapper;

        public OrderService(
                IGenericRepository<Domain.Orders.Order, Guid> orderRepository,
                IGenericRepository<Domain.Orders.DeliveryMethod, Guid> deliveryMethodRepository,
                IGenericRepository<Domain.Product, Guid> productRepository,
                IBasketRepository basketRepository,
                IMapper mapper) {

            this.orderRepository = orderRepository;
            this.deliveryMethodRepository = deliveryMethodRepository;
            this.productRepository = productRepository;
            this.basketRepository = basketRepository;
            this.mapper = mapper;
        }

        public async Task<Domain.Orders.Order> CreateOrderAsync(
                string buyerEmail,
                Guid deliveryMethodId,
                Guid basketId,
                Domain.Orders.OrderAddress shippingAddress) {

            var basket = await this.basketRepository.GetBasketAsync(basketId);
            var items = new List<Domain.Orders.OrderItem>();
            foreach (var item in basket.Items) {
                var productItem = await this.productRepository.FineByKeyAsync(item.Id);
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
            var deliveryMethod = await this.deliveryMethodRepository.FineByKeyAsync(deliveryMethodId);
            var subtotal = items.Sum(item => item.Price * item.Quantity);
            var order = new Domain.Orders.Order {
                OrderItems = items,
                DeliveryMethod = deliveryMethod,
                BuyerEmail = buyerEmail,
                ShipAddress = shippingAddress,
                Subtotal = subtotal
            };
            // TODO: Save the order to Database
            return order;
        }

        public async Task<Domain.Orders.Order> CreateOrderAsync(
                OrderRequestModel model,
                string userEmail,
                CancellationToken ct = default) {

            var address = this.mapper.Map<Domain.Orders.OrderAddress>(model.ShipToAddress);
            // TODO: Change to Response model
            var orderFromDb = await this.CreateOrderAsync(userEmail, model.DeliveryMethodId, model.BasketId, address);
            return orderFromDb;
        }

        public Task<IReadOnlyList<Domain.Orders.DeliveryMethod>> GetDeliveryMethods() {
            throw new NotImplementedException();
        }

        public Task<Domain.Orders.Order> GetOrderByIdAsync(
                Guid id,
                string buyerEmail) {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Domain.Orders.Order>> GetOrdersForUserAsync(string buyerEmail) {
            throw new NotImplementedException();
        }
    }
}
