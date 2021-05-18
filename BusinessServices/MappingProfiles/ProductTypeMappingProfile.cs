using AutoMapper;
using Model = KPI.SportStuffInternetShop.Models.ResponseModels;
using Domain = KPI.SportStuffInternetShop.Domains;

namespace KPI.SportStuffInternetShop.BusinessServices.MappingProfiles {
    public class ProductTypeMappingProfile : Profile {
        public ProductTypeMappingProfile() {
            this.CreateMap<Domain.ProductType, Model.ProductType>();
        }
    }
}
