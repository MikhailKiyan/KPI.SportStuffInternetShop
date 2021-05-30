using System;
using System.ComponentModel.DataAnnotations;

namespace KPI.SportStuffInternetShop.Models {
    public class CustomerBasketItem {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Ціна повинна бути більша 0")]
        public decimal Price { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Кількість повинна бути не меншь 1")]
        public int Quantity { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
