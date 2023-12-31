using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IServices
{
    public interface ITokenManager
    {
        public string CreateToken(User user, bool rememberMe, string tokenKey, bool isAdmin);
        public string GetClaimValueFromToken(HttpRequest Request, string claimKey);
    }
}
