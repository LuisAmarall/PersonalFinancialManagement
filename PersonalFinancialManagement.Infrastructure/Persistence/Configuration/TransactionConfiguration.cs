using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinancialManagement.Core.Models.Entities;

namespace PersonalFinancialManagement.Infrastructure.Persistence.Configuration;
public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("Transaction")
            .HasKey(_ => _.Id);

        builder.Property(_ => _.UserId).HasColumnName("UserId").HasColumnType("UNIQUEIDENTIFIER").IsRequired();

        builder.Property(_ => _.ToPayId).HasColumnName("ToPayId").HasColumnType("UNIQUEIDENTIFIER").IsRequired();

        builder.Property(_ => _.ToReceiveId).HasColumnName("ToReceiveId").HasColumnType("UNIQUEIDENTIFIER").IsRequired();

        builder.OwnsOne(_ => _.Amount, amount =>
        { amount.Property(_ => _.Value).HasColumnName("Amount").HasColumnType("DECIMAL(00,00)").IsRequired(); });

        builder.OwnsOne(_ => _.Modality, modality =>
        { modality.Property(_ => _.Modality).HasColumnName("Modality").HasColumnType("VARCHAR").HasMaxLength(50).IsRequired(); });

        builder.OwnsOne(_ => _.Description, description =>
        { description.Property(_ => _.Information).HasColumnName("Description").HasColumnType("VARCHAR").HasMaxLength(200).IsRequired(); });

        builder.OwnsOne(_ => _.TransactionDate, transactionDate =>
        { transactionDate.Property(_ => _.Date).HasColumnName("Transaction Date").HasColumnType("TIMESTAMP").IsRequired(); });

    }
}