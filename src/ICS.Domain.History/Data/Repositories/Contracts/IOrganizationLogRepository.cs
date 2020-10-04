using ICS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICS.Domain.Data.Repositories.Contracts
{
    public interface IOrganizationLogRepository
    {
        Task<OrganizationLog> GetAsync(Guid id);

        Task<IEnumerable<OrganizationLog>> GetAllAsync();

        Guid Create(
           Guid stateRegistrationId,
           string name,
           string shortName,
           string legalAddress,
           string scientificActivity,
           long revisionNumber);
    }
}