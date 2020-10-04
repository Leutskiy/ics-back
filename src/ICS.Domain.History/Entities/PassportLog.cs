using ICS.Domain.Enums;
using ICS.Shared;
using System;

namespace ICS.Domain.Entities
{
    /// <summary>
    /// Логи паспортных данных
    /// </summary>
    public class PassportLog
    {
        protected PassportLog()
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
        /// Имя (по-русски)
        /// </summary>
        public virtual string NameRus { get; protected set; }

        /// <summary>
        /// Имя (по-английски)
        /// </summary>
        public virtual string NameEng { get; protected set; }

        /// <summary>
        /// Фамилия (по-русски)
        /// </summary>
        public virtual string SurnameRus { get; protected set; }

        /// <summary>
        /// Фамилия (по-английски)
        /// </summary>
        public virtual string SurnameEng { get; protected set; }

        /// <summary>
        /// Отчество (по-русски)
        /// </summary>
        public virtual string PatronymicNameRus { get; protected set; }

        /// <summary>
        /// Отчество (по-ангийски)
        /// </summary>
        public virtual string PatronymicNameEng { get; protected set; }

        /// <summary>
        /// Место рождения
        /// </summary>
        public virtual string BirthPlace { get; protected set; }

        /// <summary>
        /// Страна рождения
        /// </summary>
        public virtual string BirthCountry { get; protected set; }

        /// <summary>
        /// Гражданство (подданство)
        /// </summary>
        public virtual string Citizenship { get; protected set; }

        /// <summary>
        /// Местожительство
        /// </summary>
        public virtual string Residence { get; protected set; }

        /// <summary>
        /// Страна постоянного проживания
        /// </summary>
        public virtual string ResidenceCountry { get; protected set; }

        /// <summary>
        /// Регион в стране постоянного проживания
        /// </summary>
        public virtual string ResidenceRegion { get; protected set; }

        /// <summary>
        /// Документ удостоверяющий личность
        /// </summary>
        public virtual string IdentityDocument { get; protected set; }

        /// <summary>
        /// Место выдачи документа удостоверяющего личность
        /// </summary>
        public virtual string IssuePlace { get; protected set; }

        /// <summary>
        /// Код подразделения выдававшего документ
        /// </summary>
        public virtual string DepartmentCode { get; protected set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public virtual DateTime BirthDate { get; protected set; }

        /// <summary>
        /// Дата выдачи документа удостоверяющего личность
        /// </summary>
        public virtual DateTime IssueDate { get; protected set; }

        /// <summary>
        /// Пол
        /// </summary>
        public virtual Sex Gender { get; protected set; }

        /// <summary>
        /// Инициализировать логи паспортных данных
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="nameRus">Имя по-русски</param>
        /// <param name="surnameRus">Фмаилия по-русски</param>
        /// <param name="nameEng">Имя по-английски</param>
        /// <param name="surnameEng">Фамилия по-английски</param>
        /// <param name="patronymicNameRus">Отчество по-русски</param>
        /// <param name="patronymicNameEng">Отчество по-английски</param>
        /// <param name="birthPlace">Место рождения</param>
        /// <param name="birthCountry">Страна рождения</param>
        /// <param name="departmentCode">Код подразделения</param>
        /// <param name="citizenship">Гражданство (подданство)</param>
        /// <param name="identityDocument">Документ идентицирующий личность</param>
        /// <param name="residence">Местожительство</param>
        /// <param name="residenceCountry">Страна проживания</param>
        /// <param name="residenceRegion">Регион проживания</param>
        /// <param name="issuePlace">Место выда документа идентифицирующего личность</param>
        /// <param name="birthDate">Дата рождения</param>
        /// <param name="issueDate">Дата выдачи документа идентифицирующего личность</param>
        /// <param name="gender">Пол</param>
        public void Initialize(
            Guid id,
            string nameRus,
            string surnameRus,
            string nameEng,
            string surnameEng,
            string patronymicNameRus,
            string patronymicNameEng,
            string birthPlace,
            string birthCountry,
            string departmentCode,
            string citizenship,
            string identityDocument,
            string residence,
            string residenceCountry,
            string residenceRegion,
            string issuePlace,
            DateTime birthDate,
            DateTime issueDate,
            Sex gender,
            long revisionNumber)
        {
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));
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

            Id = id;

            NameRus = nameRus;
            NameEng = nameEng;
            SurnameRus = surnameRus;
            SurnameEng = surnameEng;
            PatronymicNameRus = patronymicNameRus;
            PatronymicNameEng = patronymicNameEng;
            BirthPlace = birthPlace;
            BirthCountry = birthCountry;
            DepartmentCode = departmentCode;
            Citizenship = citizenship;
            IdentityDocument = identityDocument;
            Residence = residence;
            ResidenceCountry = residenceCountry;
            ResidenceRegion = residenceRegion;
            IssuePlace = issuePlace;
        }
    }
}