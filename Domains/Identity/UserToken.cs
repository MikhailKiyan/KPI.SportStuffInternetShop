using System;
using Microsoft.AspNetCore.Identity;

namespace KPI.SportStuffInternetShop.Domains.Identity {
    public class UserToken : IdentityUserToken<Guid> {
        public virtual User User { get; set; }
    }
}
