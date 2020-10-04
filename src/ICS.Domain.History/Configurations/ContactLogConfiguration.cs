using ICS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICS.Domain.Configurations
{
    public sealed class ContactLogConfiguration : EntityTypeConfiguration<ContactLog>
    {
        public string TableName => "ContactLogs";

        public ContactLogConfiguration(string schemaName)
        {
            ToTable(TableName, schemaName);

            HasKey(contact => contact.Id);

            Property(contact => contact.Id).HasColumnName("Uid").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(alienLog => alienLog.RevisionNumber).HasColumnName("Revision");
            Property(contact => contact.Email).HasColumnName("Email");
            Property(contact => contact.Postcode).HasColumnName("Postcode");
            Property(contact => contact.HomePhoneNumber).HasColumnName("HomePhoneNumber");
            Property(contact => contact.WorkPhoneNumber).HasColumnName("WorkPhoneNumber");
            Property(contact => contact.MobilePhoneNumber).HasColumnName("MobilePhoneNumber");
        }
    }
}