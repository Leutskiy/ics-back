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
    /// Репозиторий логов организаций
    /// </summary>
    public sealed class OrganizationLogRepository : IOrganizationLogRepository
    {
        private readonly IIdGenerator _idGenerator;
        private readonly DomainLogContext _context;

        public OrganizationLogRepository(
            IIdGenerator idGenerator,
            DomainLogContext domainLogContext)
        {
            _idGenerator = idGenerator ?? throw new ArgumentNullException(nameof(idGenerator));
            _context = domainLogContext ?? throw new ArgumentNullException(nameof(domainLogContext));
        }

        /// <summary>
        /// Получить все логи организаций
        /// </summary>
        /// <returns>Логи организаций</returns>
        public async Task<IEnumerable<OrganizationLog>> GetAllAsync()
        {
            var organizationLogs = await _context.Set<OrganizationLog>().ToArrayAsync().ConfigureAwait(false);

            return organizationLogs;
        }

        /// <summary>
        /// Получить лог организации по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор лога организации</param>
        /// <returns>Лог организации</returns>
        public async Task<OrganizationLog> GetAsync(Guid id)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));

            var organizationLog = await _context.Set<OrganizationLog>().FindAsync(id).ConfigureAwait(false);

            if (organizationLog == null)
            {
                throw new Exception($"Сущность не найдена для id: {id}");
            }

            return organizationLog;
        }

        /// <summary>
        /// Создать лог организации
        /// </summary>
        /// <param name="stateRegistrationId">Идентификатор государственной регистрации</param>
        /// <param name="name">Наименование</param>
        /// <param name="shortName">Короткое наименование</param>
        /// <param name="legalAddress">Юридический адрес</param>
        /// <param name="scientificActivity">Научная деятельность</param>
        /// <param name="revisionNumber">Номер ревизии</param>
        /// <returns>Идентификатор лога организации</returns>
        public Guid Create(
            Guid stateRegistrationId,
            string name,
            string shortName,
            string legalAddress,
            string scientificActivity,
            long revisionNumber)
        {
            Contract.Argument.IsNotEmptyGuid(stateRegistrationId, nameof(stateRegistrationId));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(name, nameof(name));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(shortName, nameof(shortName));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(scientificActivity, nameof(scientificActivity));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(legalAddress, nameof(legalAddress));

            Contract.Argument.IsValidIf(revisionNumber > 0, $"{nameof(revisionNumber)} > 0");

            var createdOrganizationLog = _context.Set<OrganizationLog>().Create();
            var id = _idGenerator.Generate();
            createdOrganizationLog.Initialize(
                id: id,
                stateRegistrationId: stateRegistrationId,
                name: name,
                shortName: shortName,
                scientificActivity: scientificActivity,
                legalAddress: legalAddress,
                revisionNumber: revisionNumber);

            var newOrganizationLog = _context.Set<OrganizationLog>().Add(createdOrganizationLog);

            return newOrganizationLog.Id;
        }
    }
}