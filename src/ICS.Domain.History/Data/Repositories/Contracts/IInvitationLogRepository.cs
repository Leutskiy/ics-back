using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ICS.Domain.Entities;
using ICS.Domain.Enums;

namespace ICS.Domain.Data.Repositories.Contracts
{
    public interface IInvitationLogRepository
    {
        Task<InvitationLog> GetAsync(Guid id);

        Task<IEnumerable<InvitationLog>> GetAllAsync();

        Guid Create(
            Guid alienId,
            Guid employeeId,
            Guid visitDetailId,
            DateTime createdDate,
            DateTime updateDate,
            InvitationStatus invitationStatus,
            long revisionNumber);
    }
}