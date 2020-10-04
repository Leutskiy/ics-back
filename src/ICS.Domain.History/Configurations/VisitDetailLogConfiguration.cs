using ICS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICS.Domain.Configurations
{
    public sealed class VisitDetailLogConfiguration : EntityTypeConfiguration<VisitDetailLog>
    {
        public string TableName => "VisitDetailLogs";

        public VisitDetailLogConfiguration(string schemaName)
        {
            ToTable(TableName, schemaName);

            HasKey(visitDetail => visitDetail.Id);

            Property(visitDetail => visitDetail.Id)
                .HasColumnName("Uid")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(visitDetail => visitDetail.Goal).HasColumnName("Goal");
            Property(visitDetail => visitDetail.Country).HasColumnName("Country");
            Property(visitDetail => visitDetail.VisitingPoints).HasColumnName("VisitingPoints");
            Property(visitDetail => visitDetail.VisaType).HasColumnName("VisaType");
            Property(visitDetail => visitDetail.VisaCity).HasColumnName("VisaCity");
            Property(visitDetail => visitDetail.VisaCountry).HasColumnName("VisaCountry");
            Property(visitDetail => visitDetail.VisaMultiplicity).HasColumnName("VisaMultiplicity");
            Property(visitDetail => visitDetail.Period).HasColumnName("PeriodDays");
            Property(visitDetail => visitDetail.ArrivalDate).HasColumnName("ArrivalDate");
            Property(visitDetail => visitDetail.DepartureDate).HasColumnName("DepartureDate");
        }
    }
}