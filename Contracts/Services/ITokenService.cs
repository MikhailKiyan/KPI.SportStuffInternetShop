using KPI.SportStuffInternetShop.Domains.Identity;

namespace KPI.SportStuffInternetShop.Contracts.Services {
    public interface ITokenService {
        string CreateToken(User user);
    }
}
