using ICS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICS.Domain.Configurations
{
    public sealed class DocumentLogConfiguration : EntityTypeConfiguration<DocumentLog>
    {
        public string TableName => "DocumentLogs";

        public DocumentLogConfiguration(string schemaName)
        {
            ToTable(TableName, schemaName);

            HasKey(document => document.Id);

            Property(documentLog => documentLog.Id).HasColumnName("Uid").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(documentLog => documentLog.RevisionNumber).HasColumnName("Revision");
            Property(documentLog => documentLog.InvitationId).HasColumnName("InvitationUid");
            Property(documentLog => documentLog.Name).HasColumnName("Name");
            Property(documentLog => documentLog.Content).HasColumnName("Content");
            Property(documentLog => documentLog.UpdateDate).HasColumnName("UpdateDate");
            Property(documentLog => documentLog.CreatedDate).HasColumnName("CreatedDate");
            Property(documentLog => documentLog.DocumentType).HasColumnName("DocumentType");
        }
    }
}