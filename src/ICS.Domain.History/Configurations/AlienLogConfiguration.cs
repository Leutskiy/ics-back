using ICS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICS.Domain.Configurations
{
    public sealed class AlienLogConfiguration : EntityTypeConfiguration<AlienLog>
    {
        public string TableName => "AlienLogs";

        public AlienLogConfiguration(string schemaName)
        {
            ToTable(TableName, schemaName);

            HasKey(alienLog => alienLog.AlienId);

            Property(alienLog => alienLog.AlienId).HasColumnName("Uid").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(alienLog => alienLog.RevisionNumber).HasColumnName("Revision");
            Property(alienLog => alienLog.ContactId).HasColumnName("ContactUid");
            Property(alienLog => alienLog.PassportId).HasColumnName("PassportUid");
            Property(alienLog => alienLog.OrganizationId).HasColumnName("OrganizationUid");
            Property(alienLog => alienLog.StateRegistrationId).HasColumnName("StateRegistrationUid");
            Property(alienLog => alienLog.Position).HasColumnName("Position");
            Property(alienLog => alienLog.WorkPlace).HasColumnName("WorkPlace");
            Property(alienLog => alienLog.WorkAddress).HasColumnName("WorkAddress");
            Property(alienLog => alienLog.StayAddress).HasColumnName("StayAddress");
        }
    }
}