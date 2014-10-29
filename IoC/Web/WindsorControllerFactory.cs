using System;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;

namespace Web
{
    class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IWindsorContainer _container;

        public WindsorControllerFactory(IWindsorContainer container)
        {
            _container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null || !typeof(IController).IsAssignableFrom(controllerType))
                return base.GetControllerInstance(requestContext, controllerType);

            try
            {
                return (IController)_container.Resolve(controllerType);
            }
            catch
            {
                return base.GetControllerInstance(requestContext, controllerType);
            }
        }

        public override void ReleaseController(IController controller)
        {
            _container.Release(controller);
        }
    }
}
