using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SalerOrderReceiverService.Domain.Interfaces;
using SalesOrderReceiverService.Context;
using SalesOrderReceiverService.Domain.Entities;

namespace SalesOrderReceiverService.Infra.Data.Repositories
{
   public class SalesOrderRepository : ISalesOrderRepository
    {

        private readonly ILogger<SalesOrderRepository> _logger;
        private readonly ApplicationDbContext _salesOrderContext;

        public SalesOrderRepository(ILogger<SalesOrderRepository> logger,
                                    ApplicationDbContext context)
        {
            _logger = logger;
            _salesOrderContext = context;
        }

        public async Task<SalesOrder> CreateSalesOrderAsync(SalesOrder salesOrder)
        {
            _salesOrderContext.Add<SalesOrder>(salesOrder);
            await _salesOrderContext.SaveChangesAsync();
            return (SalesOrder)salesOrder;
        }

        public async Task<IEnumerable<SalesOrder>> GetSalesOrdersAsync()
        {
            return await _salesOrderContext.SalesOrders.ToListAsync();
        }
    }
}