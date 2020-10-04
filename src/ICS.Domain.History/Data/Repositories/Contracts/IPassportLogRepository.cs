using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ICS.Domain.Entities;
using ICS.Domain.Enums;

namespace ICS.Domain.Data.Repositories.Contracts
{
    public interface IPassportLogRepository
    {
        Task<IEnumerable<PassportLog>> GetAllAsync();

        Task<PassportLog> GetAsync(Guid id);

        Guid Create(
            string nameRus,
            string nameEng,
            string surnameRus,
            string surnameEng,
            string patronymicNameRus,
            string patronymicNameEng,
            string birthPlace,
            string birthCountry,
            string citizenship,
            string residence, 
            string residenceCountry,
            string residenceRegion,
            string identityDocument,
            string issuePlace,
            string departmentCode, 
            DateTime birthDate,
            DateTime issueDate,
            Sex gender,
            long revisionNumber);
    }
}