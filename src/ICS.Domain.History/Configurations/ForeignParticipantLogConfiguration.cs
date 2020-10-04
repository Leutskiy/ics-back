using ICS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICS.Domain.Configurations
{
    public sealed class ForeignParticipantLogConfiguration : EntityTypeConfiguration<ForeignParticipantLog>
    {
        public string TableName => "ForeignParticipantLogs";

        public ForeignParticipantLogConfiguration(string schemaName)
        {
            ToTable(TableName, schemaName);

            HasKey(foreignParticipant => foreignParticipant.Id);

            Property(foreignParticipant => foreignParticipant.Id).HasColumnName("Uid").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(alienLog => alienLog.RevisionNumber).HasColumnName("Revision");
            Property(foreignParticipant => foreignParticipant.AlienId).HasColumnName("AlienUid");
            Property(foreignParticipant => foreignParticipant.PassportId).HasColumnName("PassportUid");
        }
    }
}