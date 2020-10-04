using ICS.Domain.Data.Adapters;
using StructureMap;

namespace ICS.Domain.Registries
{
    public sealed class AdapterLogRegistry : Registry
    {
        public AdapterLogRegistry()
        {
            For<DomainLogContext>().Use(ctx => new DomainLogContext(string.Empty, Constants.Schemes.Log));
        }
    }
}