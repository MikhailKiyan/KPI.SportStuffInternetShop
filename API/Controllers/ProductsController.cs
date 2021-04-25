using Microsoft.AspNetCore.Mvc;

namespace KPI.SportStuffInternetShop.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase {

        [HttpGet]
        public string GetProducts() {
            return "some products";
        }

        [HttpGet("{id}")]
        public string GetProduct(int id) {
            return $"a product with ID {id}";
        }
    }
}
