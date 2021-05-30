using AutoMapper;
using Model = KPI.SportStuffInternetShop.Models;
using Domain = KPI.SportStuffInternetShop.Domains;

namespace KPI.SportStuffInternetShop.BusinessServices.MappingProfiles {
    public class CustomerBasketMappingProfile : Profile {
        public CustomerBasketMappingProfile() {
            this.CreateMap<Domain.CustomerBasket, Model.CustomerBasket>().ReverseMap();
        }
    }
}
