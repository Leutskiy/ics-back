using ICS.Domain.Enums;
using ICS.Shared;
using System;

namespace ICS.Domain.Entities
{
    /// <summary>
    /// Логи приглашения
    /// </summary>
    public class InvitationLog
    {
        protected InvitationLog()
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
        /// Идентификатор иностранца
        /// </summary>
        public virtual Guid AlienId { get; protected set; }

        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public virtual Guid EmployeeId { get; protected set; }

        /// <summary>
        /// Идентификатор деталей поездки по приглашению
        /// </summary>
        public virtual Guid VisitDetailId { get; protected set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public virtual DateTime CreatedDate { get; protected set; }

        /// <summary>
        /// Дата изменения
        /// </summary>
        public virtual DateTime UpdateDate { get; protected set; }

        /// <summary>
        /// Статус
        /// </summary>
        public virtual InvitationStatus Status { get; protected set; }

        /// <summary>
        /// Инициализировать логи приглашения
        /// </summary>
        public void Initialize(
            Guid id,
            Guid alienId,
            Guid employeeId,
            Guid visitDetailId,
            DateTime createdDate,
            DateTime updateDate,
            InvitationStatus status,
            long revisionNumber)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));
            Contract.Argument.IsNotEmptyGuid(alienId, nameof(alienId));
            Contract.Argument.IsNotEmptyGuid(employeeId, nameof(employeeId));
            Contract.Argument.IsNotEmptyGuid(visitDetailId, nameof(visitDetailId));

            Contract.Argument.IsValidIf(revisionNumber > 0, $"{nameof(revisionNumber)} > 0");
            Contract.Argument.IsValidIf(createdDate <= updateDate, $"{nameof(createdDate)}:{createdDate} < {nameof(updateDate)}:{updateDate}");

            Id = id;

            AlienId = alienId;
            EmployeeId = employeeId;
            VisitDetailId = visitDetailId;
            CreatedDate = createdDate;
            UpdateDate = updateDate;
            Status = status;
        }
    }
}