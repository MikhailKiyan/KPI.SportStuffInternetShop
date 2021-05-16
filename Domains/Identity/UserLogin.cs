using System;
using Microsoft.AspNetCore.Identity;

namespace KPI.SportStuffInternetShop.Domains.Identity {
    public class UserLogin : IdentityUserLogin<Guid> {
        public virtual User User { get; set; }
    }
}
