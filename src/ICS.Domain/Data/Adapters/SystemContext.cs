using ICS.Domain.Configurations;
using ICS.Shared;
using System.Data.Entity;
using System.Diagnostics;

namespace ICS.Domain.Data.Adapters
{
    /// <summary>
    /// Контекст системы
    /// </summary>
    public sealed class SystemContext : DbContext
    {
        /// <summary>
        /// Конструктор контекста системы
        /// </summary>
        /// <param name="connectionString">Строка подключения</param>
        public SystemContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(nameOrConnectionString, nameof(nameOrConnectionString));

            SchemaName = Constants.Schemes.System;

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
        /// Зарегистрировать системные модели
        /// </summary>
        /// <param name="modelBuilder">Построитель модели</param>
        private void RegisterDomainModels(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration(SchemaName));
            modelBuilder.Configurations.Add(new ProfileConfiguration(SchemaName));
        }

        [Conditional("DEBUG")]
        private static void SetDatabaseLog(DbContext context)
        {
            context.Database.Log = s => Debug.WriteLine(s);
        }
    }
}