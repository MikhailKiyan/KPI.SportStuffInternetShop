using System;
using Microsoft.AspNetCore.Identity;

namespace KPI.SportStuffInternetShop.Domains.Identity {
    public class RoleClaim : IdentityRoleClaim<Guid> {
        public virtual Role Role { get; set; }
    }
}
