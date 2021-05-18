using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KPI.SportStuffInternetShop.Contracts.Services;

namespace KPI.SportStuffInternetShop.API.Controllers {
    public class ProductsController : BaseApiController {
        private readonly IProductService service;

        public ProductsController(IProductService service) {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetProductsAsync(CancellationToken ct) {
            return this.Ok(await this.service.GetProductsAsync(ct));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductAsync(
                [FromRoute] Guid id,
                CancellationToken ct) {
            var result = await this.service.GetProductByIdAsync(id, ct);
            return result != null ? this.Ok(result) : this.NotFound();
        }

        [HttpGet("brands")]
        public async Task<ActionResult> GetProductBrandsAsync(CancellationToken ct) {
            return this.Ok(await this.service.GetProductBrandsAsync(ct));
        }

        [HttpGet("types")]
        public async Task<ActionResult> GetProductTypesAsync(CancellationToken ct) {
            return this.Ok(await this.service.GetProductTypesAsync(ct));
        }
    }
}
