using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KPI.SportStuffInternetShop.Contracts.Services;
using KPI.SportStuffInternetShop.Data;
using KPI.SportStuffInternetShop.Domains;

using Microsoft.EntityFrameworkCore;

namespace KPI.SportStuffInternetShop.BusinessServices {
    public class ProductService : IProductService {
        private readonly ApplicationDbContext db;

        public ProductService(ApplicationDbContext db) {
            this.db = db;
        }

        public ValueTask<Product> GetProductById(int id, CancellationToken token) {
            var keys = new object[] { id };
            return this.db.Products.FindAsync(keys, cancellationToken: token);
        }

        public async Task<IEnumerable<Product>> GetProducts(CancellationToken token) {
            return await this.db.Products.AsNoTracking().ToListAsync(token);
        }
    }
}
