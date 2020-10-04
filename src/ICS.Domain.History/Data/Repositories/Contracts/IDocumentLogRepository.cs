using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ICS.Domain.Entities;
using ICS.Domain.Enums;

namespace ICS.Domain.Repositories.Contracts
{
    public interface IDocumentLogRepository
    {
        Task<IEnumerable<DocumentLog>> GetAllAsync();

        Task<DocumentLog> GetAsync(Guid id);

        Guid Create(
            Guid invitationId,
            string name,
            byte[] content,
            DateTime createdDate,
            DateTime updateDate,
            DocumentType documentType,
            long revisionNumber);
    }
}