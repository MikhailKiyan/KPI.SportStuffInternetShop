using System;

namespace KPI.SportStuffInternetShop.Domains.Identity {
    public class Address : BaseEntity<Guid> {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Oblast { get; set; }

        public string Zipcode { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
