using KPI.SportStuffInternetShop.Domains;
using RequestModel = KPI.SportStuffInternetShop.Models.RequestModels;

namespace KPI.SportStuffInternetShop.Data.Specifications {
    public class ProductWithFilterForCountSpecification : BaseSpecifcation<Product>{
        public ProductWithFilterForCountSpecification(RequestModel.ProductCpecificationParams productParams)
                : base(x =>
                    (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
                   (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
                   (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
                ) {

        }
    }
}
