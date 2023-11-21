using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SalerOrderReceiverService.Domain.Interfaces;
using SalesOrderReceiverService.Context;
using SalesOrderReceiverService.Domain.Entities;

namespace SalesOrderReceiverService.Infra.Data.Repositories
{
    public class PaymentTypeRepository : IPaymentTypeRepository
    {
        private readonly ILogger<PaymentTypeRepository> _logger;
        private readonly ApplicationDbContext _paymentTypeContext;

        public PaymentTypeRepository(ILogger<PaymentTypeRepository> logger,
                                     ApplicationDbContext context)
        {
            _logger = logger;
            _paymentTypeContext = context;            
        }

        public async Task<PaymentType> CreatePaymentTypeAsync(PaymentType paymentType)
        {
            _paymentTypeContext.Add<PaymentType>(paymentType);
            await _paymentTypeContext.SaveChangesAsync();
            return (PaymentType)paymentType;
        }

        public async Task<bool> PaymentTypeExistsAsync(string name)
        {
            return await _paymentTypeContext.PaymentTypes.Where(x => x.Name == name).AnyAsync();
        }
    }
}