using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using KPI.SportStuffInternetShop.Domains.Identity;
using Microsoft.EntityFrameworkCore;

namespace KPI.SportStuffInternetShop.BusinessServices.Extensions {
    public static class UserManagerExtensions {
        public static Task<User> FindUserByClaimsPrincipalWithAddressAsync(
                this UserManager<User> userManager,
                ClaimsPrincipal user) {
            var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            return userManager.Users.Include(x => x.Address).SingleOrDefaultAsync(u => u.Email == email);
        }

        public static Task<User> FindUserByClaimsPrinciple(
                this UserManager<User> userManager,
                ClaimsPrincipal user) {
            var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            return userManager.Users.SingleOrDefaultAsync(u => u.Email == email);
        }
    }
}
