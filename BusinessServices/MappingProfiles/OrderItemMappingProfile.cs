using AutoMapper;
using KPI.SportStuffInternetShop.BusinessServices.Helpers;
using Domain = KPI.SportStuffInternetShop.Domains;
using ResponseModel = KPI.SportStuffInternetShop.Models.ResponseModels;

namespace KPI.SportStuffInternetShop.BusinessServices.MappingProfiles {
    public class OrderItemMappingProfile : Profile {
        public OrderItemMappingProfile() {
            this.CreateMap<Domain.Orders.OrderItem, ResponseModel.OrderItem>()
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.Id))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
                .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.ItemOrdered.PictureUrl))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>());
        }
    }
}
