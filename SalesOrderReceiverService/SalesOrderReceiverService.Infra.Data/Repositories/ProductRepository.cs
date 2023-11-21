using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SalerOrderReceiverService.Domain.Interfaces;
using SalesOrderReceiverService.Context;
using SalesOrderReceiverService.Domain.Entities;

namespace SalesOrderReceiverService.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ILogger<ProductRepository> _logger;
        private readonly ApplicationDbContext _productContext;

        public ProductRepository(ILogger<ProductRepository> logger,
                                 ApplicationDbContext context)
        {
            _logger = logger;
            _productContext = context;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            _productContext.Add<Product>(product);
            await _productContext.SaveChangesAsync();
            return (Product)product;
        }

        public async Task<bool> ProductExistsAsync(string name)
        {
            return await _productContext.Products.Where(x => x.Name == name).AnyAsync();
        }
    }
}