using System;

namespace KPI.SportStuffInternetShop.Models.RequestModels {
    public class ProductCpecificationParams {
        private const int MaxPageSize = 50;

        public int PageIndex { get; set; } = 1;

        private int pageSize = 6;
        public int PageSize {
            get => pageSize;
            set => pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public Guid? BrandId { get; set; }

        public Guid? TypeId { get; set; }

        public string Sort { get; set; }

        private string search;
        public string Search {
            get => search;
            set => search = value.ToLower();
        }
    }
}
