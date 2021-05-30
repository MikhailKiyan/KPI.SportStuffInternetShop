using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using KPI.SportStuffInternetShop.Contracts.Services;
using KPI.SportStuffInternetShop.Domains.Identity;
using KPI.SportStuffInternetShop.BusinessServices.Extensions;
using Model = KPI.SportStuffInternetShop.Models;
using RequestModel = KPI.SportStuffInternetShop.Models.RequestModels;
using ResponseModel = KPI.SportStuffInternetShop.Models.ResponseModels;
using Domain = KPI.SportStuffInternetShop.Domains.Identity;

namespace KPI.SportStuffInternetShop.BusinessServices {
    public class AccountService : IAccountService {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly ITokenService tokenService;
        private readonly IMapper mapper;

        public AccountService(
                UserManager<User> userManager,
                SignInManager<User> signInManager,
                ITokenService tokenService,
                IMapper mapper
        ) {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenService = tokenService;
            this.mapper = mapper;
        }

        public async Task<ResponseModel.Login> LoginAsync(RequestModel.Login model) {
            var user = await this.userManager.FindByEmailAsync(model.Email);
            if (user == null) return null;
            var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded) return null;
            else return new ResponseModel.Login {
                Email = user.Email,
                DisplayName = user.DisplayName,
                Token = this.tokenService.CreateToken(user),
            };
        }

        public async Task<ResponseModel.Login> RegisterAsync(RequestModel.Register model) {
            var user = new User {
                DisplayName = model.DisplayName,
                Email = model.Email,
                UserName = model.Email
            };
            var result = await this.userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded) return null;
            else return new ResponseModel.Login {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = this.tokenService.CreateToken(user)
            };
        }

        public async Task<ResponseModel.Login> GetUserAsync(ClaimsPrincipal userClaims) {
            var user = await userManager.FindUserByClaimsPrinciple(userClaims);
            return new ResponseModel.Login {
                Email = user.Email,
                DisplayName = user.DisplayName,
                Token = this.tokenService.CreateToken(user)
            };
        }

        public async Task<bool> CheckEmailExistsAsync(string email) {
            return await this.userManager.FindByEmailAsync(email) != null;
        }

        public async Task<Model.Address> GetUserAddressAsync(ClaimsPrincipal userClaims) {
            var user = await this.userManager.FindUserByClaimsPrincipalWithAddressAsync(userClaims);
            return user.Address != null
                ? this.mapper.Map<Model.Address>(user.Address)
                : null;
        }

        public async Task<Model.Address> UpdateUserAddressAsync(
                ClaimsPrincipal userClaims,
                Model.Address address) {
            var user = await this.userManager.FindUserByClaimsPrincipalWithAddressAsync(userClaims);
            user.Address = this.mapper.Map<Domain.Address>(address);
            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded) return this.mapper.Map<Model.Address>(user.Address);
            else return null;
        }
    }
}
