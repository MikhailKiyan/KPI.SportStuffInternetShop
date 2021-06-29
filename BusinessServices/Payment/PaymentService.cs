using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Stripe;
using KPI.SportStuffInternetShop.Contracts.Services;
using KPI.SportStuffInternetShop.Domains;
using KPI.SportStuffInternetShop.Domains.Orders;
using Domain = KPI.SportStuffInternetShop.Domains;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace KPI.SportStuffInternetShop.BusinessServices.Payment {
    public class PaymentService : IPaymentService {
        private readonly IBasketRepository basketRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration configuration;

        public PaymentService(
                IBasketRepository basketRepository,
                IUnitOfWork unitOfWork,
                IConfiguration configuration) {
            this.basketRepository = basketRepository;
            this.unitOfWork = unitOfWork;
            this.configuration = configuration;
        }

        public async Task<CustomerBasket> CreateOrUpdatePaymentIntentAsync(
                Guid basketId,
                CancellationToken ct) {
            StripeConfiguration.ApiKey = this.configuration["StripeSettings:SecretKey"];
            var basket = await this.basketRepository.GetBasketAsync(basketId);
            ct.ThrowIfCancellationRequested();
            var shippingPrice = 0m;
            if (basket.DeliveryMethodId.HasValue) {
                var deliveryMethod = await this.unitOfWork.Repository<DeliveryMethod, Guid>()
                    .FineByKeyAsync(basket.DeliveryMethodId.Value);
                ct.ThrowIfCancellationRequested();
                shippingPrice = deliveryMethod.Price;
            }

            foreach (var item in basket.Items) {
                var productItem = await this.unitOfWork.Repository<Domain.Product, Guid>().FineByKeyAsync(item.Id, ct);
                item.Price = productItem.Price;
            }

            var service = new PaymentIntentService();
            PaymentIntent intent;
            if (string.IsNullOrEmpty(basket.PaymentIntentId)) {
                var options = new PaymentIntentCreateOptions {
                    Amount = (long)basket.Items.Sum(x => x.Quantity * x.Price * 100) + (long)shippingPrice * 100,
                    Currency = "usd",
                    PaymentMethodTypes = new List<string> { "card" }
                };
                intent = await service.CreateAsync(options, cancellationToken: ct);
                basket.PaymentIntentId = intent.Id;
                basket.ClientSecret = intent.ClientSecret;
            } else {
                var options = new PaymentIntentUpdateOptions {
                    Amount = (long)basket.Items.Sum(x => x.Quantity * x.Price * 100) + (long)shippingPrice * 100
                };
                await service.UpdateAsync(basket.PaymentIntentId, options, cancellationToken: ct);
            }

            await basketRepository.CreateOrUpdateBasketAsync(basket);
            ct.ThrowIfCancellationRequested();
            return basket;
        }
    }
}
