using ICS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICS.Domain.Data.Repositories.Contracts
{
    public interface IAlienLogRepository
    {
        Task<IEnumerable<AlienLog>> GetAllAsync();

        Task<AlienLog> GetAsync(Guid alienId, long revisionNumber);

        Guid Create(
            Guid alienId,
            Guid contactId,
            Guid passportId,
            Guid organizationId,
            Guid stateRegistrationId,
            string position,
            string workPlace,
            string workAddress,
            string stayAddress,
            long revisionNumber);
    }
}