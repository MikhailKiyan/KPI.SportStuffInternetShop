using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KPI.SportStuffInternetShop.Domains;
using KPI.SportStuffInternetShop.Services.Contracts;
using KPI.SportStuffInternetShop.Contracts;
using System.Linq;

namespace KPI.SportStuffInternetShop.Data {

    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey>
            where TEntity : BaseEntity<TKey> {
        readonly DbSet<TEntity> dbSet;

        public GenericRepository(ApplicationDbContext db) {
            this.dbSet = db.Set<TEntity>();
        }

        public async Task<IReadOnlyList<TEntity>> GetAllEntitiesAsync(CancellationToken ct) {
            return await this.dbSet.AsNoTracking().ToListAsync(ct);
        }

        public ValueTask<TEntity> FineByKeyAsync(
                TKey key,
                CancellationToken ct = default) {

            var keys = new object[] { key };
            return this.dbSet.FindAsync(keys, cancellationToken: ct);
        }

        public async Task<IReadOnlyList<TEntity>> GetEntitiesWithSpecificationAsync(
                ISpecification<TEntity> spec,
                CancellationToken ct = default) {

            return await ApplySpecification(dbSet.AsNoTracking(), spec).ToListAsync(ct);
        }

        public Task<TEntity> GetEntityWithSpecificationAsync(
                ISpecification<TEntity> spec,
                CancellationToken ct = default) {

            return ApplySpecification(dbSet.AsNoTracking(), spec).SingleOrDefaultAsync(ct);
        }

        public Task<int> CountAsync(
                ISpecification<TEntity> spec,
                CancellationToken ct) {
            return ApplySpecification(dbSet.AsNoTracking(), spec).CountAsync(ct);
        }

        static IQueryable<TEntity> ApplySpecification(
                IQueryable<TEntity> sourceQuery,
                ISpecification<TEntity> spec) {
            return SpecificationEvaluator<TEntity>.GetQuery(sourceQuery, spec);
        }
    }
}
