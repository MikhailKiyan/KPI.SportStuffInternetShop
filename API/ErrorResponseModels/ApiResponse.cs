using System;

namespace KPI.SportStuffInternetShop.API.ErrorResponseModels {
    public class ApiResponse {
        public ApiResponse(
                int statusCode,
                string message = null) {

            this.StatusCode = statusCode;
            this.Message = message ?? GetDefaultMessageFoeStatusCode(statusCode);
        }

        public int StatusCode { get; set; }

        public string Message { get; set; }
        
        private static string GetDefaultMessageFoeStatusCode(int statusCode) {
            return statusCode switch {
                400 => "A bad request",
                401 => "Not authorized",
                404 => "Not found resource",
                500 => "Server error!!!",
                _ => null
            };
        }
    }
}
