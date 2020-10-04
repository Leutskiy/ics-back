using ICS.Domain.Enums;
using ICS.Shared;
using System;

namespace ICS.Domain.Entities
{
    /// <summary>
    /// Логи документа
    /// </summary>
    public class DocumentLog
    {
        protected DocumentLog()
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
        /// Идентификатор приглашения
        /// </summary>
        public virtual Guid InvitationId { get; protected set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public virtual string Name { get; protected set; }

        /// <summary>
        /// Содержимое
        /// </summary>
        public virtual byte[] Content { get; protected set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public virtual DateTime CreatedDate { get; protected set; }

        /// <summary>
        /// Дата изменения
        /// </summary>
        public virtual DateTime UpdateDate { get; protected set; }

        /// <summary>
        /// Тип документа
        /// </summary>
        public virtual DocumentType DocumentType { get; protected set; }

        /// <summary>
        /// Инициализировать логи документа
        /// </summary>
        public void Initialize(
            Guid id,
            Guid invitationId,
            string name,
            byte[] content,
            DateTime createdDate,
            DateTime updateDate,
            DocumentType documentType,
            long revisionNumber)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));
            Contract.Argument.IsNotEmptyGuid(invitationId, nameof(invitationId));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(name, nameof(name));
            Contract.Argument.IsNotNull(content, nameof(content));
            Contract.Argument.IsValidIf(createdDate <= updateDate, $"{nameof(createdDate)}:{createdDate} < {nameof(updateDate)}:{updateDate}");

            Contract.Argument.IsValidIf(revisionNumber > 0, $"{nameof(revisionNumber)} > 0");

            Id = id;

            InvitationId = invitationId;
            Name = name;
            Content = content;
            CreatedDate = createdDate;
            UpdateDate = updateDate;
            DocumentType = documentType;

            RevisionNumber = revisionNumber;
        }
    }
}