using Microsoft.Extensions.Configuration;
using AutoMapper;
using ResponseModel = KPI.SportStuffInternetShop.Models.ResponseModels;
using Domain = KPI.SportStuffInternetShop.Domains;

namespace KPI.SportStuffInternetShop.BusinessServices.Helpers {
    public class OrderItemUrlResolver : IValueResolver<Domain.Orders.OrderItem, ResponseModel.OrderItem, string> {
        private readonly IConfiguration config;

        public OrderItemUrlResolver(IConfiguration config) {
            this.config = config;
        }

        public string Resolve(
                Domain.Orders.OrderItem source,
                ResponseModel.OrderItem destination,
                string destMember,
                ResolutionContext context) {
            return !string.IsNullOrEmpty(source.ItemOrdered.PictureUrl)
                ? config["ApiUrl"] + source.ItemOrdered.PictureUrl
                : null;
        }
    }
}
