using System;
using System.Collections.Generic;
using System.Linq;

using KPI.SportStuffInternetShop.API.ErrorResponseModels;
using KPI.SportStuffInternetShop.Data;
using KPI.SportStuffInternetShop.Models.ResponseModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KPI.SportStuffInternetShop.API.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : BaseApiController {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> logger;
        private readonly ApplicationDbContext db;

        public WeatherForecastController(
                ILogger<WeatherForecastController> logger,
                ApplicationDbContext db) {
            this.logger = logger;
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get() {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundResponse() {
            return this.NotFound(new ApiResponse(404));
        }

        [HttpGet("servererror")]
        public ActionResult GetServerErrorResponse() {
            Product product = null;
            return Ok(product.ToString());
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequestResponse() {
            return this.BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequestResponse([FromRoute] int id) {
            throw new NotImplementedException();
        }
    }
}
