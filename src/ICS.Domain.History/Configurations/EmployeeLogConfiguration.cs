using ICS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICS.Domain.Configurations
{
    public sealed class EmployeeLogConfiguration : EntityTypeConfiguration<EmployeeLog>
    {
        public string TableName => "EmployeeLogs";

        public EmployeeLogConfiguration(string schemaName)
        {
            ToTable(TableName, schemaName);

            HasKey(employee => employee.Id);

            Property(employee => employee.Id).HasColumnName("Uid").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(alienLog => alienLog.RevisionNumber).HasColumnName("Revision");
            Property(employee => employee.UserId).HasColumnName("UserUid");
            Property(employee => employee.ContactId).HasColumnName("ContactUid");
            Property(employee => employee.ManagerId).HasColumnName("ManagerUid");
            Property(employee => employee.PassportId).HasColumnName("OrganizationUid");
            Property(employee => employee.OrganizationId).HasColumnName("OrganizationUid");
            Property(employee => employee.StateRegistrationId).HasColumnName("StateRegistrationUid");
            Property(employee => employee.Position).HasColumnName("Position");
            Property(employee => employee.WorkPlace).HasColumnName("WorkPlace");
        }
    }
}