using ICS.Domain.Entities.System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICS.Domain.Configurations
{
    public sealed class ProfileConfiguration : EntityTypeConfiguration<Profile>
    {
        public string TableName => "Profiles";

        public ProfileConfiguration(string schemaName)
        {
            ToTable(TableName, schemaName);

            HasKey(profile => profile.Id);

            Property(profile => profile.Id)
                .HasColumnName("Uid")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(profile => profile.OrdinalNumber).HasColumnName("OrdinalNumber");
            Property(profile => profile.UserId).HasColumnName("UserUid");
            Property(profile => profile.Photo).HasColumnName("Avatar");
            Property(profile => profile.WebPages).HasColumnName("WebPages");

            HasRequired(profile => profile.User).WithOptional(user => user.Profile);
        }
    }
}