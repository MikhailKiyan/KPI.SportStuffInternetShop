using AutoMapper;
using Model = KPI.SportStuffInternetShop.Models;
using Domain = KPI.SportStuffInternetShop.Domains;

namespace KPI.SportStuffInternetShop.BusinessServices.MappingProfiles {
    public class CustomerBasketItemMappingProfile : Profile {
        public CustomerBasketItemMappingProfile() {
            this.CreateMap<Domain.CustomerBasketItem, Model.CustomerBasketItem>().ReverseMap();
        }
    }
}
