using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KPI.SportStuffInternetShop.Contracts.Services;
using Model = KPI.SportStuffInternetShop.Models;

namespace KPI.SportStuffInternetShop.API.Controllers {
    public class BasketsController : BaseApiController {
        private readonly IBasketService service;

        public BasketsController(IBasketService baskerService) {
            this.service = baskerService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBasketsByIdAsync([FromRoute] Guid id) {
            return this.Ok(await this.service.GetBasketsById(id));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBasketAsync([FromBody] Model.CustomerBasket customerBasket) {
            var updatedBasket = await this.service.UpdateBasketAsync(customerBasket);
            return this.Ok(updatedBasket);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBasketAsync([FromBody] Model.CustomerBasket customerBasket) {
            var createdBasket = await this.service.CreateBasketAsync(customerBasket);
            return this.Ok(createdBasket);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBasketAsync([FromRoute] Guid id) {
            await this.service.DeleteBasketAsync(id);
            return this.Ok();
        }
    }
}
