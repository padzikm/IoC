using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Domain;

namespace Database
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUserRepository>().ImplementedBy<UserRepository>());
            container.Register(Component.For<ILogRepository>().ImplementedBy<LogRepository>());
        }
    }
}
