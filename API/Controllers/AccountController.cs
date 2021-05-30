using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using KPI.SportStuffInternetShop.API.ErrorResponseModels;
using KPI.SportStuffInternetShop.Contracts.Services;
using KPI.SportStuffInternetShop.Models.RequestModels;
using KPI.SportStuffInternetShop.Models;

namespace KPI.SportStuffInternetShop.API.Controllers {
    public class AccountController : BaseApiController {
        private readonly IAccountService service;

        public AccountController(IAccountService service) {
            this.service = service;
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync([FromBody] Login model) {
            var result = await this.service.LoginAsync(model);
            return result == null
                ? this.Unauthorized(new ApiResponse(401))
                : this.Ok(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync([FromBody] Register model) {
            var result = await this.service.RegisterAsync(model);
            return result == null
                ? this.BadRequest(new ApiResponse(400))
                : this.Ok(result);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetCurrentUserAsync() {
            var result = await service.GetUserAsync(this.HttpContext.User);
            return this.Ok(result);
        }

        [HttpGet("emailexists")]
        public async Task<ActionResult> CheckEmailExistsAsync([FromQuery] string email) {
            var result = await this.service.CheckEmailExistsAsync(email);
            return this.Ok(result);
        }

        [HttpGet("address")]
        [Authorize]
        public async Task<ActionResult> GetCurrentUserAddressAsync() {
            var result = await this.service.GetUserAddressAsync(this.HttpContext.User);
            return this.Ok(result);
        }

        [HttpPut("address")]
        [Authorize]
        public async Task<ActionResult> UpdateUserAddressAsync([FromBody] Address address) {
            var result = await this.service.UpdateUserAddressAsync(this.HttpContext.User, address);
            return result != null
                ? this.Ok(result)
                : this.BadRequest();
        }

    }
}
