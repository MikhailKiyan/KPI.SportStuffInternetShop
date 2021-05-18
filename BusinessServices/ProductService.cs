using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using KPI.SportStuffInternetShop.Contracts.Services;
using KPI.SportStuffInternetShop.Data.Specifications;
using KPI.SportStuffInternetShop.Services.Contracts;
using Model = KPI.SportStuffInternetShop.Models.ResponseModels;
using Domain = KPI.SportStuffInternetShop.Domains;

namespace KPI.SportStuffInternetShop.BusinessServices {
    public class ProductService : IProductService {
        readonly IGenericRepository<Domain.Product, Guid> productRepository;
        readonly IGenericRepository<Domain.ProductBrand, Guid> brandRepository;
        readonly IGenericRepository<Domain.ProductType, Guid> typeRepository;
        readonly IMapper mapper;

        public ProductService(
                IGenericRepository<Domain.Product, Guid> repository,
                IGenericRepository<Domain.ProductBrand, Guid> brandRepository,
                IGenericRepository<Domain.ProductType, Guid> typeRepository,
                IMapper mapper) {

            this.productRepository = repository;
            this.brandRepository = brandRepository;
            this.typeRepository = typeRepository;
            this.mapper = mapper;
        }

        public async Task<Model.Product> GetProductByIdAsync(Guid id, CancellationToken ct = default) {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var result = await this.productRepository.GetEntityWithSpecificationAsync(spec, ct);
            return this.mapper.Map<Model.Product>(result);
        }

        public async Task<IReadOnlyList<Model.Product>> GetProductsAsync(CancellationToken ct = default) {
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var result = await this.productRepository.GetEntitiesWithSpecificationAsync(spec, ct);
            return this.mapper.Map<IReadOnlyList<Model.Product>>(result);
        }

        public async Task<IReadOnlyList<Model.ProductBrand>> GetProductBrandsAsync(CancellationToken ct = default) {
            var result = await this.brandRepository.GetAllEntitiesAsync(ct);
            return this.mapper.Map<IReadOnlyList<Model.ProductBrand>>(result);
        }

        public async Task<IReadOnlyList<Model.ProductType>> GetProductTypesAsync(CancellationToken ct = default) {
            var result = await this.typeRepository.GetAllEntitiesAsync(ct);
            return this.mapper.Map<IReadOnlyList<Model.ProductType>>(result);
        }
    }
}
