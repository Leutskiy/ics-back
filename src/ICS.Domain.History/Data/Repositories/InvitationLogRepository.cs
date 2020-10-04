using ICS.Domain.Data.Adapters;
using ICS.Domain.Data.Repositories.Contracts;
using ICS.Domain.Entities;
using ICS.Domain.Enums;
using ICS.Domain.Services.Contracts;
using ICS.Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ICS.Domain.Data.Repositories
{
    /// <summary>
    /// Репозиторий логов приглашений
    /// </summary>
    public sealed class InvitationLogRepository : IInvitationLogRepository
    {
        private readonly IIdGenerator _idGenerator;
        private readonly DomainLogContext _context;

        public InvitationLogRepository(
            IIdGenerator idGenerator,
            DomainLogContext domainLogContext)
        {
            _idGenerator = idGenerator ?? throw new ArgumentNullException(nameof(idGenerator));
            _context = domainLogContext ?? throw new ArgumentNullException(nameof(domainLogContext));
        }

        /// <summary>
        /// Получить все логи приглашений
        /// </summary>
        /// <returns>Логи приглашений</returns>
        public async Task<IEnumerable<InvitationLog>> GetAllAsync()
        {
            var invitationLogs = await _context.Set<InvitationLog>().ToArrayAsync().ConfigureAwait(false);

            return invitationLogs;
        }

        /// <summary>
        /// Получить лог приглашения по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор лога приглашения</param>
        /// <returns>Лог приглашения</returns>
        public async Task<InvitationLog> GetAsync(Guid id)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));

            var invitationLog = await _context.Set<InvitationLog>().FindAsync(id).ConfigureAwait(false);

            if (invitationLog == null)
            {
                throw new Exception($"Сущность не найдена для id: {id}");
            }

            return invitationLog;
        }

        /// <summary>
        /// Создать лог приглашения
        /// </summary>
        /// <param name="alienId">Идентификатор иностранца</param>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <param name="visitDetailId">Идентификатор деталей визита</param>
        /// <param name="createdDate">Дата создания</param>
        /// <param name="updateDate">Дата изменения</param>
        /// <param name="invitationStatus">Статус приглашения</param>
        /// <param name="revisionNumber">Номер ревизии</param>
        /// <returns>Идентификатор лога приглашения</returns>
        public Guid Create(
            Guid alienId,
            Guid employeeId,
            Guid visitDetailId,
            DateTime createdDate,
            DateTime updateDate,
            InvitationStatus invitationStatus,
            long revisionNumber)
        {
            Contract.Argument.IsNotEmptyGuid(alienId, nameof(alienId));
            Contract.Argument.IsNotEmptyGuid(employeeId, nameof(employeeId));
            Contract.Argument.IsNotEmptyGuid(visitDetailId, nameof(visitDetailId));

            Contract.Argument.IsValidIf(createdDate <= updateDate, $"{nameof(createdDate)}:{createdDate} < {nameof(updateDate)}:{updateDate}");
            Contract.Argument.IsValidIf(revisionNumber > 0, $"{nameof(revisionNumber)} > 0");

            var createdInvitationLog = _context.Set<InvitationLog>().Create();
            var id = _idGenerator.Generate();
            createdInvitationLog.Initialize(
                id: id,
                alienId: alienId, 
                employeeId: employeeId,
                visitDetailId: visitDetailId,
                createdDate: createdDate,
                updateDate: updateDate,
                status: invitationStatus,
                revisionNumber: revisionNumber);

            var newInvitationLog = _context.Set<InvitationLog>().Add(createdInvitationLog);

            return newInvitationLog.Id;
        }
    }
}