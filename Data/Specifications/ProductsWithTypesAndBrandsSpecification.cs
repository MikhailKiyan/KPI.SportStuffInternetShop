using System;

namespace KPI.SportStuffInternetShop.Data.Specifications {
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecifcation<Domains.Product> {
        public ProductsWithTypesAndBrandsSpecification() : base() {
            this.AddInclude(x => x.ProductType);
            this.AddInclude(x => x.ProductBrand);
        } 

        public ProductsWithTypesAndBrandsSpecification(Guid id) : base(x => x.Id == id) {
            this.AddInclude(x => x.ProductType);
            this.AddInclude(x => x.ProductBrand);
        }
    }
}
