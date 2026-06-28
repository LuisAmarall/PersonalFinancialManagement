using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinancialManagement.Core.Models.Entities;

namespace PersonalFinancialManagement.Infrastructure.Persistence.Configuration;

public class ToReceiveConfiguration : IEntityTypeConfiguration<ToReceive>
{
    public void Configure(EntityTypeBuilder<ToReceive> builder)
    {
        builder.ToTable("ToReceive")
            .HasKey(_ => _.Id);

        builder.Property(_ => _.UserId).HasColumnName("UserId").HasColumnType("UNIQUEIDENTIFIER").IsRequired();

        builder.Property(_ => _.CategoryId).HasColumnName("CategoryId").HasColumnType("UNIQUEIDENTIFIER").IsRequired();

        builder.Property(_ => _.TransactionId).HasColumnName("TransactionId").HasColumnType("UNIQUEIDENTIFIER").IsRequired();

        builder.OwnsOne(_ => _.Description, description =>
        { description.Property(_ => _.Information).HasColumnName("Description").HasColumnType("VARCHAR").HasMaxLength(200).IsRequired(); });

        builder.OwnsOne(_ => _.Observation, observation =>
        { observation.Property(_ => _.Information).HasColumnName("Observation").HasColumnType("VARCHAR").HasMaxLength(200).IsRequired(); });

        builder.OwnsOne(_ => _.OriginalValue, originalValue =>
        { originalValue.Property(_ => _.Value).HasColumnName("Original Value").HasColumnType("DECIMAL(00,00)").IsRequired(); });

        builder.OwnsOne(_ => _.AmountReceived, amountReceived =>
        { amountReceived.Property(_ => _.Value).HasColumnName("Amount Received").HasColumnType("DECIMAL(00,00)").IsRequired(); });

        builder.OwnsOne(_ => _.DueDate, dueDate =>
        { dueDate.Property(_ => _.Date).HasColumnName("Due Date").HasColumnType("TIMESTAMP").IsRequired(); });

        builder.OwnsOne(_ => _.ReferenceDate, referenceDate =>
        { referenceDate.Property(_ => _.Date).HasColumnName("Reference Date").HasColumnType("TIMESTAMP").IsRequired(); });

        builder.OwnsOne(_ => _.DateReceipt, dateReceipt =>
        { dateReceipt.Property(_ => _.Date).HasColumnName("Date Receipt").HasColumnType("TIMESTAMP").IsRequired(); });

        builder.OwnsOne(_ => _.CreatedAt, createdAt =>
        { createdAt.Property(_ => _.Date).HasColumnName("Created At").HasColumnType("TIMESTAMP").IsRequired(); });
    }
}