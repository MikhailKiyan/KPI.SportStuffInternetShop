using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KPI.SportStuffInternetShop.Domains.Identity;

namespace KPI.SportStuffInternetShop.Data {

    public class ApplicationDbContext :
            IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken> {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        //public DbSet<Domains.Product> Products { get; set; }
    }
}
