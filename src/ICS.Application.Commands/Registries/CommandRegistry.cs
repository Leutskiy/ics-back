using ICS.WebApplication.Commands.Read;
using ICS.WebApplication.Commands.Read.Contracts;
using ICS.WebApplication.Commands.Read.Results;
using StructureMap;

namespace ICS.WebApplication.Commands.Registries
{
    public sealed class CommandRegistry : Registry
    {
        public CommandRegistry()
        {
            For<IReadCommand<ProfileResult>>().Use<ProfileReadCommand>();
            For<IReadCommand<AlienResult>>().Use<AlienReadCommand>();
            For<IReadCommand<ContactResult>>().Use<ContactReadCommand>();
            For<IReadCommand<DocumentResult>>().Use<DocumentReadCommand>();
            For<IReadCommand<PassportResult>>().Use<PassportReadCommand>();
            For<IReadCommand<EmployeeResult>>().Use<EmployeeReadCommand>();
            For<IReadCommand<InvitationResult>>().Use<InvitationReadCommand>();
            For<IReadCommand<VisitDetailResult>>().Use<VisitDetailReadCommand>();
            For<IReadCommand<OrganizationResult>>().Use<OrganizationReadCommand>();
            For<IReadCommand<StateRegistrationResult>>().Use<StateRegistrationReadCommand>();
            For<IReadCommand<ForeignParticipantResult>>().Use<ForeignParticipantReadCommand>();
            For<UserReadCommand>().Use<UserReadCommand>();
            For<EmployeeWriteCommand>().Use<EmployeeWriteCommand>();
        }
    }
}