using ICS.Domain.Data.Adapters;
using ICS.Domain.Data.Repositories.Contracts;
using ICS.Domain.Entities;
using ICS.Domain.Services.Contracts;
using ICS.Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ICS.Domain.Data.Repositories
{
    /// <summary>
    /// Репозиторий логов иностранных участников
    /// </summary>
    public sealed class ForeignParticipantLogRepository : IForeignParticipantLogRepository
    {
        private readonly IIdGenerator _idGenerator;
        private readonly DomainLogContext _context;

        public ForeignParticipantLogRepository(
            IIdGenerator idGenerator,
            DomainLogContext domainLogContext)
        {
            _idGenerator = idGenerator ?? throw new ArgumentNullException(nameof(idGenerator));
            _context = domainLogContext ?? throw new ArgumentNullException(nameof(domainLogContext));
        }

        /// <summary>
        /// Получить все логи иностранных участников
        /// </summary>
        /// <returns>Логи иностранных участников</returns>
        public async Task<IEnumerable<ForeignParticipantLog>> GetAllAsync()
        {
            var foreignParticipantLogs = await _context.Set<ForeignParticipantLog>().ToArrayAsync().ConfigureAwait(false);

            return foreignParticipantLogs;
        }

        /// <summary>
        /// Получить логи иностранного участника по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор логов иностранного участника</param>
        /// <returns>Лог иностранного участника</returns>
        public async Task<ForeignParticipantLog> GetAsync(Guid id)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));

            var foreignParticipantLog = await _context.Set<ForeignParticipantLog>().FindAsync(id).ConfigureAwait(false);

            if (foreignParticipantLog == null)
            {
                throw new Exception($"Сущность не найдена для id: {id}");
            }

            return foreignParticipantLog;
        }

        /// <summary>
        /// Создать лог иностранного участника
        /// </summary>
        /// <param name="alienId">Идентификатор иностранца</param>
        /// <param name="passportId">Идентификатор паспорта</param>
        /// <param name="revisionNumber">Номер ревизи</param>
        /// <returns>Идентификатор лога инстранного участника</returns>
        public Guid Create(
            Guid alienId,
            Guid passportId,
            long revisionNumber)
        {
            Contract.Argument.IsNotEmptyGuid(alienId, nameof(alienId));
            Contract.Argument.IsNotEmptyGuid(passportId, nameof(passportId));

            Contract.Argument.IsValidIf(revisionNumber > 0, $"{nameof(revisionNumber)} > 0");

            var createdForeignParticipantLog = _context.Set<ForeignParticipantLog>().Create();
            var id = _idGenerator.Generate();
            createdForeignParticipantLog.Initialize(
                id: id,
                alienId: alienId,
                passportId: passportId,
                revisionNumber: revisionNumber);

            var newForeignParticipantLog = _context.Set<ForeignParticipantLog>().Add(createdForeignParticipantLog);

            return newForeignParticipantLog.Id;
        }
    }
}