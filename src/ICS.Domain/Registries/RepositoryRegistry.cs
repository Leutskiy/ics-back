using ICS.Domain.Data.Repositories;
using ICS.Domain.Data.Repositories.Contracts;
using ICS.Domain.Repositories;
using ICS.Domain.Repositories.Contracts;
using StructureMap;

namespace ICS.Domain.Registries
{
    public sealed class RepositoryRegistry : Registry
    {
        public RepositoryRegistry()
        {
            For<IUserRepository>().Use<UserRepository>();
            For<IProfileRepository>().Use<ProfileRepository>();

            For<IAlienRepository>().Use<AlienRepository>();
            For<IContactRepository>().Use<ContactRepository>();
            For<IPassportRepository>().Use<PassportRepository>();
            For<IEmployeeRepository>().Use<EmployeeRepository>();
            For<IDocumentRepository>().Use<DocumentRepository>();
            For<IInvitationRepository>().Use<InvitationRepository>();
            For<IVisitDetailRepository>().Use<VisitDetailRepository>();
            For<IOrganizationRepository>().Use<OrganizationRepository>();
            For<IStateRegistrationRepository>().Use<StateRegistrationRepository>();
            For<IForeignParticipantRepository>().Use<ForeignParticipantRepository>();
        }
    }
}