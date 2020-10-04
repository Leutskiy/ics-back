using ICS.Domain.Data.Adapters;
using StructureMap;

namespace ICS.Domain.Registries
{
    public sealed class AdapterRegistry : Registry
    {
        public AdapterRegistry()
        {
            ForConcreteType<DomainContext>()
                .Configure
                .Ctor<string>("nameOrConnectionString")
                .Is("PostgreSQLConnection")
                .Transient();

            ForConcreteType<SystemContext>()
                .Configure
                .Ctor<string>("nameOrConnectionString")
                .Is("PostgreSQLConnection")
                .Transient();
        }
    }
}