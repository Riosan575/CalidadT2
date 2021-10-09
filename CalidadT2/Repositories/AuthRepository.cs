using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CalidadT2.Repositories
{
    public interface IAuthRepository
    {
        void Login(List<Claim> claims);

        void Logout();
    }
    public class AuthRepository : IAuthRepository
    {
        private static HttpContext httpContext => new HttpContextAccessor().HttpContext;

        public void Login(List<Claim> claims)
        {
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            httpContext.SignInAsync(claimsPrincipal);
        }

        public void Logout()
        {
            httpContext.SignOutAsync();
        }
    }
}
