using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace KPI.SportStuffInternetShop.Data {

    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext([NotNull] DbContextOptions<ApplicationDbContext> options)
                : base(options) { }

        public DbSet<Domains.Product> Products { get; set; }
    }
}
