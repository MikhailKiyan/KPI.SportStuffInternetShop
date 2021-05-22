using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RequestModel = KPI.SportStuffInternetShop.Models.RequestModels;
using ResponseModel = KPI.SportStuffInternetShop.Models.ResponseModels;

namespace KPI.SportStuffInternetShop.Contracts.Services {
    public interface IProductService {
        Task<ResponseModel.Pagination<ResponseModel.Product>> GetProductsAsync(
            RequestModel.ProductCpecificationParams productParams,
            CancellationToken token = default);

        Task<ResponseModel.Product> GetProductByIdAsync(
            Guid id,
            CancellationToken token = default);
        
        Task<IReadOnlyList<ResponseModel.ProductBrand>> GetProductBrandsAsync(
            CancellationToken ct = default);
        
        Task<IReadOnlyList<ResponseModel.ProductType>> GetProductTypesAsync(
            CancellationToken ct = default);
    }
}
