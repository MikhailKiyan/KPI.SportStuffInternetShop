using System.Linq;
using System.Security.Claims;

namespace KPI.SportStuffInternetShop.BusinessServices.Extensions {
    public static class ClaimsPrincipalExtensions {
        public static string GetEmail(this ClaimsPrincipal user) {
            return user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
        }
    }
}
