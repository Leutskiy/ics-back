using ICS.Shared;
using System;

namespace ICS.Domain.Entities
{
    /// <summary>
    /// Логи деталей визита
    /// </summary>
    public class VisitDetailLog
    {
        protected VisitDetailLog()
        {
        }

        /// <summary>
        /// Номер ревизии
        /// </summary>
        public virtual long RevisionNumber { get; protected set; }

        /// <summary>
        /// Идентификатор
        /// </summary>
        public virtual Guid Id { get; protected set; }

        /// <summary>
        /// Цель визита
        /// </summary>
        public virtual string Goal { get; protected set; }

        /// <summary>
        /// Страна визита
        /// </summary>
        public virtual string Country { get; protected set; }

        /// <summary>
        /// Пункты посещения
        /// </summary>
        public virtual string VisitingPoints { get; protected set; }

        /// <summary>
        /// Период пребывания
        /// </summary>
        public virtual TimeSpan Period { get; protected set; }

        /// <summary>
        /// Дата пребытия
        /// </summary>
        public virtual DateTime ArrivalDate  { get; protected set; }

        /// <summary>
        /// Дата депортации
        /// </summary>
        public virtual DateTime DepartureDate { get; protected set; }

        /// <summary>
        /// Вид визы
        /// </summary>
        public virtual string VisaType { get; protected set; }

        /// <summary>
        /// Город получения визы
        /// </summary>
        public virtual string VisaCity { get; protected set; }

        /// <summary>
        /// Страна получения визы
        /// </summary>
        public virtual string VisaCountry { get; protected set; }

        /// <summary>
        /// Кратность визы
        /// </summary>
        public virtual VisaMultiplicity VisaMultiplicity { get; protected set; }

        /// <summary>
        /// Инициализировать логи деталей визита
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="goal">Цель визита</param>
        /// <param name="country">Страна визита</param>
        /// <param name="visitingPoints">Посещаемые пункты</param>
        /// <param name="period">Период пребывания</param>
        /// <param name="arrivalDate">Дата пребытия</param>
        /// <param name="departureDate">Дата депортации</param>
        /// <param name="visaType">Тип визы</param>
        /// <param name="visaCity">Город получения визы</param>
        /// <param name="visaCountry">Страна получения визы</param>
        /// <param name="visaMultiplicity">Кратность визы</param>
        public void Initialize(
            Guid id,
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
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(goal, nameof(goal));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(country, nameof(country));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(visitingPoints, nameof(visitingPoints));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(visaType, nameof(visaType));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(visaCity, nameof(visaCity));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(visaCountry, nameof(visaCountry));

            Contract.Argument.IsValidIf(revisionNumber > 0, $"{nameof(revisionNumber)} > 0");
            Contract.Argument.IsValidIf(period.Days > 0, $"{nameof(period.Days)} > 0");
            Contract.Argument.IsValidIf(arrivalDate < departureDate, $"{nameof(arrivalDate)}:{arrivalDate} < {nameof(departureDate)}:{departureDate}");

            Id = id;

            Goal = goal;
            Country = country;
            VisitingPoints = visitingPoints;
            Period = period;
            ArrivalDate = arrivalDate;
            DepartureDate = departureDate;
            VisaType = visaType;
            VisaCity = visaCity;
            VisaCountry = visaCountry;
            VisaMultiplicity = visaMultiplicity;
            RevisionNumber = revisionNumber;
        }
    }
}