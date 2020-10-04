using ICS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICS.Domain.Data.Repositories.Contracts
{
    public interface IStateRegistrationLogRepository
    {
        Task<StateRegistrationLog> GetAsync(Guid id);

        Task<IEnumerable<StateRegistrationLog>> GetAllAsync();

        Guid Create(
            string inn,
            string ogrnip,
            long revisionNumber);
    }
}