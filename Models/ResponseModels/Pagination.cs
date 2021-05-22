using System.Collections.Generic;

namespace KPI.SportStuffInternetShop.Models.ResponseModels {
    public class Pagination<T> {
        public Pagination(
                int pageIndex,
                int pageSize,
                int totalItems,
                IReadOnlyList<T> data) {

            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.Count = totalItems;
            this.Data = data;
        }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int Count { get; set; }

        public IReadOnlyList<T> Data { get; set; }
    }
}
