using StructureMap;
using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dependencies;
using System.Web.Http.Dispatcher;

namespace ICS.WebApp.App_Start
{
    public class StructureMapDependencyResolver : StructureMapScope, IDependencyResolver, IHttpControllerActivator
    {
        private readonly IContainer container;

        public StructureMapDependencyResolver(IContainer container) : base(container)
        {
            this.container = container;
            container.Inject<IHttpControllerActivator>(this);
        }

        public IDependencyScope BeginScope()
        {
            var childContainer = container.GetNestedContainer();
            return new StructureMapScope(childContainer);
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var scope = request.GetDependencyScope();
            return scope.GetService(controllerType) as IHttpController;
        }
    }
}