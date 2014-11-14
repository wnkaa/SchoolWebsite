using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Ninject.Syntax;
using Ninject.Parameters;
using System.Web.Mvc;
using SchoolWebsite.Helpers;
using SchoolWebsite.Models;
namespace SchoolWebsite.Ninject
{
    public class NinjectDependencyResolver:IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            addBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void addBindings()
        {
            kernel.Bind<IMailSender>().To<EmailHelper>();
        //    kernel.Bind<ILectorsRepository>().To<LectorRepository>();
            
        }
    }
}