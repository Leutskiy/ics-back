using ICS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICS.Domain.Configurations
{
    public sealed class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public string TableName => "Employees";

        public EmployeeConfiguration(string schemaName)
        {
            ToTable(TableName, schemaName);

            HasKey(employee => employee.Id);

            Property(employee => employee.Id)
                .HasColumnName("Uid")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(employee => employee.UserId).HasColumnName("UserUid");
            Property(employee => employee.ContactId).HasColumnName("ContactUid");
            Property(employee => employee.ManagerId).HasColumnName("ManagerUid");
            Property(employee => employee.PassportId).HasColumnName("PassportUid");
            Property(employee => employee.InvitationId).HasColumnName("InvitationUid");
            Property(employee => employee.OrganizationId).HasColumnName("OrganizationUid");
            Property(employee => employee.StateRegistrationId).HasColumnName("StateRegistrationUid");
            Property(employee => employee.AcademicRank).HasColumnName("AcademicRank");
            Property(employee => employee.AcademicDegree).HasColumnName("AcademicDegree");
            Property(employee => employee.Education).HasColumnName("Education");
            Property(employee => employee.Position).HasColumnName("Position");
            Property(employee => employee.WorkPlace).HasColumnName("WorkPlace");

            HasOptional(employee => employee.Manager).WithMany().HasForeignKey(manager => manager.ManagerId);
        }
    }
}