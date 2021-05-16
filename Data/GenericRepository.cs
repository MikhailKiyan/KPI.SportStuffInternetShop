using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KPI.SportStuffInternetShop.Domains;
using KPI.SportStuffInternetShop.Services.Contracts;

namespace KPI.SportStuffInternetShop.Data {

    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey>
            where TEntity : BaseEntity<TKey> {
        readonly DbSet<TEntity> dbSet;

        public GenericRepository(ApplicationDbContext db) {
            this.dbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken ct) {
            return await this.dbSet.AsNoTracking().ToListAsync(ct);
        }

        public ValueTask<TEntity> GetByIdAsync(
                TKey key,
                CancellationToken ct = default) {

            var keys = new object[] { key };
            return this.dbSet.FindAsync(keys, cancellationToken: ct);
        }
    }
}
