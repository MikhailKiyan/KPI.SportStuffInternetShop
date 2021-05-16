using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KPI.SportStuffInternetShop.Domains;

namespace KPI.SportStuffInternetShop.Contracts.Services
{
    public interface IProductService {
        Task<IEnumerable<Product>> GetProducts(CancellationToken token = default);

        ValueTask<Product> GetProductById(Guid id, CancellationToken token = default);
    }
}
