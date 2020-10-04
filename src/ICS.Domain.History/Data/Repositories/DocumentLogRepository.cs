using ICS.Domain.Data.Adapters;
using ICS.Domain.Entities;
using ICS.Domain.Enums;
using ICS.Domain.Repositories.Contracts;
using ICS.Domain.Services.Contracts;
using ICS.Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ICS.Domain.Repositories
{
    /// <summary>
    /// Репозиторий логов документов
    /// </summary>
    public sealed class DocumentLogRepository : IDocumentLogRepository
    {
        private readonly IIdGenerator _idGenerator;
        private readonly DomainLogContext _context;

        public DocumentLogRepository(
            IIdGenerator idGenerator,
            DomainLogContext domainLogContext)
        {
            _idGenerator = idGenerator ?? throw new ArgumentNullException(nameof(idGenerator));
            _context = domainLogContext ?? throw new ArgumentNullException(nameof(domainLogContext));
        }

        /// <summary>
        /// Получить все логи документов
        /// </summary>
        /// <returns>Логи документов</returns>
        public async Task<IEnumerable<DocumentLog>> GetAllAsync()
        {
            var documentLogs = await _context.Set<DocumentLog>().ToArrayAsync().ConfigureAwait(false);

            return documentLogs;
        }

        /// <summary>
        /// Получить лог документа по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор лога документа</param>
        /// <returns>Лог документа</returns>
        public async Task<DocumentLog> GetAsync(Guid id)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));

            var documentLog = await _context.Set<DocumentLog>().FindAsync(id).ConfigureAwait(false);

            if (documentLog == null)
            {
                throw new Exception($"Сущность не найдена для id: {id}");
            }

            return documentLog;
        }

        /// <summary>
        /// Создать лог документа
        /// </summary>
        /// <param name="invitationId">Идентификатор приглашения</param>
        /// <param name="name">Название</param>
        /// <param name="content">Содержимое</param>
        /// <param name="createdDate">Дата создания</param>
        /// <param name="updateDate">Дата изменения</param>
        /// <param name="documentType">Тип документа</param>
        /// <param name="revisionNumber">Номер ревизии</param>
        /// <returns>Идентификатор лога документа</returns>
        public Guid Create(
            Guid invitationId,
            string name,
            byte[] content,
            DateTime createdDate,
            DateTime updateDate,
            DocumentType documentType,
            long revisionNumber)
        {
            Contract.Argument.IsNotEmptyGuid(invitationId, nameof(invitationId));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(name, nameof(name));
            Contract.Argument.IsNotNull(content, nameof(content));

            Contract.Argument.IsValidIf(createdDate <= updateDate, $"{nameof(createdDate)}:{createdDate} < {nameof(updateDate)}:{updateDate}");
            Contract.Argument.IsValidIf(revisionNumber > 0, $"{nameof(revisionNumber)} > 0");

            var createdDocumentLog = _context.Set<DocumentLog>().Create();
            var id = _idGenerator.Generate();
            createdDocumentLog.Initialize(
                id: id,
                invitationId: invitationId,
                name: name,
                content: content,
                createdDate: createdDate,
                updateDate: updateDate,
                documentType: documentType,
                revisionNumber: revisionNumber);

            var newDocumentLog = _context.Set<DocumentLog>().Add(createdDocumentLog);

            return newDocumentLog.Id;
        }
    }
}