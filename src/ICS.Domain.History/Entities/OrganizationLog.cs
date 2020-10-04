using ICS.Shared;
using System;

namespace ICS.Domain.Entities
{
    /// <summary>
    /// Логи организации
    /// </summary>
    public class OrganizationLog
    {
        protected OrganizationLog()
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
        /// Идентификатор государственной регистрации
        /// </summary>
        public virtual Guid StateRegistrationId { get; protected set; }

        /// <summary>
        /// Полное наименование
        /// </summary>
        public virtual string Name { get; protected set; }

        /// <summary>
        /// Краткое наименование
        /// </summary>
        public virtual string ShortName { get; protected set; }

        /// <summary>
        /// Юридический адрес
        /// </summary>
        public virtual string LegalAddress { get; protected set; }

        /// <summary>
        /// Направление научной деятельности
        /// </summary>
        public virtual string ScientificActivity { get; protected set; }

        /// <summary>
        /// Инициализировать логи организации
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="stateRegistrationId">Идентификатор государственной регистрации</param>
        /// <param name="name">Наименование</param>
        /// <param name="shortName">Короткое наименование</param>
        /// <param name="scientificActivity">Научная деятельность</param>
        /// <param name="legalAddress">Юридический адрес</param>
        public void Initialize(
            Guid id,
            Guid stateRegistrationId,
            string name,
            string shortName,
            string scientificActivity,
            string legalAddress,
            long revisionNumber)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));
            Contract.Argument.IsNotEmptyGuid(stateRegistrationId, nameof(stateRegistrationId));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(name, nameof(name));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(shortName, nameof(shortName));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(scientificActivity, nameof(scientificActivity));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(legalAddress, nameof(legalAddress));

            Contract.Argument.IsValidIf(revisionNumber > 0, $"{nameof(revisionNumber)} > 0");

            Id = id;

            StateRegistrationId = stateRegistrationId;
            Name = name;
            ShortName = shortName;
            ScientificActivity = scientificActivity;
            LegalAddress = legalAddress;
        }
    }
}