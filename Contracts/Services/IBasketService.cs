using System;
using System.Threading.Tasks;
using Domain = KPI.SportStuffInternetShop.Domains;

namespace KPI.SportStuffInternetShop.Contracts.Services {
    public interface IBasketService {
        Task<Domain.CustomerBasket> GetBasketsById(Guid id);

        Task<Domain.CustomerBasket> UpdateBasketAsync(Domain.CustomerBasket customerBasket);

        Task<Domain.CustomerBasket> CreateBasketAsync(Domain.CustomerBasket customerBasket);

        Task DeleteBasketAsync(Guid id);
    }
}
