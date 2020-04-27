using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthenticationExample.Authentication
{
    public class FakeAuthenticationStateProvider : AuthenticationStateProvider, ILoginService
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

        public async Task Login(UserInfo userInfo)
        {
            await Task.Delay(3000);
            NotifyAuthenticationStateChanged(Task.FromResult(BuildAuthenticatedState(userInfo)));
        }

        public async Task LogOut()
        {
            await Task.Delay(3000);
            NotifyAuthenticationStateChanged(Task.FromResult(BuildAnonymousState()));
        }

        private AuthenticationState BuildAuthenticatedState(UserInfo userInfo)
        {
            var identity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, userInfo.Name), new Claim(ClaimTypes.Role, userInfo.Role)
            }, "Teste");
            var user = new ClaimsPrincipal(identity);

            return new AuthenticationState(user);
        }

        private AuthenticationState BuildAnonymousState()
        {
            var identity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Guilherme Henrique"), new Claim(ClaimTypes.Role, "admin")
            });
            var user = new ClaimsPrincipal(identity);

            return new AuthenticationState(user);
        }
    }
}
