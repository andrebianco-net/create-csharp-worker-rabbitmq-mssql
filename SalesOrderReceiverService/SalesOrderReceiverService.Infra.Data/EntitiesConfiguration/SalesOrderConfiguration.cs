using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesOrderReceiverService.Domain.Entities;

namespace SalesOrderReceiverService.Infra.Data.EntitiesConfiguration
{
    public class SalesOrderConfiguration : IEntityTypeConfiguration<SalesOrder>
    {
        public void Configure(EntityTypeBuilder<SalesOrder> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Total).HasPrecision(10,2);
            builder.Property(p => p.SoldAt).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();

            builder.HasOne(e => e.Category).WithMany(e => e.SalesOrders).HasForeignKey(e => e.CategoryId);
            builder.HasOne(e => e.Customer).WithMany(e => e.SalesOrders).HasForeignKey(e => e.CustomerId);
            builder.HasOne(e => e.PaymentType).WithMany(e => e.SalesOrders).HasForeignKey(e => e.PaymentTypeId);

        }
    }
}