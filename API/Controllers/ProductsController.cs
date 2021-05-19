using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using KPI.SportStuffInternetShop.Contracts.Services;
using KPI.SportStuffInternetShop.API.ErrorResponseModels;
using KPI.SportStuffInternetShop.Models.ResponseModels;
using System.Collections.Generic;

namespace KPI.SportStuffInternetShop.API.Controllers {
    public class ProductsController : BaseApiController {
        private readonly IProductService service;

        public ProductsController(IProductService service) {
            this.service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>) StatusCodes.Status200OK)]
        public async Task<ActionResult> GetProductsAsync(CancellationToken ct) {
            return this.Ok(await this.service.GetProductsAsync(ct));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Product) StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetProductAsync(
                [FromRoute] Guid id,
                CancellationToken ct) {
            var result = await this.service.GetProductByIdAsync(id, ct);
            return result != null ? this.Ok(result) : this.NotFound(new ApiResponse(404));
        }

        [HttpGet("brands")]
        [ProducesResponseType(typeof(IEnumerable<ProductBrand>) StatusCodes.Status200OK)]
        public async Task<ActionResult> GetProductBrandsAsync(CancellationToken ct) {
            return this.Ok(await this.service.GetProductBrandsAsync(ct));
        }

        [HttpGet("types")]
        [ProducesResponseType(typeof(IEnumerable<ProductType>) StatusCodes.Status200OK)]
        public async Task<ActionResult> GetProductTypesAsync(CancellationToken ct) {
            return this.Ok(await this.service.GetProductTypesAsync(ct));
        }
    }
}
