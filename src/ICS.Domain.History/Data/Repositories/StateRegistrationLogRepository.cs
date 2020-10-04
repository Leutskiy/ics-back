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
    /// Репозиторий логов регистраций государственных номеров
    /// </summary>
    public sealed class StateRegistrationLogRepository : IStateRegistrationLogRepository
    {
        private readonly IIdGenerator _idGenerator;
        private readonly DomainLogContext _context;

        public StateRegistrationLogRepository(
            IIdGenerator idGenerator,
            DomainLogContext domainLogContext)
        {
            _idGenerator = idGenerator ?? throw new ArgumentNullException(nameof(idGenerator));
            _context = domainLogContext ?? throw new ArgumentNullException(nameof(domainLogContext));
        }

        /// <summary>
        /// Получить все логи государственных регистраций
        /// </summary>
        /// <returns>Логи государственных регистраций</returns>
        public async Task<IEnumerable<StateRegistrationLog>> GetAllAsync()
        {
            var stateRegistrationLogs = await _context.Set<StateRegistrationLog>().ToArrayAsync().ConfigureAwait(false);

            return stateRegistrationLogs;
        }

        /// <summary>
        /// Получить лог государственной регистрации по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор лога государственной регистрации</param>
        /// <returns>Лог государственной регистрации</returns>
        public async Task<StateRegistrationLog> GetAsync(Guid id)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));

            var stateRegistrationLog = await _context.Set<StateRegistrationLog>().FindAsync(id).ConfigureAwait(false);

            if (stateRegistrationLog == null)
            {
                throw new Exception($"Сущность не найдена для id: {id}");
            }

            return stateRegistrationLog;
        }

        /// <summary>
        /// Создать лог государственной регистрации
        /// </summary>
        /// <param name="inn">ИНН</param>
        /// <param name="ogrnip"><ОГРНИП/param>
        /// <param name="revisionNumber">Номер ревизии</param>
        /// <returns>Идентификатор лога государственной регистрации</returns>
        public Guid Create(
            string inn,
            string ogrnip,
            long revisionNumber)
        {
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(inn, nameof(inn));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(ogrnip, nameof(ogrnip));

            Contract.Argument.IsValidIf(revisionNumber > 0, $"{nameof(revisionNumber)} > 0");

            var createdStateRegistrationLog = _context.Set<StateRegistrationLog>().Create();

            var id = _idGenerator.Generate();
            createdStateRegistrationLog.Initialize(
                id: id,
                inn: inn,
                ogrnip: ogrnip,
                revisionNumber: revisionNumber);

            var newStateRegistrationLog = _context.Set<StateRegistrationLog>().Add(createdStateRegistrationLog);

            return newStateRegistrationLog.Id;
        }
    }
}