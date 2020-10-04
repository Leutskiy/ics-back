using ICS.Shared;
using System;

namespace ICS.Domain.Entities
{
    /// <summary>
    /// Логи контактных данных
    /// </summary>
    public class ContactLog
    {
        protected ContactLog()
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
        /// Электронная почта
        /// </summary>
        public virtual string Email { get; protected set; }

        /// <summary>
        /// Индекс
        /// </summary>
        public virtual string Postcode { get; protected set; }

        /// <summary>
        /// Домашний номер телефона
        /// </summary>
        public virtual string HomePhoneNumber { get; protected set; }

        /// <summary>
        /// Рабочий номер телефона
        /// </summary>
        public virtual string WorkPhoneNumber { get; protected set; }

        /// <summary>
        /// Мобильный номер телефона
        /// </summary>
        public virtual string MobilePhoneNumber { get; protected set; }

        /// <summary>
        /// Инициализировать логи контактных данных
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="email">Электронная почта</param>
        /// <param name="postcode">Почтовый индекс</param>
        /// <param name="homePhoneNumber">Домашний номер телефона</param>
        /// <param name="workPhoneNumber">Рабочий номер телефона</param>
        /// <param name="mobilePhoneNumber">Мобильный номер телефона</param>
        public void Initialize(
            Guid id,
            string email,
            string postcode,
            string homePhoneNumber,
            string workPhoneNumber,
            string mobilePhoneNumber,
            long revisionNumber)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(email, nameof(email));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(postcode, nameof(postcode));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(homePhoneNumber, nameof(homePhoneNumber));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(workPhoneNumber, nameof(workPhoneNumber));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(mobilePhoneNumber, nameof(mobilePhoneNumber));

            Contract.Argument.IsValidIf(revisionNumber > 0, $"{nameof(revisionNumber)} > 0");

            Id = id;

            Email = email;
            Postcode = postcode;
            HomePhoneNumber = homePhoneNumber;
            WorkPhoneNumber = workPhoneNumber;
            MobilePhoneNumber = mobilePhoneNumber;
        }
    }
}