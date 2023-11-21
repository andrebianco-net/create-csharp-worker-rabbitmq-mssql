using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesOrderReceiverService.Domain.Entities;

namespace SalesOrderReceiverService.Infra.Data.EntitiesConfiguration
{
    public class SalesOrderItemConfiguration : IEntityTypeConfiguration<SalesOrderItem>
    {
        public void Configure(EntityTypeBuilder<SalesOrderItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(e => e.Product).WithMany(e => e.SalesOrderItems).HasForeignKey(e => e.ProductId);

        }
    }
}