using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using KPI.SportStuffInternetShop.Domains;

namespace KPI.SportStuffInternetShop.Data {
    public class SeedData {
        public static async Task SeedAsync(
                ApplicationDbContext context,
                ILoggerFactory loggerFactory) {

            const string pathPrefix = @"..\Data\Seed\";

            try {
                if (!context.ProductBrands.Any()) {
                    var brands = JsonConvert.DeserializeObject<List<ProductBrand>>(await File.ReadAllTextAsync(pathPrefix + "productBrands.json"));
                    foreach (var brand in brands) {
                        context.ProductBrands.Add(brand);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.ProductTypes.Any()) {
                    var types = JsonConvert.DeserializeObject<List<ProductType>>(await File.ReadAllTextAsync(pathPrefix + "productTypes.json"));
                    foreach (var type in types) {
                        context.ProductTypes.Add(type);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any()) {
                    var products = JsonConvert.DeserializeObject<List<Product>>(await File.ReadAllTextAsync(pathPrefix + "products.json"));
                    foreach (var product in products) {
                        context.Products.Add(product);
                    }
                    await context.SaveChangesAsync();
                }
            } catch (Exception ex) {
                var logger = loggerFactory.CreateLogger<SeedData>();
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
