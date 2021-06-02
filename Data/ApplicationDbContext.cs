using System;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Domain = KPI.SportStuffInternetShop.Domains;

namespace KPI.SportStuffInternetShop.Data {

    public class ApplicationDbContext :
            IdentityDbContext<Domain.Identity.User, Domain.Identity.Role, Guid, Domain.Identity.UserClaim,
                Domain.Identity.UserRole, Domain.Identity.UserLogin, Domain.Identity.RoleClaim,
                Domain.Identity.UserToken> {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Domain.Product> Products { get; set; }

        public DbSet<Domain.ProductBrand> ProductBrands { get; set; }

        public DbSet<Domain.ProductType> ProductTypes { get; set; }

        public DbSet<Domain.Orders.Order> Orders { get; set; }

        public DbSet<Domain.Orders.OrderItem> OrderItems { get; set; }

        public DbSet<Domain.Orders.DeliveryMethod> DeliveryMethods { get; set; }
    }
}
