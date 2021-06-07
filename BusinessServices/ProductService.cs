using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using KPI.SportStuffInternetShop.Contracts.Services;
using KPI.SportStuffInternetShop.Data.Specifications;
using KPI.SportStuffInternetShop.Services.Contracts;
using Domain = KPI.SportStuffInternetShop.Domains;
using RequestModel = KPI.SportStuffInternetShop.Models.RequestModels;
using ResponseModel = KPI.SportStuffInternetShop.Models.ResponseModels;

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

        public async Task<ResponseModel.Product> GetProductByIdAsync(Guid id, CancellationToken ct = default) {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var result = await this.productRepository.GetEntityWithSpecificationAsync(spec, ct);
            return this.mapper.Map<ResponseModel.Product>(result);
        }

        public async Task<ResponseModel.Pagination<ResponseModel.Product>> GetProductsAsync(
                RequestModel.ProductCpecificationParams productParams,
                CancellationToken ct = default) {
            var productSpec = new ProductsWithTypesAndBrandsSpecification(productParams);
            var countSpec = new ProductWithFilterForCountSpecification(productParams);
            var productsTask = this.productRepository.GetEntitiesWithSpecificationAsync(productSpec, ct);
            var totalItemsTask = this.productRepository.CountAsync(countSpec, ct);
            var data = this.mapper.Map<IReadOnlyList<ResponseModel.Product>>(await productsTask);
            return new ResponseModel.Pagination<ResponseModel.Product>(productParams.PageIndex, productParams.PageSize,
                await totalItemsTask, data);
        }

        public async Task<IReadOnlyList<ResponseModel.ProductBrand>> GetProductBrandsAsync(CancellationToken ct = default) {
            var result = await this.brandRepository.GetAllEntitiesAsync(ct);
            return this.mapper.Map<IReadOnlyList<ResponseModel.ProductBrand>>(result);
        }

        public async Task<IReadOnlyList<ResponseModel.ProductType>> GetProductTypesAsync(CancellationToken ct = default) {
            var result = await this.typeRepository.GetAllEntitiesAsync(ct);
            return this.mapper.Map<IReadOnlyList<ResponseModel.ProductType>>(result);
        }
    }
}
