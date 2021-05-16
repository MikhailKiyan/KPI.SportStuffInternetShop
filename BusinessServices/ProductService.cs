using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KPI.SportStuffInternetShop.Contracts.Services;
using KPI.SportStuffInternetShop.Domains;
using KPI.SportStuffInternetShop.Services.Contracts;

namespace KPI.SportStuffInternetShop.BusinessServices {
    public class ProductService : IProductService {
        readonly IGenericRepository<Product, Guid> productRepository;
        readonly IGenericRepository<ProductBrand, Guid> brandRepository;
        readonly IGenericRepository<ProductType, Guid> typeRepository;

        public ProductService(
                IGenericRepository<Product, Guid> repository,
                IGenericRepository<ProductBrand, Guid> brandRepository,
                IGenericRepository<ProductType, Guid> typeRepository) {

            this.productRepository = repository;
            this.brandRepository = brandRepository;
            this.typeRepository = typeRepository;
        }

        public ValueTask<Product> GetProductByIdAsync(Guid id, CancellationToken ct = default) {
            return this.productRepository.GetByIdAsync(id, ct);
        }

        public Task<IEnumerable<Product>> GetProductsAsync(CancellationToken ct = default) {
            return this.productRepository.GetAllAsync(ct);
        }

        public Task<IEnumerable<ProductBrand>> GetProductBrandsAsync(CancellationToken ct = default) {
            return this.brandRepository.GetAllAsync(ct);
        }

        public Task<IEnumerable<ProductType>> GetProductTypesAsync(CancellationToken ct = default) {
            return this.typeRepository.GetAllAsync(ct);
        }
    }
}
