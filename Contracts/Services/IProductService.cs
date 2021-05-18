using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Model = KPI.SportStuffInternetShop.Models.ResponseModels;

namespace KPI.SportStuffInternetShop.Contracts.Services {
    public interface IProductService {
        Task<IReadOnlyList<Model.Product>> GetProductsAsync(CancellationToken token = default);

        Task<Model.Product> GetProductByIdAsync(Guid id, CancellationToken token = default);
        
        Task<IReadOnlyList<Model.ProductBrand>> GetProductBrandsAsync(CancellationToken ct = default);
        
        Task<IReadOnlyList<Model.ProductType>> GetProductTypesAsync(CancellationToken ct = default);
    }
}
