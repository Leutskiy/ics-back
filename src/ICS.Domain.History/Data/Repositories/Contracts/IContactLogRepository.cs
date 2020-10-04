using ICS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICS.Domain.Data.Repositories.Contracts
{
    public interface IContactLogRepository
    {
        Task<IEnumerable<ContactLog>> GetAllAsync();

        Task<ContactLog> GetAsync(Guid id);

        Guid Create(
            string email,
            string postcode,
            string homePhoneNumber,
            string workPhoneNumber,
            string mobilePhoneNumber,
            long revisionNumber);
    }
}