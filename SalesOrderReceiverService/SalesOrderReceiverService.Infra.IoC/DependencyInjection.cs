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
using SalesOrderReceiverService.RabbitMQ.Interfaces;
using SalesOrderReceiverService.RabbitMQ;
using SalesOrderReceiverService.Domain.Interfaces;

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
            services.AddScoped<ISalesOrderItemRepository, SalesOrderItemRepository>();
            services.AddScoped<ISalesOrderReceiverRabbitMQRepository, SalesOrderReceiverRabbitMQRepository>();

            // Service
            services.AddScoped<ISalesOrderReceiverAppService, SalesOrderReceiverAppService>();
            services.AddScoped<ISalesOrderReceiverRabbitMQService, SalesOrderReceiverRabbitMQService>();
            services.AddScoped<ISalesOrderService, SalesOrderService>();
            services.AddScoped<ISalesOrderItemService, SalesOrderItemService>();

            // RabbitMQ
            services.AddScoped<ISalesOrderReceiverRabbitMQ, SalesOrderReceiverRabbitMQ>();

            // Mapper
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}