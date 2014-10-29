using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Domain;

namespace Web
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            RegisterControllers(container, store);

            container.Register(Component.For<ILogConfiguration>().ImplementedBy<LogConfiguration>().DependsOn(new {Format = "web log: {0}"}));

        }

        private void RegisterControllers(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Types.FromThisAssembly().BasedOn<IController>().LifestyleTransient());
        }
    }
}
