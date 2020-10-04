using ICS.Shared;
using System;

namespace ICS.Domain.Entities
{
    /// <summary>
    /// Логи иностранца
    /// </summary>
    public class AlienLog
    {
        protected AlienLog()
        {
        }

        /// <summary>
        /// Номер ревизии
        /// </summary>
        public virtual long RevisionNumber { get; set; }

        /// <summary>
        /// Идентификатор иностранца
        /// </summary>
        public virtual Guid AlienId { get; protected set; }

        /// <summary>
        /// Идентификатор контактных данных
        /// </summary>
        public virtual Guid ContactId { get; protected set; }

        /// <summary>
        /// Идентификатор паспортных данных
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
        /// Должность
        /// </summary>
        public virtual string Position { get; protected set; }

        /// <summary>
        /// Место работы
        /// </summary>
        public virtual string WorkPlace { get; protected set; }

        /// <summary>
        /// Адрес работы
        /// </summary>
        public virtual string WorkAddress { get; protected set; }

        /// <summary>
        /// Адрес пребывания
        /// </summary>
        public virtual string StayAddress { get; protected set; }

        /// <summary>
        /// Инициализировать логи иностранца
        /// </summary>
        /// <param name="alienId">Идентификатор иностранца</param>
        /// <param name="contactId">Идентификактор контактных данных</param>
        /// <param name="passportId">Идентификактор паспортных данных</param>
        /// <param name="organizationId">Идентификактор организации</param>
        /// <param name="stateRegistrationId">Идентификактор государственной регистрации</param>
        /// <param name="position">Должность</param>
        /// <param name="workPlace">Место работы</param>
        /// <param name="workAddress">Адрес места работы</param>
        /// <param name="stayAddress">Адрес пребывания</param>
        public void Initialize(
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
            Contract.Argument.IsNotEmptyGuid(alienId, nameof(alienId));
            Contract.Argument.IsNotEmptyGuid(contactId, nameof(contactId));
            Contract.Argument.IsNotEmptyGuid(passportId, nameof(passportId));
            Contract.Argument.IsNotEmptyGuid(organizationId, nameof(organizationId));
            Contract.Argument.IsNotEmptyGuid(stateRegistrationId, nameof(stateRegistrationId));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(position, nameof(position));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(workPlace, nameof(workPlace));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(workAddress, nameof(workAddress));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(stayAddress, nameof(stayAddress));

            Contract.Argument.IsValidIf(revisionNumber > 0, $"{nameof(revisionNumber)} > 0");

            AlienId = alienId;
            ContactId = contactId;
            PassportId = passportId;
            OrganizationId = organizationId;
            StateRegistrationId = stateRegistrationId;
            Position = position;
            WorkPlace = workPlace;
            WorkAddress = workAddress;
            StayAddress = stayAddress;
        }
    }
}