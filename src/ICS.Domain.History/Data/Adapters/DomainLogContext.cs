using ICS.Domain.Configurations;
using ICS.Shared;
using System.Data.Entity;

namespace ICS.Domain.Data.Adapters
{
    /// <summary>
    /// Контекст логов домена
    /// </summary>
    public sealed class DomainLogContext : DbContext
    {
        /// <summary>
        /// Конструктор контекста логов домена
        /// </summary>
        /// <param name="connectionString">Строка подключения</param>
        /// <param name="schemaName">Наименование схемы</param>
        public DomainLogContext(
            string connectionString,
            string schemaName)
            : base(connectionString)
        {
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(connectionString, nameof(connectionString));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(schemaName, nameof(schemaName));

            SchemaName = schemaName;
        }

        /// <summary>
        /// Наименование схемы
        /// </summary>
        public string SchemaName { get; private set; }

        /// <summary>
        /// Вызов после создания модели
        /// </summary>
        /// <param name="modelBuilder">Построитель модели</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Database.SetInitializer<DomainLogContext>(null);

            RegisterDomainModels(modelBuilder);
        }

        /// <summary>
        /// Зарегистрировать доменные модели
        /// </summary>
        /// <param name="modelBuilder">Построитель модели</param>
        private void RegisterDomainModels(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlienLogConfiguration(SchemaName));
            modelBuilder.Configurations.Add(new ContactLogConfiguration(SchemaName));
            modelBuilder.Configurations.Add(new EmployeeLogConfiguration(SchemaName));
            modelBuilder.Configurations.Add(new DocumentLogConfiguration(SchemaName));
            modelBuilder.Configurations.Add(new PassportLogConfiguration(SchemaName));
            modelBuilder.Configurations.Add(new InvitationLogConfiguration(SchemaName));
            modelBuilder.Configurations.Add(new VisitDetailLogConfiguration(SchemaName));
            modelBuilder.Configurations.Add(new OrganizationLogConfiguration(SchemaName));
            modelBuilder.Configurations.Add(new StateRegistrationLogConfiguration(SchemaName));
            modelBuilder.Configurations.Add(new ForeignParticipantLogConfiguration(SchemaName));
        }
    }
}