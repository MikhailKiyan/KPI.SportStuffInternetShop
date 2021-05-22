using System;
using KPI.SportStuffInternetShop.Models.RequestModels;

namespace KPI.SportStuffInternetShop.Data.Specifications {
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecifcation<Domains.Product> {
        public ProductsWithTypesAndBrandsSpecification(ProductCpecificationParams productParams)
                : base( x =>
                    (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
                    (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
                    (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
                ) {
            this.AddNavigationProperty();
            this.ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);
            switch (productParams.Sort) {
                case "priceAsc":
                    this.AddOrderBy(x => x.Price);
                    break;

                case "priceDesc":
                    this.AddOrderByDescending(x => x.Price);
                    break;

                case null:
                    this.AddOrderBy(x => x.Name);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(productParams.Sort), productParams.Sort, "Unexpected value");
            }
        } 

        public ProductsWithTypesAndBrandsSpecification(Guid id) : base(x => x.Id == id) {
            this.AddNavigationProperty();
        }

        private void AddNavigationProperty() {
            this.AddInclude(x => x.ProductType);
            this.AddInclude(x => x.ProductBrand);
        }
    }
}
