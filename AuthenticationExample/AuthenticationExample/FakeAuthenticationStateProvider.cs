using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthenticationExample
{
    public class FakeAuthenticationStateProvider : AuthenticationStateProvider
    {
        public FakeAuthenticationStateProvider()
        {
                
        }
        public  override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            await Task.Delay(3000);
            var identity = new ClaimsIdentity( new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Guilherme Henrique"), new Claim(ClaimTypes.Role, "admin")
            });
            var user = new ClaimsPrincipal(identity);

            return await Task.FromResult(new AuthenticationState(user));
        }
    }
}
