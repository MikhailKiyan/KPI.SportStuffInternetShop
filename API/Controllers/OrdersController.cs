using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using KPI.SportStuffInternetShop.Contracts.Services;
using KPI.SportStuffInternetShop.BusinessServices.Extensions;
using RequestModel = KPI.SportStuffInternetShop.Models.RequestModels;
using System.Threading;
using KPI.SportStuffInternetShop.API.ErrorResponseModels;

namespace KPI.SportStuffInternetShop.API.Controllers {
    [Authorize]
    public class OrdersController : BaseApiController {
        private readonly IOrderService orderService;
        private readonly IMapper mapper;

        public OrdersController(
                IOrderService orderService,
                IMapper mapper) {
            this.orderService = orderService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder(
                RequestModel.OrderRequestModel model,
                CancellationToken ct) {
            var email = this.HttpContext.User.GetEmail();
            var result = await this.orderService.CreateOrderAsync(model, email, ct);
            return result != null
                ? this.Ok(result)
                : this.BadRequest(new ApiResponse(400, "Проблема зі створенням замовлення"));
        }
    }
}
