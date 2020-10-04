using ICS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICS.Domain.Configurations
{
    public sealed class StateRegistrationConfiguration : EntityTypeConfiguration<StateRegistration>
    {
        public string TableName => "StateRegistrations";

        public StateRegistrationConfiguration(string schemaName)
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