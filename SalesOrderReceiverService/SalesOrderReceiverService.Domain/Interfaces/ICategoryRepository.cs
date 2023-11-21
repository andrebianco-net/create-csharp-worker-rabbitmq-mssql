using SalesOrderReceiverService.Domain.Entities;

namespace SalerOrderReceiverService.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> CreateCategoryAsync(Category category);
        Task<bool> CategoryExistsAsync(string name);
    }
}