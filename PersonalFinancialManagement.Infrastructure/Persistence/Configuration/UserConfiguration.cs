using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinancialManagement.Core.Models.Entities;

namespace PersonalFinancialManagement.Infrastructure.Persistence.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Transfers")
            .HasKey(_ => _.Id);

        builder.OwnsOne(_ => _.FullName, name =>
        { name.Property(_ => _.IndividualsName).HasColumnName("Name").HasColumnType("VARCHAR").HasMaxLength(100).IsRequired(); });

        builder.OwnsOne(_ => _.EmailAddress, email =>
        { email.Property(_ => _.EmailAddress).HasColumnName("Email").HasColumnType("VARCHAR").HasMaxLength(80).IsRequired(); });

        builder.OwnsOne(_ => _.Password, password =>
        { password.Property(_ => _.Key).HasColumnName("Password").HasColumnType("VARCHAR").HasMaxLength(10).IsRequired(); });

        builder.Property(_ => _.CreatedAt).HasColumnName("CreatedAt").HasColumnType("TIMESTAMP").IsRequired();

        builder.Property(_ => _.DeletedAt).HasColumnName("DeletedAt").HasColumnType("TIMESTAMP");
    }
}