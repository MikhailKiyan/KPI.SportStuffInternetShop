using AutoMapper;
using Model = KPI.SportStuffInternetShop.Models.ResponseModels;
using Domain = KPI.SportStuffInternetShop.Domains;

namespace KPI.SportStuffInternetShop.BusinessServices.MappingProfiles {
    public class ProductBrandMappingProfile : Profile {
        public ProductBrandMappingProfile() {
            this.CreateMap<Domain.ProductBrand, Model.ProductBrand>();
        }
    }
}
