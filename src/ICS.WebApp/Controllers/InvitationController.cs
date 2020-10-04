using ICS.Shared;
using ICS.WebApplication.Commands.Read.Contracts;
using ICS.WebApplication.Commands.Read.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ICS.WebApp.Controllers
{
    /// <summary>
    /// Контроллер приглашений
    /// </summary>
    [Authorize]
    [RoutePrefix("api/v1/invitations")]
    public class InvitationController : ApiController
    {
        private readonly IReadCommand<InvitationResult> _invitationReadCommand;

        public InvitationController(
            IReadCommand<InvitationResult> invitationReadCommand)
        {
            Contract.Argument.IsNotNull(invitationReadCommand, nameof(invitationReadCommand));

            _invitationReadCommand = invitationReadCommand;
        }

        [HttpGet]
        [Route]
        public async Task<IEnumerable<InvitationResult>> GetAll()
        {
            return await _invitationReadCommand.ExecuteAsync().ConfigureAwait(false);
        }

        [HttpGet]
        [Route("invitation/{invitationId:guid}")]
        public async Task<InvitationResult> GetById(Guid invitationId)
        {
            Contract.Argument.IsNotEmptyGuid(invitationId, nameof(invitationId));

            return await _invitationReadCommand.ExecuteAsync(invitationId).ConfigureAwait(false);
        }
    }
}