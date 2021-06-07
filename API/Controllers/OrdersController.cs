using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using KPI.SportStuffInternetShop.Contracts.Services;
using KPI.SportStuffInternetShop.BusinessServices.Extensions;
using KPI.SportStuffInternetShop.API.ErrorResponseModels;
using RequestModel = KPI.SportStuffInternetShop.Models.RequestModels;

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
        public async Task<ActionResult> CreateOrderAsync(
                RequestModel.OrderRequestModel model,
                CancellationToken ct) {
            var email = this.HttpContext.User.GetEmail();
            var result = await this.orderService.CreateOrderAsync(model, email, ct);
            return result != null
                ? this.Ok(result)
                : this.BadRequest(new ApiResponse(400, "Проблема зі створенням замовлення"));
        }

        [HttpGet]
        public async Task<ActionResult> GetOrdersAsync(CancellationToken ct) {
            var currentUserEmail = this.HttpContext.User.GetEmail();
            return this.Ok(await this.orderService.GetOrdersForUserAsync(currentUserEmail, ct));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrderByIdForUserAsync(
                Guid id,
                CancellationToken ct) {
            var currentUserEmail = this.HttpContext.User.GetEmail();
            var result = await this.orderService.GetOrderByIdAsync(id, currentUserEmail, ct);
            return result == null
                ? this.NotFound(new ApiResponse(400, "Не знайдене відповідне замовлення"))
                : this.Ok(result);
        }

        [HttpGet("deliveryMethods")]
        public async Task<ActionResult> GetDeliveryMethods(CancellationToken ct) {
            return this.Ok(await this.orderService.GetDeliveryMethods(ct));
        }
    }
}
