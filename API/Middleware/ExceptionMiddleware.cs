using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using KPI.SportStuffInternetShop.API.ErrorResponseModels;
using Newtonsoft.Json.Serialization;

namespace KPI.SportStuffInternetShop.API.Middleware {
    public class ExceptionMiddleware {
        readonly RequestDelegate next;
        readonly ILogger<ExceptionMiddleware> logger;
        readonly IHostEnvironment env;

        public ExceptionMiddleware(
                RequestDelegate next,
                ILogger<ExceptionMiddleware> logger,
                IHostEnvironment env) {
            this.next = next;
            this.logger = logger;
            this.env = env;
        }

        public async Task InvokeAsync(HttpContext context) {
            try {
                await this.next(context);
            } catch (Exception ex) {
                logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = env.IsDevelopment()
                    ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace.ToString())
                    : new ApiResponse(context.Response.StatusCode);
                var settings = new JsonSerializerSettings {
                    ContractResolver = new DefaultContractResolver {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    },
                    Formatting = Formatting.None
                };
                var json = JsonConvert.SerializeObject(response, settings);
                await context.Response.WriteAsync(json);
            }
        }

    }
}
