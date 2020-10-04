using ICS.Domain.Entities.System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICS.Domain.Configurations
{
    public sealed class UserConfiguration : EntityTypeConfiguration<User>
    {
        public string TableName => "Users";

        public UserConfiguration(string schemaName)
        {
            ToTable(TableName, schemaName);

            HasKey(user => user.Id);

            Property(user => user.Id)
                .HasColumnName("Uid")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(user => user.AccountName).HasColumnName("Account");
            Property(user => user.Password).HasColumnName("Password");
            Property(user => user.Password).HasColumnName("Password");
            Property(user => user.ProfileId).HasColumnName("ProfileUid");

            HasOptional(user => user.Profile).WithRequired(profile => profile.User);
        }
    }
}