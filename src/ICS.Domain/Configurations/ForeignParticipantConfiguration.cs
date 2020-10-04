using ICS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICS.Domain.Configurations
{
    public sealed class ForeignParticipantConfiguration : EntityTypeConfiguration<ForeignParticipant>
    {
        public string TableName => "ForeignParticipants";

        public ForeignParticipantConfiguration(string schemaName)
        {
            ToTable(TableName, schemaName);

            HasKey(foreignParticipant => foreignParticipant.Id);

            Property(foreignParticipant => foreignParticipant.Id)
                .HasColumnName("Uid")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(foreignParticipant => foreignParticipant.AlienId).HasColumnName("AlienUid");
            Property(foreignParticipant => foreignParticipant.InvitationId).HasColumnName("InvitationUid");
            Property(foreignParticipant => foreignParticipant.PassportId).HasColumnName("PassportUid");
        }
    }
}