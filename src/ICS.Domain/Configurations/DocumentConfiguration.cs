using ICS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICS.Domain.Configurations
{
    public sealed class DocumentConfiguration : EntityTypeConfiguration<Document>
    {
        public string TableName => "Documents";

        public DocumentConfiguration(string schemaName)
        {
            ToTable(TableName, schemaName);

            HasKey(document => document.Id);

            Property(document => document.Id)
                .HasColumnName("Uid")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(document => document.InvitationId).HasColumnName("InvitationUid");
            Property(document => document.Name).HasColumnName("Name");
            Property(document => document.Content).HasColumnName("Content");
            Property(document => document.UpdateDate).HasColumnName("UpdateDate");
            Property(document => document.CreatedDate).HasColumnName("CreatedDate");
            Property(document => document.DocumentType).HasColumnName("DocumentType");
        }
    }
}