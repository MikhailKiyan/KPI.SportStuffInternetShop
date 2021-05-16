using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KPI.SportStuffInternetShop.Domains;

namespace KPI.SportStuffInternetShop.Contracts.Services
{
    public interface IProductService {
        Task<IEnumerable<Product>> GetProductsAsync(CancellationToken token = default);

        ValueTask<Product> GetProductByIdAsync(Guid id, CancellationToken token = default);
        
        Task<IEnumerable<ProductBrand>> GetProductBrandsAsync(CancellationToken ct = default);
        
        Task<IEnumerable<ProductType>> GetProductTypesAsync(CancellationToken ct = default);
    }
}
