using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalerOrderReceiverService.Application.Mappings;
using SalerOrderReceiverService.Domain.Seed;
using SalerOrderReceiverService.Infra.Data.Seed;
using SalesOrderReceiverService.Application.Services;
using SalesOrderReceiverService.Context;
using SalesOrderReceiverService.Application.Interfaces;
using SalerOrderReceiverService.Domain.Interfaces;
using SalesOrderReceiverService.Infra.Data.Repositories;
using SalesOrderReceiverService.Domain.Entities;

namespace SalesOrderReceiverService.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                options =>
                options.UseSqlServer(
                            configuration.GetConnectionString("DefaultConnection"),
                            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                        )
            );

            // Repository
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IPaymentTypeRepository, PaymentTypeRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISalesOrderRepository, SalesOrderRepository>();

            // Service
            services.AddScoped<ISalesOrderReceiverAppService, SalesOrderReceiverAppService>();
            services.AddScoped<ISalesOrderService, SalesOrderService>();

            // Mapper
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}