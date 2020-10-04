using ICS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICS.Domain.Data.Repositories.Contracts
{
    public interface IEmployeeLogRepository
    {
        Task<IEnumerable<EmployeeLog>> GetAllAsync();

        Task<EmployeeLog> GetAsync(Guid id);

        Guid Create(
            Guid userId,
            Guid? managerId,
            Guid contactId,
            Guid passportId,
            Guid organizationId,
            Guid stateRegistrationId,
            string workPlace,
            string position,
            long revisionNumber);
    }
}