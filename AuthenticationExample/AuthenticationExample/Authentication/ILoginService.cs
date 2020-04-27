using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationExample.Authentication
{
    public interface ILoginService
    {
        Task Login(UserInfo userInfo);
        Task LogOut();
    }
}
