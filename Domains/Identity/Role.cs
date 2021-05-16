using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace KPI.SportStuffInternetShop.Domains.Identity {
    public class Role : IdentityRole<Guid> {
        public virtual List<UserRole> UserRoles { get; set; }
    }
}
