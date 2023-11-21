using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SalerOrderReceiverService.Domain.Interfaces;
using SalesOrderReceiverService.Context;
using SalesOrderReceiverService.Domain.Entities;

namespace SalesOrderReceiverService.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ILogger<CategoryRepository> _logger;
        private readonly ApplicationDbContext _categoryContext;        

        public CategoryRepository(ILogger<CategoryRepository> logger,
                                  ApplicationDbContext context)
        {
            _logger = logger;
            _categoryContext = context;
        }

        public async Task<bool> CategoryExistsAsync(string name)
        {
            return await _categoryContext.Categories.Where(x => x.Name == name).AnyAsync();
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            _categoryContext.Add<Category>(category);
            await _categoryContext.SaveChangesAsync();
            return (Category)category;
        }
    }
}