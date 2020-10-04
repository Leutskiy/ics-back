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
    /// Репозиторий логов контактов
    /// </summary>
    public sealed class ContactLogRepository : IContactLogRepository
    {
        private readonly IIdGenerator _idGenerator;
        private readonly DomainLogContext _context;

        public ContactLogRepository(
            IIdGenerator idGenerator,
            DomainLogContext domainLogContext)
        {
            _idGenerator = idGenerator ?? throw new ArgumentNullException(nameof(idGenerator));
            _context = domainLogContext ?? throw new ArgumentNullException(nameof(domainLogContext));
        }

        /// <summary>
        /// Получить все логи контактов
        /// </summary>
        /// <returns>Логи контактов</returns>
        public async Task<IEnumerable<ContactLog>> GetAllAsync()
        {
            var contactLogs = await _context.Set<ContactLog>().ToArrayAsync().ConfigureAwait(false);

            return contactLogs;
        }

        /// <summary>
        /// Получить лог контакта
        /// </summary>
        /// <param name="id">Идентификатор лога контакта</param>
        /// <returns>Лог контакта</returns>
        public async Task<ContactLog> GetAsync(Guid id)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));

            var contactLog = await _context.Set<ContactLog>().FindAsync(id).ConfigureAwait(false);

            if (contactLog == null)
            {
                throw new Exception($"Сущность не найдена для id: {id}");
            }

            return contactLog;
        }

        /// <summary>
        /// Создать лог контакта
        /// </summary>
        /// <param name="email">Электронный адрес</param>
        /// <param name="postcode">Почтовый индекс</param>
        /// <param name="homePhoneNumber">Домашний номер телефона</param>
        /// <param name="workPhoneNumber">Рабочий номер телефона</param>
        /// <param name="mobilePhoneNumber">Мобильный номер телефона</param>
        /// <returns>Идентификатор лога контакта</returns>
        public Guid Create(
            string email,
            string postcode,
            string homePhoneNumber,
            string workPhoneNumber,
            string mobilePhoneNumber,
            long revisionNumber)
        {
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(email, nameof(email));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(postcode, nameof(postcode));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(homePhoneNumber, nameof(homePhoneNumber));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(workPhoneNumber, nameof(workPhoneNumber));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(mobilePhoneNumber, nameof(mobilePhoneNumber));

            Contract.Argument.IsValidIf(revisionNumber > 0, $"{nameof(revisionNumber)} > 0");

            var createdContactLog = _context.Set<ContactLog>().Create();
            var id = _idGenerator.Generate();
            createdContactLog.Initialize(
                id: id,
                email: email,
                postcode: postcode,
                homePhoneNumber: homePhoneNumber,
                workPhoneNumber: workPhoneNumber,
                mobilePhoneNumber: mobilePhoneNumber,
                revisionNumber: revisionNumber);

            var newContactLog = _context.Set<ContactLog>().Add(createdContactLog);

            return newContactLog.Id;
        }
    }
}