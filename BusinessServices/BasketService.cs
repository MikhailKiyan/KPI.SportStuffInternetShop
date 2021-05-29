using System;
using System.Threading.Tasks;
using KPI.SportStuffInternetShop.Contracts.Services;
using Domain = KPI.SportStuffInternetShop.Domains;

namespace KPI.SportStuffInternetShop.BusinessServices {
    public class BasketService : IBasketService {
        private readonly IBasketRepository basketRepository;

        public BasketService(IBasketRepository basketRepository) {
            this.basketRepository = basketRepository;
        }

        public Task<Domain.CustomerBasket> CreateBasketAsync(Domain.CustomerBasket customerBasket) {
            return this.basketRepository.CreateOrUpdateBasketAsync(customerBasket);
        }

        public Task DeleteBasketAsync(Guid id) {
            return this.basketRepository.DeleteBasketAsync(id);
        }

        public async Task<Domain.CustomerBasket> GetBasketsById(Guid id) {
            var basket = await this.basketRepository.GetBasketAsync(id);
            return basket ?? new Domain.CustomerBasket(id);
        }

        public Task<Domain.CustomerBasket> UpdateBasketAsync(Domain.CustomerBasket customerBasket) {
            return this.basketRepository.CreateOrUpdateBasketAsync(customerBasket);
        }
    }
}
