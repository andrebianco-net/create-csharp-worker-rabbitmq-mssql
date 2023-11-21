using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalerOrderReceiverService.Domain.Seed;
using SalerOrderReceiverService.Infra.Data.Seed;
using SalesOrderReceiverService.Context;

namespace SalesOrderReceiverService.Infra.IoC
{
    public static class DependencyInjectionSeed
    {
        public static IServiceCollection AddInfrastructureSeed(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<ISeedInitial, SeedInitial>();

            var serviceProvider = services.BuildServiceProvider();

            using (var db = serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                //Just create seeds if database is connected
                if (db.Database.CanConnect())
                {
                    using (var scope = serviceProvider.CreateScope())
                    {
                        var seed = scope.ServiceProvider.GetRequiredService<ISeedInitial>();

                        //It will create new records if they do not exists yet.
                        //No duplicity will be generated.
                        seed.SeedCustomers();
                        seed.SeedCategories();
                        seed.SeedProducts();
                        seed.SeedPaymentType();
                    }
                }
            }

            return services;
        }
    }
}