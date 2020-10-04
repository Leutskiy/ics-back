using ICS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICS.Domain.Data.Repositories.Contracts
{
    public interface IForeignParticipantLogRepository
    {
        Task<IEnumerable<ForeignParticipantLog>> GetAllAsync();

        Task<ForeignParticipantLog> GetAsync(Guid id);

        Guid Create(
            Guid alienId,
            Guid passportId,
            long revisionNumber);
    }
}