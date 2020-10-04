﻿using ICS.Domain.Entities;
using System;

namespace ICS.WebApplication.Commands.Read.Results
{
    /// <summary>
    /// Данные по деталям визита
    /// </summary>
    public sealed class VisitDetailResult
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор приглашения
        /// </summary>
        public Guid InvitationId { get; set; }

        /// <summary>
        /// Цель визита
        /// </summary>
        public string Goal { get; set; }

        /// <summary>
        /// Страна визита
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Пункты посещения
        /// </summary>
        public string VisitingPoints { get; set; }

        /// <summary>
        /// Период пребывания
        /// </summary>
        public long PeriodInDays { get; set; }

        /// <summary>
        /// Дата пребытия
        /// </summary>
        public DateTime ArrivalDate { get; set; }

        /// <summary>
        /// Дата депортации
        /// </summary>
        public DateTime DepartureDate { get; set; }

        /// <summary>
        /// Вид визы
        /// </summary>
        public string VisaType { get; set; }

        /// <summary>
        /// Город получения визы
        /// </summary>
        public string VisaCity { get; set; }

        /// <summary>
        /// Страна получения визы
        /// </summary>
        public string VisaCountry { get; set; }

        /// <summary>
        /// Кратность визы
        /// </summary>
        public VisaMultiplicity VisaMultiplicity { get; set; }
    }
}