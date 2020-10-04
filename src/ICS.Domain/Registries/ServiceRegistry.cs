using ICS.Domain.Services;
using ICS.Domain.Services.Contracts;
using StructureMap;

namespace ICS.Domain.Registries
{
    public sealed class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            For<IClock>().Use<SystemClock>();
            For<IIdGenerator>().Use<IdGenerator>();
            For<IUserInfoProvider>().Use<UserInfoProvider>();
            For<IAlienService>().Use<AlienService>();
            For<IContactService>().Use<ContactService>();
            For<IEmployeeService>().Use<EmployeeService>();
            For<IPassportService>().Use<PassportService>();
            For<IInvitationService>().Use<InvitationService>();
            For<IVisitDetailService>().Use<VisitDetailService>();
            For<IOrganizationService>().Use<OrganizationService>();
            For<IStateRegistrationService>().Use<StateRegistrationService>();
            For<IForeignParticipantService>().Use<ForeignParticipantService>();
        }
    }
}