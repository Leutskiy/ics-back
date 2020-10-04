using ICS.Domain.Data.Adapters;
using ICS.Domain.Data.Repositories.Contracts;
using ICS.Domain.Entities;
using ICS.Domain.Enums;
using ICS.Domain.Services.Contracts;
using ICS.Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ICS.Domain.Data.Repositories
{
    /// <summary>
    /// Репозиторий логов паспортных данных
    /// </summary>
    public sealed class PassportLogRepository : IPassportLogRepository
    {
        private readonly IIdGenerator _idGenerator;
        private readonly DomainLogContext _context;

        public PassportLogRepository(
            IIdGenerator idGenerator,
            DomainLogContext domainLogContext)
        {
            _idGenerator = idGenerator ?? throw new ArgumentNullException(nameof(idGenerator));
            _context = domainLogContext ?? throw new ArgumentNullException(nameof(domainLogContext));
        }

        /// <summary>
        /// Получить все логи паспортных данных
        /// </summary>
        /// <returns>Логи паспортных данных</returns>
        public async Task<IEnumerable<PassportLog>> GetAllAsync()
        {
            var passportLogs = await _context.Set<PassportLog>().ToArrayAsync().ConfigureAwait(false);

            return passportLogs;
        }

        /// <summary>
        /// Получить лог паспортных данных по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор лога паспортных данных</param>
        /// <returns>Лог паспортных данных</returns>
        public async Task<PassportLog> GetAsync(Guid id)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));

            var passportLog = await _context.Set<PassportLog>().FindAsync(id).ConfigureAwait(false);

            if (passportLog == null)
            {
                throw new Exception($"Сущность не найдена для id: {id}");
            }

            return passportLog;
        }

        /// <summary>
        /// Создать лог паспортных данных
        /// </summary>
        /// <param name="nameRus">Имя по-русски</param>
        /// <param name="nameEng">Имя по-английски</param>
        /// <param name="surnameRus">Фамилия по-русски</param>
        /// <param name="surnameEng">Фамилия по-английски</param>
        /// <param name="patronymicNameRus">Отчество по-русски</param>
        /// <param name="patronymicNameEng">Отчество по-английски</param>
        /// <param name="birthPlace">Место рождения</param>
        /// <param name="birthCountry">Страна рождения</param>
        /// <param name="citizenship">Гражданство (подданство)</param>
        /// <param name="residence">Местожительство</param>
        /// <param name="residenceCountry">Страна проживания</param>
        /// <param name="residenceRegion">Регион проживания</param>
        /// <param name="identityDocument">Документ идентифицирующий личность</param>
        /// <param name="issuePlace">Место выдачи документа</param>
        /// <param name="departmentCode">Код подразделения, выдававшего документ</param>
        /// <param name="birthDate">Дата рождения</param>
        /// <param name="issueDate">Дата выдачи</param>
        /// <param name="gender">Пол</param>
        /// <param name="revisionNumber">Номер ревизии</param>
        /// <returns>Идентификатор лога паспортных данных</returns>
        public Guid Create(
            string nameRus,
            string nameEng,
            string surnameRus,
            string surnameEng,
            string patronymicNameRus,
            string patronymicNameEng,
            string birthPlace,
            string birthCountry,
            string citizenship,
            string residence,
            string residenceCountry,
            string residenceRegion,
            string identityDocument,
            string issuePlace,
            string departmentCode,
            DateTime birthDate,
            DateTime issueDate,
            Sex gender,
            long revisionNumber)
        {
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(nameRus, nameof(nameRus));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(nameEng, nameof(nameEng));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(surnameRus, nameof(surnameRus));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(surnameEng, nameof(surnameEng));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(patronymicNameRus, nameof(patronymicNameRus));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(patronymicNameEng, nameof(patronymicNameEng));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(birthPlace, nameof(birthPlace));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(birthCountry, nameof(birthCountry));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(departmentCode, nameof(departmentCode));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(citizenship, nameof(citizenship));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(identityDocument, nameof(identityDocument));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(residence, nameof(residence));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(residenceCountry, nameof(residenceCountry));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(residenceRegion, nameof(residenceRegion));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(issuePlace, nameof(issuePlace));

            Contract.Argument.IsValidIf(revisionNumber > 0, $"{nameof(revisionNumber)} > 0");

            var createdPassportLog = _context.Set<PassportLog>().Create();

            var id = _idGenerator.Generate();
            createdPassportLog.Initialize(
                id: id,
                nameRus: nameRus,
                surnameRus: surnameRus,
                nameEng: nameEng,
                surnameEng: surnameEng,
                patronymicNameRus: patronymicNameRus,
                patronymicNameEng: patronymicNameEng,
                birthPlace: birthPlace,
                birthCountry: birthCountry,
                departmentCode: departmentCode,
                citizenship: citizenship,
                identityDocument: identityDocument,
                residence: residence,
                residenceCountry: residenceCountry,
                residenceRegion: residenceRegion,
                issuePlace: issuePlace,
                birthDate: birthDate,
                issueDate: issueDate,
                gender: gender,
                revisionNumber: revisionNumber);

            var newPassportLog = _context.Set<PassportLog>().Add(createdPassportLog);

            return newPassportLog.Id;
        }
    }
}