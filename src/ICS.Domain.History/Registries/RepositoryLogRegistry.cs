using ICS.Domain.Data.Repositories;
using ICS.Domain.Data.Repositories.Contracts;
using ICS.Domain.Repositories;
using ICS.Domain.Repositories.Contracts;
using StructureMap;

namespace ICS.Domain.Registries
{
    public sealed class RepositoryLogRegistry : Registry
    {
        public RepositoryLogRegistry()
        {
            For<IAlienLogRepository>().Use<AlienLogRepository>();
            For<IContactLogRepository>().Use<ContactLogRepository>();
            For<IPassportLogRepository>().Use<PassportLogRepository>();
            For<IEmployeeLogRepository>().Use<EmployeeLogRepository>();
            For<IDocumentLogRepository>().Use<DocumentLogRepository>();
            For<IInvitationLogRepository>().Use<InvitationLogRepository>();
            For<IVisitDetailLogRepository>().Use<VisitDetailLogRepository>();
            For<IOrganizationLogRepository>().Use<OrganizationLogRepository>();
            For<IStateRegistrationLogRepository>().Use<StateRegistrationLogRepository>();
            For<IForeignParticipantLogRepository>().Use<ForeignParticipantLogRepository>();
        }
    }
}