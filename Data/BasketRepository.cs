using System;
using System.Threading.Tasks;
using StackExchange.Redis;
using KPI.SportStuffInternetShop.Contracts.Services;
using KPI.SportStuffInternetShop.Domains;
using Newtonsoft.Json;

namespace KPI.SportStuffInternetShop.Data {
    public class BasketRepository : IBasketRepository {
        private readonly IDatabase database;
        public BasketRepository(IConnectionMultiplexer redis) {
            this.database = redis.GetDatabase();
        }

        public Task<bool> DeleteBasketAsync(Guid basketId) {
            return this.database.KeyDeleteAsync(basketId.ToString());
        }

        public async Task<CustomerBasket> GetBasketAsync(Guid basketId) {
            var data = await this.database.StringGetAsync(basketId.ToString());
            if (data.IsNullOrEmpty) return null;
            return JsonConvert.DeserializeObject<CustomerBasket>(data);
        }

        public async Task<CustomerBasket> CreateOrUpdateBasketAsync(CustomerBasket customerBasket) {
            var json = JsonConvert.SerializeObject(customerBasket);
            var ttl = TimeSpan.FromDays(30);
            var created = await this.database.StringSetAsync(customerBasket.Id.ToString(), json, ttl);
            if (!created) return null;
            return await this.GetBasketAsync(customerBasket.Id);
        }
    }
}
