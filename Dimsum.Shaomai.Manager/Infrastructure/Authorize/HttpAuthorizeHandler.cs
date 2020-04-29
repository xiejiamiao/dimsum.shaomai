using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace Dimsum.Shaomai.Manager.Infrastructure.Authorize
{
    public class HttpAuthorizeHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public HttpAuthorizeHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task SignInAsync(Guid managerUserId, CancellationToken cancellationToken = default)
        {
            var claims = new[]
            {
                new Claim("ManagerUserId", managerUserId.ToString())
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var user = new ClaimsPrincipal(claimsIdentity);
            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user,
                new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                    AllowRefresh = true
                });
        }

        public async Task SignOutAsync()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync();
        }

        public Guid GetUseIdFromCookie()
        {
            var cookieItem = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "ManagerUserId");
            if (cookieItem != null)
            {
                return Guid.Parse(cookieItem.Value);
            }
            else
            {
                throw new ArgumentNullException(nameof(cookieItem));
            }
        }
    }
}
