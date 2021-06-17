using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KPI.SportStuffInternetShop.Contracts.Services;
using KPI.SportStuffInternetShop.Domains;
using KPI.SportStuffInternetShop.Services.Contracts;

namespace KPI.SportStuffInternetShop.Data {
    public class UnitOfWork : IUnitOfWork {
        private readonly DbContext dbContext;
        private readonly Hashtable repositories;

        public UnitOfWork(
                DbContext dbContext) {
            this.dbContext = dbContext;
            this.repositories = new Hashtable();
        }

        public Task<int> CompleteAsync(CancellationToken ct = default) {
            return this.dbContext.SaveChangesAsync(ct);
        }

        public void Dispose() {
            this.dbContext.Dispose();
        }

        public IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey> {
            var type = typeof(TEntity);
            if (!this.repositories.ContainsKey(type)) {
                var repositoryType = typeof(GenericRepository<,>);
                var repository = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity), typeof(TKey)),
                    this.dbContext);
                this.repositories.Add(type, repository);
            }
            return (IGenericRepository<TEntity, TKey>)this.repositories[type];
        }
    }
}
