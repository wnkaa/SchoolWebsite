using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SchoolWebsite.Ninject;
using System.Data.Entity;
using SchoolWebsite.Models;
using System.Web.Security;
namespace SchoolWebsite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new DataBaseInitializer());
            DependencyResolver.SetResolver(new NinjectDependencyResolver());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            if (FormsAuthentication.CookiesSupported == true)
            {
                try
                {
                    string username = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                    string roles = string.Empty;
                    using (Context ctx = new Context())
                    {
                        User user = ctx.Users.SingleOrDefault(u => u.Name == username);
                        roles = user.Roles;
                    }
                    HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(
                        new System.Security.Principal.GenericIdentity(username,"Forms"),roles.Split(';')
                        );
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
