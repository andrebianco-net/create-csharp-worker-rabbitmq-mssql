using SalesOrderReceiverService.Domain.Entities;

namespace SalerOrderReceiverService.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<bool> CustomerExistsAsync(string name);
    }
}