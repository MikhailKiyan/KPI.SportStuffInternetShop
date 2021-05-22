using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KPI.SportStuffInternetShop.Contracts;
using KPI.SportStuffInternetShop.Domains;

namespace KPI.SportStuffInternetShop.Services.Contracts {
    public interface IGenericRepository<TEntity, TKey>
            where TEntity : BaseEntity<TKey> {
        ValueTask<TEntity> FineByKeyAsync(
            TKey key,
            CancellationToken ct);

        Task<IReadOnlyList<TEntity>> GetAllEntitiesAsync(CancellationToken ct);

        Task<IReadOnlyList<TEntity>> GetEntitiesWithSpecificationAsync(
            ISpecification<TEntity> spec,
            CancellationToken ct);

        Task<TEntity> GetEntityWithSpecificationAsync(
            ISpecification<TEntity> spec,
            CancellationToken ct);

        Task<int> CountAsync(
            ISpecification<TEntity> spec,
            CancellationToken ct);
    }
}
