using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KPI.SportStuffInternetShop.Contracts;
using KPI.SportStuffInternetShop.Domains;

namespace KPI.SportStuffInternetShop.Services.Contracts {
    public interface IGenericRepository<TEntity, TKey>
            where TEntity : BaseEntity<TKey> {
        ValueTask<TEntity> FineByKeyAsync(TKey key, CancellationToken ct);

        Task<IEnumerable<TEntity>> GetAllEntiotiesAsync(CancellationToken ct);

        Task<IEnumerable<TEntity>> GetEntitiesWithSpecificationAsync(ISpecification<TEntity> spec, CancellationToken ct);

        Task<TEntity> GetEntityWithSpecificationAsync(ISpecification<TEntity> spec, CancellationToken ct);
    }
}
