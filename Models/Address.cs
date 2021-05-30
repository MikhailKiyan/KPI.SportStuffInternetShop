using System.ComponentModel.DataAnnotations;

namespace KPI.SportStuffInternetShop.Models {
    public class Address {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Oblast { get; set; }

        [Required]
        public string Zipcode { get; set; }
    }
}
