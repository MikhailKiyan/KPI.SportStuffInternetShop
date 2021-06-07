using AutoMapper;
using ResponseModel = KPI.SportStuffInternetShop.Models.ResponseModels;
using Domain = KPI.SportStuffInternetShop.Domains;

namespace KPI.SportStuffInternetShop.BusinessServices.MappingProfiles {
    public class OrderMappingProfile : Profile {
        public OrderMappingProfile() {
            this.CreateMap<Domain.Orders.Order, ResponseModel.Order>()
                .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
                .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));
        }
    }
}
