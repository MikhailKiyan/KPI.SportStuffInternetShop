using AutoMapper;
using Model = KPI.SportStuffInternetShop.Models.ResponseModels;
using Domain = KPI.SportStuffInternetShop.Domains;

namespace KPI.SportStuffInternetShop.BusinessServices.MappingProfiles {
    public class ProducMappingProfiles : Profile {
        public ProducMappingProfiles() {
            this.CreateMap<Domain.Product, Model.Product>()
                .ForMember(x => x.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(x => x.ProductType, o => o.MapFrom(s => s.ProductType.Name));
        }
    }
}
