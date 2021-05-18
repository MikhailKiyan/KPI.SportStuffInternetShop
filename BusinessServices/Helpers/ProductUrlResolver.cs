using Microsoft.Extensions.Configuration;
using AutoMapper;
using Model = KPI.SportStuffInternetShop.Models.ResponseModels;
using Domain = KPI.SportStuffInternetShop.Domains;

namespace KPI.SportStuffInternetShop.BusinessServices.Helpers {
    public class ProductUrlResolver : IValueResolver<Domain.Product, Model.Product, string> {
        readonly IConfiguration config;

        public ProductUrlResolver(IConfiguration config) {
            this.config = config;
        }

        public string Resolve(
                Domain.Product source,
                Model.Product destination,
                string destMember,
                ResolutionContext context) {

            if (!string.IsNullOrEmpty(source.PictureUrl)) return this.config["ApiUrl"] + source.PictureUrl;
            else return null;
        }
    }
}
