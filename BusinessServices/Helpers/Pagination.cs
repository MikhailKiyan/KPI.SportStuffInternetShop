using System.Collections.Generic;
using KPI.SportStuffInternetShop.Domains;

namespace KPI.SportStuffInternetShop.BusinessServices.Helpers {
    public class Pagination<T> where T: BaseEntity {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int Count { get; set; }

        public IReadOnlyList<T> Data { get; set; }
    }
}
