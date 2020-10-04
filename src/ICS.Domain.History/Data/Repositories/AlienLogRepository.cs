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
    /// Репозиторий логов иностранцев
    /// </summary>
    public sealed class AlienLogRepository : IAlienLogRepository
    {
        private readonly IIdGenerator _idGenerator;
        private readonly DomainLogContext _context;

        public AlienLogRepository(
            IIdGenerator idGenerator,
            DomainLogContext domainLogContext)
        {
            _idGenerator = idGenerator ?? throw new ArgumentNullException(nameof(idGenerator));
            _context = domainLogContext ?? throw new ArgumentNullException(nameof(domainLogContext));
        }

        /// <summary>
        /// Получить все логи иностранцев
        /// </summary>
        /// <returns>Логи иностранцев</returns>
        public async Task<IEnumerable<AlienLog>> GetAllAsync()
        {
            var alienLogs = await _context.Set<AlienLog>().ToArrayAsync().ConfigureAwait(false);

            return alienLogs;
        }

        /// <summary>
        /// Получить лог иностранца
        /// </summary>
        /// <param name="id">Идентификатор лога иностранца</param>
        /// <returns>Лог иностранца</returns>
        public async Task<AlienLog> GetAsync(Guid alienId, long revisionNumber)
        {
            Contract.Argument.IsNotEmptyGuid(alienId, nameof(alienId));

            var alienLog = await _context.Set<AlienLog>()
                .FirstOrDefaultAsync(alienLogRecord => 
                    alienLogRecord.AlienId == alienId && alienLogRecord.RevisionNumber == revisionNumber).ConfigureAwait(false);

            if (alienLog == null)
            {
                throw new Exception($"Сущность не найдена для id: {alienId}");
            }

            return alienLog;
        }

        /// <summary>
        /// Создать лог иностранца
        /// </summary>
        /// <param name="contactId">Контакт</param>
        /// <param name="passportId">Паспорт</param>
        /// <param name="organizationId">Организация</param>
        /// <param name="stateRegistrationId">Государственная регистрация</param>
        /// <param name="position">Должность</param>
        /// <param name="workPlace">Место работы</param>
        /// <param name="workAddress">Рабочий адрес</param>
        /// <param name="stayAddress">Адрес пребывания</param>
        /// <param name="revisionNumber">Номер ревизии</param>
        /// <returns>Идентификатор лога иностранца</returns>
        public Guid Create(
            Guid alienId,
            Guid contactId,
            Guid passportId,
            Guid organizationId,
            Guid stateRegistrationId,
            string position,
            string workPlace,
            string workAddress,
            string stayAddress,
            long revisionNumber)
        {
            Contract.Argument.IsNotEmptyGuid(contactId, nameof(contactId));
            Contract.Argument.IsNotEmptyGuid(passportId, nameof(passportId));
            Contract.Argument.IsNotEmptyGuid(organizationId, nameof(organizationId));
            Contract.Argument.IsNotEmptyGuid(stateRegistrationId, nameof(stateRegistrationId));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(position, nameof(position));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(workPlace, nameof(workPlace));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(workAddress, nameof(workAddress));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(stayAddress, nameof(stayAddress));

            Contract.Argument.IsValidIf(revisionNumber > 0, $"{nameof(revisionNumber)} > 0");

            var createdAlienLog = _context.Set<AlienLog>().Create();
            var id = _idGenerator.Generate();
            createdAlienLog.Initialize(
                alienId: alienId,
                contactId: contactId,
                passportId: passportId,
                organizationId: organizationId,
                stateRegistrationId: stateRegistrationId,
                position: position,
                workPlace: workPlace,
                workAddress: workAddress,
                stayAddress: stayAddress,
                revisionNumber: revisionNumber);

            var newAlienLog =_context.Set<AlienLog>().Add(createdAlienLog);

            return newAlienLog.AlienId;
        }
    }
}