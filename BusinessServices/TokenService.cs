using System;
using System.Text;
using System.Collections.Generic;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using KPI.SportStuffInternetShop.Contracts.Services;
using KPI.SportStuffInternetShop.Domains.Identity;

namespace KPI.SportStuffInternetShop.BusinessServices {
    public class TokenService : ITokenService {
        private readonly IConfiguration config;
        private readonly SecurityKey key;

        public TokenService(IConfiguration config) {
            this.config = config;
            this.key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.config["Token:Key"]));
        }

        public string CreateToken(User user) {
            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.DisplayName)
            };
            var credentions = new SigningCredentials(this.key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                Issuer = this.config["Token:Issuer"],
                SigningCredentials = credentions
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
