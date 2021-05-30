using System;
using System.Threading.Tasks;
using AutoMapper;
using KPI.SportStuffInternetShop.Contracts.Services;
using Domain = KPI.SportStuffInternetShop.Domains;
using Model = KPI.SportStuffInternetShop.Models;

namespace KPI.SportStuffInternetShop.BusinessServices {
    public class BasketService : IBasketService {
        private readonly IBasketRepository basketRepository;
        private readonly IMapper mapper;

        public BasketService(IBasketRepository basketRepository, IMapper mapper) {
            this.basketRepository = basketRepository;
            this.mapper = mapper;
        }

        public async Task<Model.CustomerBasket> CreateBasketAsync(Model.CustomerBasket customerBasket) {
            var customerBasketEntity = this.mapper.Map<Domain.CustomerBasket>(customerBasket);
            var createdCustomerBasketEntity = await this.basketRepository.CreateOrUpdateBasketAsync(customerBasketEntity);
            return this.mapper.Map<Model.CustomerBasket>(createdCustomerBasketEntity);
        }

        public Task DeleteBasketAsync(Guid id) {
            return this.basketRepository.DeleteBasketAsync(id);
        }

        public async Task<Model.CustomerBasket> GetBasketsById(Guid id) {
            var basket = await this.basketRepository.GetBasketAsync(id);
            if (basket != null) {
                return this.mapper.Map<Model.CustomerBasket>(basket);
            } else {
                return new Model.CustomerBasket {
                    Id = id
                };
            }
        }

        public async Task<Model.CustomerBasket> UpdateBasketAsync(Model.CustomerBasket customerBasket) {
            var customerBasketEntity = this.mapper.Map<Domain.CustomerBasket>(customerBasket);
            var updatedcustomerBasketEntity = await this.basketRepository.CreateOrUpdateBasketAsync(customerBasketEntity);
            return this.mapper.Map<Model.CustomerBasket>(updatedcustomerBasketEntity);
        }
    }
}
