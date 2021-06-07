using System;
using System.Threading;
using System.Threading.Tasks;
using KPI.SportStuffInternetShop.Domains;
using KPI.SportStuffInternetShop.Services.Contracts;

namespace KPI.SportStuffInternetShop.Contracts.Services {
    public interface IUnitOfWork : IDisposable {
        IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;

        Task<int> CompleteAsync(CancellationToken ct = default);
    }
}
