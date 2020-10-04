using ICS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICS.Domain.Configurations
{
    public sealed class PassportLogConfiguration : EntityTypeConfiguration<PassportLog>
    {
        public string TableName => "PassportLogs";

        public PassportLogConfiguration(string schemaName)
        {
            ToTable(TableName, schemaName);

            HasKey(passport => passport.Id);

            Property(passport => passport.Id)
                .HasColumnName("Uid")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(passport => passport.NameRus).HasColumnName("NameRus");
            Property(passport => passport.NameEng).HasColumnName("NameEng");
            Property(passport => passport.SurnameRus).HasColumnName("SurnameRus");
            Property(passport => passport.SurnameEng).HasColumnName("SurnameEng");
            Property(passport => passport.PatronymicNameRus).HasColumnName("PatronymicNameRus");
            Property(passport => passport.PatronymicNameEng).HasColumnName("PatronymicNameEng");
            Property(passport => passport.BirthDate).HasColumnName("BirthDate");
            Property(passport => passport.BirthPlace).HasColumnName("BirthPlace");
            Property(passport => passport.BirthCountry).HasColumnName("BirthCountry");
            Property(passport => passport.Citizenship).HasColumnName("Citizenship");
            Property(passport => passport.Gender).HasColumnName("Gender");
            Property(passport => passport.IdentityDocument).HasColumnName("IdentityDocument");
            Property(passport => passport.IssueDate).HasColumnName("IssueDate");
            Property(passport => passport.IssuePlace).HasColumnName("IssuePlace");
            Property(passport => passport.DepartmentCode).HasColumnName("DepartmentCode");
            Property(passport => passport.Residence).HasColumnName("Residence");
            Property(passport => passport.ResidenceRegion).HasColumnName("ResidenceRegion");
            Property(passport => passport.ResidenceCountry).HasColumnName("ResidenceCountry");
        }
    }
}