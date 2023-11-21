using SalesOrderReceiverService.Domain.Entities;

namespace SalerOrderReceiverService.Domain.Interfaces
{
    public interface IPaymentTypeRepository
    {
        Task<PaymentType> CreatePaymentTypeAsync(PaymentType paymentType);
        Task<bool> PaymentTypeExistsAsync(string name);
    }
}