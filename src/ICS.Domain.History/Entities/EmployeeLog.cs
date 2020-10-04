using ICS.Shared;
using System;

namespace ICS.Domain.Entities
{
    /// <summary>
    /// Логи cотрудника
    /// </summary>
    public class EmployeeLog
    {
        protected EmployeeLog()
        {
        }

        /// <summary>
        /// Номер ревизии
        /// </summary>
        public virtual long RevisionNumber { get; set; }

        /// <summary>
        /// Идентификатор
        /// </summary>
        public virtual Guid Id { get; protected set; }

        /// <summary>
        /// Идентификатор руководителя
        /// </summary>
        public virtual Guid? ManagerId { get; protected set; }

        /// <summary>
        /// Идентификатор внутри системы
        /// </summary>
        public virtual Guid UserId { get; protected set; }

        /// <summary>
        /// Идентификатор контактных данных
        /// </summary>
        public virtual Guid ContactId { get; protected set; }

        /// <summary>
        /// Идентификатор паспорта
        /// </summary>
        public virtual Guid PassportId { get; protected set; }

        /// <summary>
        /// Идентификатор организации
        /// </summary>
        public virtual Guid OrganizationId { get; protected set; }

        /// <summary>
        /// Идентификатор государственной регистрации
        /// </summary>
        public virtual Guid StateRegistrationId { get; protected set; }

        /// <summary>
        /// Место работы
        /// </summary>
        public virtual string WorkPlace { get; private set; }

        /// <summary>
        /// Должность
        /// </summary>
        public virtual string Position { get; private set; }

        /// <summary>
        /// Инициализировать логи сотрудника
        /// </summary>
        public void Initialize(
            Guid id,
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
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));
            Contract.Argument.IsNotEmptyGuid(userId, nameof(userId));
            Contract.Argument.IsNotEmptyGuid(contactId, nameof(contactId));
            Contract.Argument.IsNotEmptyGuid(passportId, nameof(passportId));
            Contract.Argument.IsNotEmptyGuid(organizationId, nameof(organizationId));
            Contract.Argument.IsNotEmptyGuid(stateRegistrationId, nameof(stateRegistrationId));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(workPlace, nameof(workPlace));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(position, nameof(position));

            Contract.Argument.IsValidIf(revisionNumber > 0, $"{nameof(revisionNumber)} > 0");
            Contract.Argument.IsValidIf(managerId != Guid.Empty, $"{managerId} != Guid.Empty");

            Id = id;

            UserId = userId;
            ManagerId = managerId;
            ContactId = contactId;
            PassportId = passportId;
            OrganizationId = organizationId;
            StateRegistrationId = stateRegistrationId;
            WorkPlace = workPlace;
            Position = position;
        }
    }
}