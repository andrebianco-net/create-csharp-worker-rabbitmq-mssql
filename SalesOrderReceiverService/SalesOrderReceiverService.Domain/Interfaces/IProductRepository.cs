using SalesOrderReceiverService.Domain.Entities;

namespace SalerOrderReceiverService.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> CreateProductAsync(Product product);
        Task<bool> ProductExistsAsync(string name);
    }
}