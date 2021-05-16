using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KPI.SportStuffInternetShop.Domains;

namespace KPI.SportStuffInternetShop.Services.Contracts {
    public interface IGenericRepository<TEntity, TKey>
            where TEntity : BaseEntity<TKey> {
        ValueTask<TEntity> GetByIdAsync(TKey key, CancellationToken ct);

        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken ct);
    }
}
