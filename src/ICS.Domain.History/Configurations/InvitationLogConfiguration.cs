using ICS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICS.Domain.Configurations
{
    public sealed class InvitationLogConfiguration : EntityTypeConfiguration<InvitationLog>
    {
        public string TableName => "InvitationLogs";

        public InvitationLogConfiguration(string schemaName)
        {
            ToTable(TableName, schemaName);

            HasKey(invitation => invitation.Id);

            Property(invitation => invitation.Id).HasColumnName("Uid").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(alienLog => alienLog.RevisionNumber).HasColumnName("Revision");
            Property(invitation => invitation.AlienId).HasColumnName("AlienUid");
            Property(invitation => invitation.EmployeeId).HasColumnName("EmployeeUid");
            Property(invitation => invitation.VisitDetailId).HasColumnName("VisitDetailUid");
            Property(invitation => invitation.CreatedDate).HasColumnName("CreatedDate");
            Property(invitation => invitation.UpdateDate).HasColumnName("UpdateDate");
            Property(invitation => invitation.Status).HasColumnName("Status");
        }
    }
}