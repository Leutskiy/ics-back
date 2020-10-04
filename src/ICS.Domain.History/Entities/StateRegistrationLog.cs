using ICS.Shared;
using System;

namespace ICS.Domain.Entities
{
    /// <summary>
    /// Государственная регистрация
    /// </summary>
    public class StateRegistrationLog
    {
        protected StateRegistrationLog()
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
        /// ИНН
        /// </summary>
        public virtual string Inn { get; protected set; }

        /// <summary>
        /// ОГРНИП
        /// </summary>
        public virtual string Ogrnip { get; protected set; }

        /// <summary>
        /// Инициализировать логи государственной регистрации
        /// </summary>
        public void Initialize(
            Guid id,
            string inn,
            string ogrnip,
            long revisionNumber)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(inn, nameof(inn));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(ogrnip, nameof(ogrnip));

            Contract.Argument.IsValidIf(revisionNumber > 0, $"{nameof(revisionNumber)} > 0");

            Id = id;

            Inn = inn;
            Ogrnip = ogrnip;
        }
    }
}