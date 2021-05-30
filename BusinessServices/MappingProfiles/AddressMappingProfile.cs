using AutoMapper;
using Model = KPI.SportStuffInternetShop.Models;
using Domain = KPI.SportStuffInternetShop.Domains.Identity;

namespace KPI.SportStuffInternetShop.BusinessServices.MappingProfiles {
    public class AddressMappingProfile : Profile {
        public AddressMappingProfile() {
            this.CreateMap<Domain.Address, Model.Address>().ReverseMap();
        }
    }
}
