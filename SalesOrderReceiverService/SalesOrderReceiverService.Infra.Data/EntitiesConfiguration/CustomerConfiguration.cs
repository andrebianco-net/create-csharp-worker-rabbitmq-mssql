using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesOrderReceiverService.Domain.Entities;

namespace SalesOrderReceiverService.Infra.Data.EntitiesConfiguration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();            
        }
    }
}