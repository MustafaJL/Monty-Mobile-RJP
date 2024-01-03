using Domain.Entities;
using Infrastructure.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TokenManager : ITokenManager
    {
        public string CreateToken(User user, bool rememberMe, string secretKey, bool isAdmin)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("email", user.Email),
                new Claim("phoneNumber", user.PhoneNumber),
                new Claim("userId", user.Id.ToString()),
                new Claim("role", isAdmin ? "Admin" : "User"),
            };

            var key = new SymmetricSecurityKey(Encoding
                .UTF8
                .GetBytes(secretKey)
                );

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: rememberMe ? DateTime.UtcNow.AddHours(2).AddDays(30) : DateTime.UtcNow.AddHours(2).AddMinutes(30),
                signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
        public string GetClaimValueFromToken(HttpRequest Request, string claimKey)
        {
            var jwtToken = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwtToken) as JwtSecurityToken;

            if (jsonToken != null)
            {
                var claimValue = jsonToken?.Claims?.FirstOrDefault(claim => claim.Type == claimKey)?.Value;
                return claimValue;
            }

            return string.Empty;
        }
    }
}
