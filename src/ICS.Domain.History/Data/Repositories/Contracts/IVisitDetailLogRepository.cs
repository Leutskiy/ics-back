using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ICS.Domain.Entities;

namespace ICS.Domain.Data.Repositories
{
    public interface IVisitDetailLogRepository
    {
        Task<IEnumerable<VisitDetailLog>> GetAllAsync();

        Task<VisitDetailLog> GetAsync(Guid id);

        Guid Create(
            string goal,
            string country,
            string visitingPoints,
            TimeSpan period,
            DateTime arrivalDate,
            DateTime departureDate,
            string visaType,
            string visaCity,
            string visaCountry,
            VisaMultiplicity visaMultiplicity,
            long revisionNumber);
    }
}