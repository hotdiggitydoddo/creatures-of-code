using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using JotAThought.Domain.Contracts;

namespace JotAThought.Web.Services
{
    public class FormsAuthService : IFormsAuthentication
    {

        public void SignIn(string username, bool createPersistentCookie, IEnumerable<string> roles)
        {
            var str = string.Join(",", roles);

            var authTicket = new FormsAuthenticationTicket(
                                    1, 
                                    username, 
                                    DateTime.Now, 
                                    DateTime.Now.AddMinutes(30), 
                                    createPersistentCookie, 
                                    str, 
                                    "/");

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket));

            if (authTicket.IsPersistent)
                cookie.Expires = authTicket.Expiration;

            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}