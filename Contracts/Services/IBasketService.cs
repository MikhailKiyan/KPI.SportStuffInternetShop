using System;
using System.Threading.Tasks;
using Model = KPI.SportStuffInternetShop.Models;

namespace KPI.SportStuffInternetShop.Contracts.Services {
    public interface IBasketService {
        Task<Model.CustomerBasket> GetBasketsById(Guid id);

        Task<Model.CustomerBasket> UpdateBasketAsync(Model.CustomerBasket customerBasket);

        Task<Model.CustomerBasket> CreateBasketAsync(Model.CustomerBasket customerBasket);

        Task DeleteBasketAsync(Guid id);
    }
}
