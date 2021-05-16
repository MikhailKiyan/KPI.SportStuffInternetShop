using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KPI.SportStuffInternetShop.Contracts.Services;

namespace KPI.SportStuffInternetShop.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase {
        private readonly IProductService service;

        public ProductsController(IProductService service) {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts(CancellationToken token) {
            return this.Ok(await this.service.GetProducts(token));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(
                [FromRoute] Guid id,
                CancellationToken token) {
            var result = await this.service.GetProductById(id, token);
            return result != null ? this.Ok(result) : this.NotFound();
        }
    }
}
