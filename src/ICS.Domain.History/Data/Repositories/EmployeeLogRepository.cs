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
    /// Репозиторий логов сотрудников
    /// </summary>
    public sealed class EmployeeLogRepository : IEmployeeLogRepository
    {
        private readonly IIdGenerator _idGenerator;
        private readonly DomainLogContext _context;

        public EmployeeLogRepository(
            IIdGenerator idGenerator,
            DomainLogContext domainLogContext)
        {
            _idGenerator = idGenerator ?? throw new ArgumentNullException(nameof(idGenerator));
            _context = domainLogContext ?? throw new ArgumentNullException(nameof(domainLogContext));
        }

        /// <summary>
        /// Получить все логи сотрудников
        /// </summary>
        /// <returns>Логи сотрудников</returns>
        public async Task<IEnumerable<EmployeeLog>> GetAllAsync()
        {
            var employeeLogs = await _context.Set<EmployeeLog>().ToArrayAsync().ConfigureAwait(false);

            return employeeLogs;
        }

        /// <summary>
        /// Получить лог сотрудника по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор лога сотрудника</param>
        /// <returns>Лог сотрудника</returns>
        public async Task<EmployeeLog> GetAsync(Guid id)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));

            var employeeLog = await _context.Set<EmployeeLog>().FindAsync(id).ConfigureAwait(false);

            if (employeeLog == null)
            {
                throw new Exception($"Сущность не найдена для id: {id}");
            }

            return employeeLog;
        }

        /// <summary>
        /// Создать лог сотрудника
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="manager">Руководитель</param>
        /// <param name="contact">Контактные данные</param>
        /// <param name="passport">Паспортные данные</param>
        /// <param name="organization">Организация</param>
        /// <param name="stateRegistration">Государственная регистрация</param>
        /// <param name="workPlace">Место работы</param>
        /// <param name="position">Должность</param>
        /// <returns>Идентификатор лога сотрудника</returns>
        public Guid Create(
            Guid userId,
            Guid? managerId,
            Guid contactId,
            Guid passportId,
            Guid organizationId,
            Guid stateRegistrationId,
            string workPlace,
            string position,
            long revisionNumber)
        {
            Contract.Argument.IsNotEmptyGuid(userId, nameof(userId));
            Contract.Argument.IsNotEmptyGuid(contactId, nameof(contactId));
            Contract.Argument.IsNotEmptyGuid(passportId, nameof(passportId));
            Contract.Argument.IsNotEmptyGuid(organizationId, nameof(organizationId));
            Contract.Argument.IsNotEmptyGuid(stateRegistrationId, nameof(stateRegistrationId));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(workPlace, nameof(workPlace));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(position, nameof(position));

            Contract.Argument.IsValidIf(managerId != Guid.Empty, $"{managerId} != Guid.Empty");
            Contract.Argument.IsValidIf(revisionNumber > 0, $"{nameof(revisionNumber)} > 0");

            var createdEmployeeLog = _context.Set<EmployeeLog>().Create();
            var id = _idGenerator.Generate();
            createdEmployeeLog.Initialize(
                id: id,
                userId: userId,
                managerId: managerId,
                contactId: contactId,
                passportId: passportId,
                organizationId: organizationId,
                stateRegistrationId: stateRegistrationId,
                workPlace: workPlace,
                position: position,
                revisionNumber: revisionNumber);

            var newEmployeeLog = _context.Set<EmployeeLog>().Add(createdEmployeeLog);

            return newEmployeeLog.Id;
        }
    }
}