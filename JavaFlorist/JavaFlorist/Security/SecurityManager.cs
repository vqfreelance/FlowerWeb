using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using JavaFlorist.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace JavaFlorist.Security
{
    public class SecurityManager
    {
        private IEnumerable<Claim> GetClaimsOfAccount(Account account)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, account.Username));
            claims.Add(new Claim(ClaimTypes.Name, account.Name)); //lay username
            claims.Add(new Claim(ClaimTypes.Role, account.Role)); //lay roles cua username
            return claims;
        }

        public async void SignIn(HttpContext httpContext, Account account)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(GetClaimsOfAccount(account), CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,claimsPrincipal);//luu xuong cookie
        }

        public async void SignOut(HttpContext httpContext)
        {
            await httpContext.SignOutAsync();
        }
    }
}
