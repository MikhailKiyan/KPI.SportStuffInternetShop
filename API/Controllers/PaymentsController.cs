using KPI.SportStuffInternetShop.BusinessServices.Payment;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace KPI.SportStuffInternetShop.API.Controllers {
    public class PaymentsController : BaseApiController {
        private readonly IPaymentService paymentService;

        public PaymentsController(IPaymentService paymentService) {
            this.paymentService = paymentService;
        }

        [Authorize]
        [HttpPost("{basketId}")]
        public async Task<ActionResult> CreateOrUpdatePaymentIntentAsync(
                [FromRoute] Guid basketId,
                CancellationToken ct) {
            return this.Ok(await this.paymentService.CreateOrUpdatePaymentIntentAsync(basketId, ct));
        }
    }
}
