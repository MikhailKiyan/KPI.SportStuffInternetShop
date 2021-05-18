namespace KPI.SportStuffInternetShop.API.Controllers {
    using KPI.SportStuffInternetShop.API.ErrorResponseModels;

    using Microsoft.AspNetCore.Mvc;

    [Route("error/{code}")]
    public class ErrorController : BaseApiController {
        public ActionResult Error(int code) {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
