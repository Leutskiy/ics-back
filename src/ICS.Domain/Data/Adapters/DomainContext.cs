using ICS.Domain.Configurations;
using ICS.Shared;
using System.Data.Entity;
using System.Diagnostics;

namespace ICS.Domain.Data.Adapters
{
    /// <summary>
    /// Контекст домена
    /// </summary>
    public sealed class DomainContext : DbContext
    {
        /// <summary>
        /// Конструктор контекста домена
        /// </summary>
        /// <param name="connectionString">Строка подключения</param>
        public DomainContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(nameOrConnectionString, nameof(nameOrConnectionString));

            SchemaName = Constants.Schemes.Domain;

            SetDatabaseLog(this);
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

            Database.SetInitializer<DomainContext>(null);

            RegisterDomainModels(modelBuilder);
        }

        /// <summary>
        /// Зарегистрировать доменные модели
        /// </summary>
        /// <param name="modelBuilder">Построитель модели</param>
        private void RegisterDomainModels(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlienConfiguration(SchemaName));
            modelBuilder.Configurations.Add(new ContactConfiguration(SchemaName));
            modelBuilder.Configurations.Add(new EmployeeConfiguration(SchemaName));
            modelBuilder.Configurations.Add(new DocumentConfiguration(SchemaName));
            modelBuilder.Configurations.Add(new PassportConfiguration(SchemaName));
            modelBuilder.Configurations.Add(new InvitationConfiguration(SchemaName));
            modelBuilder.Configurations.Add(new VisitDetailConfiguration(SchemaName));
            modelBuilder.Configurations.Add(new OrganizationConfiguration(SchemaName));
            modelBuilder.Configurations.Add(new StateRegistrationConfiguration(SchemaName));
            modelBuilder.Configurations.Add(new ForeignParticipantConfiguration(SchemaName));
        }

        [Conditional("DEBUG")]
        private static void SetDatabaseLog(DbContext context)
        {
            context.Database.Log = s => Debug.WriteLine(s);
        }
    }
}