using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinancialManagement.Core.Entities;

namespace PersonalFinancialManagement.Infrastructure.Persistence.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category")
            .HasKey(c => c.Id);

        builder.Property(_ => _.UserId).HasColumnName("UserId").HasColumnType("UNIQUEIDENTIFIER").IsRequired();

        builder.OwnsOne(_ => _.Description, description =>
        { description.Property(_ => _.Information).HasColumnName("Description").HasColumnType("VARCHAR").HasMaxLength(200).IsRequired(); });

        builder.OwnsOne(_ => _.Observation, observation =>
        { observation.Property(_ => _.Information).HasColumnName("Observation").HasColumnType("VARCHAR").HasMaxLength(200).IsRequired(); });

        builder.Property(_ => _.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime2").IsRequired();

        builder.Property(_ => _.DeletedAt).HasColumnName("DeletedAt").HasColumnType("datetime2");
    }
}