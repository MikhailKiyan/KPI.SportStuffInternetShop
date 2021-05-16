using System;
using Microsoft.AspNetCore.Identity;

namespace KPI.SportStuffInternetShop.Domains.Identity {
    public class UserClaim : IdentityUserClaim<Guid> {
        public virtual User User { get; set; }
    }
}
