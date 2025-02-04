﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace KPI.SportStuffInternetShop.Domains.Identity {
    public class User : IdentityUser<Guid> {
        public virtual List<UserRole> UserRoles { get; set; }

        public string DisplayName { get; set; }

        public Address Address { get; set; }
    }
}
