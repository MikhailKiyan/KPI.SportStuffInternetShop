using System;
using System.Threading;
using System.Threading.Tasks;
using KPI.SportStuffInternetShop.Domains;

namespace KPI.SportStuffInternetShop.Contracts.Services {
    public interface IBasketRepository {
        Task<CustomerBasket> GetBasketAsync(Guid basketId);

        Task<CustomerBasket> CreateOrUpdateBasketAsync(CustomerBasket customerBasket);

        Task<bool> DeleteBasketAsync(Guid basketId);
    }
}
