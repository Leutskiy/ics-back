using ICS.Domain.Data.Adapters;
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
    /// Репозиторий логов деталей визита
    /// </summary>
    public sealed class VisitDetailLogRepository : IVisitDetailLogRepository
    {
        private readonly IIdGenerator _idGenerator;
        private readonly DomainLogContext _context;

        public VisitDetailLogRepository(
            IIdGenerator idGenerator,
            DomainLogContext domainLogContext)
        {
            _idGenerator = idGenerator ?? throw new ArgumentNullException(nameof(idGenerator));
            _context = domainLogContext ?? throw new ArgumentNullException(nameof(domainLogContext));
        }

        /// <summary>
        /// Получить все логи деталей визита
        /// </summary>
        /// <returns>Логи деталей визита</returns>
        public async Task<IEnumerable<VisitDetailLog>> GetAllAsync()
        {
            var visitDetailLogs = await _context.Set<VisitDetailLog>().ToArrayAsync().ConfigureAwait(false);

            return visitDetailLogs;
        }

        /// <summary>
        /// Получить лог деталей визита по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор лога деталей визита</param>
        /// <returns>Лог деталей визита</returns>
        public async Task<VisitDetailLog> GetAsync(Guid id)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));

            var visitDetailLog = await _context.Set<VisitDetailLog>().FindAsync(id).ConfigureAwait(false);

            if (visitDetailLog == null)
            {
                throw new Exception($"Сущность не найдена для id: {id}");
            }

            return visitDetailLog;
        }

        /// <summary>
        /// Создать лог деталей визита
        /// </summary>
        /// <param name="goal">Цель визита</param>
        /// <param name="country">Страна визита</param>
        /// <param name="visitingPoints">Пункты посещения</param>
        /// <param name="period">Период пребывания</param>
        /// <param name="arrivalDate">Дата прибытия</param>
        /// <param name="departureDate">Дата отъезда</param>
        /// <param name="visaType">Тип визы</param>
        /// <param name="visaCity">Город получения визы</param>
        /// <param name="visaCountry">Страна получения визы</param>
        /// <param name="visaMultiplicity">Кратность визы</param>
        /// <param name="revisionNumber">Номер ревизии</param>
        /// <returns>Идентификатор лога деталей визита</returns>
        public Guid Create(
            string goal,
            string country,
            string visitingPoints,
            TimeSpan period,
            DateTime arrivalDate,
            DateTime departureDate,
            string visaType,
            string visaCity,
            string visaCountry,
            VisaMultiplicity visaMultiplicity,
            long revisionNumber)
        {
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(goal, nameof(goal));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(country, nameof(country));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(visitingPoints, nameof(visitingPoints));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(visaType, nameof(visaType));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(visaCity, nameof(visaCity));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(visaCountry, nameof(visaCountry));

            Contract.Argument.IsValidIf(period.Days > 0, $"{nameof(period.Days)} > 0");
            Contract.Argument.IsValidIf(revisionNumber > 0, $"{nameof(revisionNumber)} > 0");
            Contract.Argument.IsValidIf(arrivalDate < departureDate, $"{nameof(arrivalDate)}:{arrivalDate} < {nameof(departureDate)}:{departureDate}");

            var createdVisitDetailLog = _context.Set<VisitDetailLog>().Create();

            var id = _idGenerator.Generate();
                createdVisitDetailLog.Initialize(
                    id: id,
                    goal: goal,
                    country: country,
                    visitingPoints: visitingPoints,
                    period: period,
                    arrivalDate: arrivalDate,
                    departureDate: departureDate,
                    visaType: visaType,
                    visaCity: visaCity,
                    visaCountry: visaCountry,
                    visaMultiplicity: visaMultiplicity,
                    revisionNumber: revisionNumber);

            var newVisitDetailLog = _context.Set<VisitDetailLog>().Add(createdVisitDetailLog);

            return newVisitDetailLog.Id;
        }
    }
}