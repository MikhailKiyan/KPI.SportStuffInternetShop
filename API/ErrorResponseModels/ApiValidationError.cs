using System.Collections.Generic;

namespace KPI.SportStuffInternetShop.API.ErrorResponseModels {
    public class ApiValidationError : ApiResponse {
        public ApiValidationError() : base(400) {

        }

        public IEnumerable<string> Errors { get; set; }
    }
}
