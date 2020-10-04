using ICS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICS.Domain.Configurations
{
    public sealed class OrganizationConfiguration : EntityTypeConfiguration<Organization>
    {
        public string TableName => "Organizations";

        public OrganizationConfiguration(string schemaName)
        {
            ToTable(TableName, schemaName);

            HasKey(organization => organization.Id);

            Property(organization => organization.Id)
                .HasColumnName("Uid")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(organization => organization.StateRegistrationId).HasColumnName("StateRegistrationUid");
            Property(organization => organization.Name).HasColumnName("Name");
            Property(organization => organization.ShortName).HasColumnName("ShortName");
            Property(organization => organization.LegalAddress).HasColumnName("LegalAddress");
            Property(organization => organization.ScientificActivity).HasColumnName("ScientificActivity");
        }
    }
}