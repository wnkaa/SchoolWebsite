using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SchoolWebsite.Ninject;
using System.Data.Entity;
using SchoolWebsite.Models;
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
    }
}
