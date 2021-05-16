using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KPI.SportStuffInternetShop.Contracts.Services;
using KPI.SportStuffInternetShop.Data;
using KPI.SportStuffInternetShop.Domains;
using KPI.SportStuffInternetShop.Services.Contracts;

using Microsoft.EntityFrameworkCore;

namespace KPI.SportStuffInternetShop.BusinessServices {
    public class ProductService : IProductService {
        readonly IGenericRepository<Product, Guid> repository;

        public ProductService(IGenericRepository<Product, Guid> repository) {
            this.repository = repository;
        }

        public ValueTask<Product> GetProductById(Guid id, CancellationToken token = default) {
            return this.repository.GetByIdAsync(id, token);
        }

        public Task<IEnumerable<Product>> GetProducts(CancellationToken token = default) {
            return this.repository.GetAllAsync(token);
        }
    }
}
