using System.Security.Claims;
using System.Threading.Tasks;
using Model = KPI.SportStuffInternetShop.Models;
using RequestModel = KPI.SportStuffInternetShop.Models.RequestModels;
using ResponseModel = KPI.SportStuffInternetShop.Models.ResponseModels;

namespace KPI.SportStuffInternetShop.Contracts.Services {
    public interface IAccountService {
        Task<ResponseModel.Login> LoginAsync(RequestModel.Login model);

        Task<ResponseModel.Login> RegisterAsync(RequestModel.Register model);

        Task<ResponseModel.Login> GetUserAsync(ClaimsPrincipal userClaims);

        Task<bool> CheckEmailExistsAsync(string email);

        Task<Model.Address> GetUserAddressAsync(ClaimsPrincipal userClaims);

        Task<Model.Address> UpdateUserAddressAsync(ClaimsPrincipal userClaims, Model.Address address);
    }
}
