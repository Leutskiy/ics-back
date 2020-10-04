using ICS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICS.Domain.Configurations
{
    public sealed class AlienConfiguration : EntityTypeConfiguration<Alien>
    {
        public string TableName => "Aliens";

        public AlienConfiguration(string schemaName)
        {
            ToTable(TableName, schemaName);

            HasKey(alien => alien.Id);

            Property(alien => alien.Id)
                .HasColumnName("AlienUid")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(alien => alien.InvitationId).HasColumnName("InvitationUid");
            Property(alien => alien.ContactId).HasColumnName("ContactUid");
            Property(alien => alien.PassportId).HasColumnName("PassportUid");
            Property(alien => alien.OrganizationId).HasColumnName("OrganizationUid");
            Property(alien => alien.StateRegistrationId).HasColumnName("StateRegistrationUid");
            Property(alien => alien.Position).HasColumnName("Position");
            Property(alien => alien.WorkPlace).HasColumnName("WorkPlace");
            Property(alien => alien.WorkAddress).HasColumnName("WorkAddress");
            Property(alien => alien.StayAddress).HasColumnName("StayAddress");
        }
    }
}