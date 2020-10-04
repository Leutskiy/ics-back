using System.Web.Http;

namespace ICS.WebApp.App_Start
{
    public sealed class ContainerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            /*
            var mainRegistry = new Registry();

            mainRegistry.IncludeRegistry<DefaultRegistry>();
            mainRegistry.IncludeRegistry<ServiceRegistry>();
            mainRegistry.IncludeRegistry<CommandRegistry>();
            mainRegistry.IncludeRegistry<AdapterRegistry>();
            mainRegistry.IncludeRegistry<RepositoryRegistry>();

            var container = IoC.Initialize(mainRegistry);
            */

            /*config.DependencyResolver = new StructureMapDependencyResolver(container);*/
        }
    }
}