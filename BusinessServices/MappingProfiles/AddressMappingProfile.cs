using AutoMapper;
using Model = KPI.SportStuffInternetShop.Models;
using Domain = KPI.SportStuffInternetShop.Domains;

namespace KPI.SportStuffInternetShop.BusinessServices.MappingProfiles {
    public class AddressMappingProfile : Profile {
        public AddressMappingProfile() {
            this.CreateMap<Domain.Identity.Address, Model.Address>().ReverseMap();
            this.CreateMap<Model.Address, Domain.Orders.OrderAddress>().ReverseMap();
        }
    }
}
