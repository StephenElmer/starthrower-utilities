using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarThrower.Providers.TestWebApp.Common
{
    public interface IFormsAuthenticationService
    {
        void SignIn(string userName, bool createPersistentCookie);
        void SignOut();
    }
}