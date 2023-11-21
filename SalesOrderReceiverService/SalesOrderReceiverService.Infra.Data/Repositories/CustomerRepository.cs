using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SalerOrderReceiverService.Domain.Interfaces;
using SalesOrderReceiverService.Context;
using SalesOrderReceiverService.Domain.Entities;

namespace SalesOrderReceiverService.Infra.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ILogger<CustomerRepository> _logger;
        private readonly ApplicationDbContext _customerContext;

        public CustomerRepository(ILogger<CustomerRepository> logger,
                                  ApplicationDbContext context)
        {
            _logger = logger;
            _customerContext = context;
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            _customerContext.Add<Customer>(customer);
            await _customerContext.SaveChangesAsync();
            return (Customer)customer;
        }

        public async Task<bool> CustomerExistsAsync(string name)
        {
            return await _customerContext.Customers.Where(x => x.Name == name).AnyAsync();
        }
    }
}