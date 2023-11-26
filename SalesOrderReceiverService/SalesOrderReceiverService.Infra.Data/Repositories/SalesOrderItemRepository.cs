using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SalerOrderReceiverService.Domain.Interfaces;
using SalesOrderReceiverService.Context;
using SalesOrderReceiverService.Domain.Entities;

namespace SalesOrderReceiverService.Infra.Data.Repositories
{
   public class SalesOrderItemRepository : ISalesOrderItemRepository
    {

        private readonly ILogger<SalesOrderItemRepository> _logger;
        private readonly ApplicationDbContext _salesOrderItemContext;

        public SalesOrderItemRepository(ILogger<SalesOrderItemRepository> logger,
                                        ApplicationDbContext context)
        {
            _logger = logger;
            _salesOrderItemContext = context;
        }

        public async Task<SalesOrderItem> CreateSalesOrderItemAsync(SalesOrderItem salesOrderItem)
        {
            _salesOrderItemContext.Add<SalesOrderItem>(salesOrderItem);
            await _salesOrderItemContext.SaveChangesAsync();
            return (SalesOrderItem)salesOrderItem;
        }

        public async Task CreateSalesOrderItemsAsync(List<SalesOrderItem> salesOrderItems)
        {
            _salesOrderItemContext.AddRange(salesOrderItems);
            await _salesOrderItemContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<SalesOrderItem>> GetSalesOrderItemsAsync()
        {
            return await _salesOrderItemContext.SalesOrderItems.ToListAsync();
        }
    }
}