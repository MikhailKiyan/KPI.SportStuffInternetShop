using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KPI.SportStuffInternetShop.Contracts.Services;
using KPI.SportStuffInternetShop.Data.Specifications;
using KPI.SportStuffInternetShop.Domains;
using KPI.SportStuffInternetShop.Services.Contracts;
using Model = KPI.SportStuffInternetShop.Models.ResponseModels;

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

        public async Task<Model.Product> GetProductByIdAsync(Guid id, CancellationToken ct = default) {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var result = await this.productRepository.GetEntityWithSpecificationAsync(spec, ct);
            return new Model.Product {
                Id = result.Id,
                Description = result.Description,
                Name = result.Name,
                PictureUrl = result.PictureUrl,
                Price = result.Price,
                ProductBrand = result.ProductBrand.Name,
                ProductType = result.ProductType.Name
            };
        }

        public async Task<IReadOnlyList<Model.Product>> GetProductsAsync(CancellationToken ct = default) {
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var result = await this.productRepository.GetEntitiesWithSpecificationAsync(spec, ct);
            return result.Select(p => new Model.Product {
                Id = p.Id,
                Description = p.Description,
                Name = p.Name,
                PictureUrl = p.PictureUrl,
                Price = p.Price,
                ProductBrand = p.ProductBrand.Name,
                ProductType = p.ProductType.Name
            }).ToList();
        }

        public async Task<IReadOnlyList<Model.ProductBrand>> GetProductBrandsAsync(CancellationToken ct = default) {
            var result = await this.brandRepository.GetAllEntitiesAsync(ct);
            return result.Select(pb => new Model.ProductBrand {
                Id = pb.Id,
                Name = pb.Name
            }).ToList();
        }

        public async Task<IReadOnlyList<Model.ProductType>> GetProductTypesAsync(CancellationToken ct = default) {
            var result = await this.typeRepository.GetAllEntitiesAsync(ct);
            return result.Select(pt => new Model.ProductType {
                Id = pt.Id,
                Name = pt.Name
            }).ToList();
        }
    }
}
