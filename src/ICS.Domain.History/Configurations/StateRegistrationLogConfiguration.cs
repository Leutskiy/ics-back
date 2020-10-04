using ICS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICS.Domain.Configurations
{
    public sealed class StateRegistrationLogConfiguration : EntityTypeConfiguration<StateRegistrationLog>
    {
        public string TableName => "StateRegistrationLogs";

        public StateRegistrationLogConfiguration(string schemaName)
        {
            ToTable(TableName, schemaName);

            HasKey(stateRegistration => stateRegistration.Id);

            Property(stateRegistration => stateRegistration.Id)
                .HasColumnName("Uid")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(stateRegistration => stateRegistration.Inn).HasColumnName("INN");
            Property(stateRegistration => stateRegistration.Ogrnip).HasColumnName("OGRNIP");
        }
    }
}