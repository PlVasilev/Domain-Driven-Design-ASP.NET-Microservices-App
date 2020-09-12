using System.Collections.Generic;
using Seller.Identity.Data;
using Seller.Identity.Data.Models;
using Seller.Identity.Features.Identity.Services.Interfaces;

namespace Seller.Identity.Features.Identity.Services
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using Microsoft.IdentityModel.Tokens;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;

    public class IdentityService : IIdentityService
    {
        private const string InvalidErrorMessage = "Invalid credentials.";

        private readonly UserManager<User> userManager;
        private readonly IdentityDbContext context;

        public IdentityService(UserManager<User> userManager, IdentityDbContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }

      

        public async Task<User> Register(string username, string password)
        {
            var user = new User()
            {
                UserName = username
            };

            await this.userManager.CreateAsync(user, password);

            if (userManager.Users.Count() == 1)
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }

            await userManager.AddToRoleAsync(user, "User");

            return user;
        }
        public string GenerateJwtToken(string userId, string userName, string secret, IEnumerable<string> roles = null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, userName)
            };

            if (roles != null)
            {
                claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

 
    }
}
