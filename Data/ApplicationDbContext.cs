using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KPI.SportStuffInternetShop.Domains.Identity;
using System.Reflection;

namespace KPI.SportStuffInternetShop.Data {

    public class ApplicationDbContext :
            IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken> {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        //public DbSet<Domains.Product> Products { get; set; }

        //public DbSet<Domains.ProductBrand> ProductBrands { get; set; }

        //public DbSet<Domains.ProductType> ProductTypes { get; set; }
    }
}
