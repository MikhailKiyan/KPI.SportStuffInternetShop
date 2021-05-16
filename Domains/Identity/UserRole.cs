using System;
using Microsoft.AspNetCore.Identity;

namespace KPI.SportStuffInternetShop.Domains.Identity {
    public class UserRole : IdentityUserRole<Guid> {
        public virtual User User { get; set; }

        public virtual Role Role { get; set; }
    }
}
