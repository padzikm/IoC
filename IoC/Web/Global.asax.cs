using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static volatile IWindsorContainer _container;
        private static readonly object _synchRoot = new object();

        protected void Application_Start()
        {
            if (_container == null)
                lock (_synchRoot)
                    if (_container == null)
                    {
                        _container = new WindsorContainer();
                        _container.Install(FromAssembly.InDirectory(new AssemblyFilter(AppDomain.CurrentDomain.RelativeSearchPath)));
                    }

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(_container));
        }
    }
}
