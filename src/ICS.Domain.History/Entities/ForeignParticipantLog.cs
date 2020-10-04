using ICS.Shared;
using System;

namespace ICS.Domain.Entities
{
    /// <summary>
    /// Логи иностранного сопровождающего
    /// </summary>
    public class ForeignParticipantLog
    {
        protected ForeignParticipantLog()
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
        /// Идентификатор сопровождаемого иностранца
        /// </summary>
        public virtual Guid AlienId { get; protected set; }

        /// <summary>
        /// Идентификатор паспорта
        /// </summary>
        public virtual Guid PassportId { get; protected set; }

        /// <summary>
        /// Инициализировать логи иностранного сопровождающего
        /// </summary>
        /// <param name="alienId">Идентификатор сопровождаемого иностранца</param>
        /// <param name="passportId">Идентификатор паспорта</param>
        /// <param name="revisionNumber">Номер ревизии</param>
        public void Initialize(
            Guid id,
            Guid alienId,
            Guid passportId,
            long revisionNumber)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));
            Contract.Argument.IsNotEmptyGuid(alienId, nameof(alienId));
            Contract.Argument.IsNotEmptyGuid(passportId, nameof(passportId));

            Contract.Argument.IsValidIf(revisionNumber > 0, $"{nameof(revisionNumber)} > 0");

            Id = id;

            AlienId = alienId;
            PassportId = passportId;
            RevisionNumber = revisionNumber;
        }
    }
}