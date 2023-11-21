using SalesOrderReceiverService.Infra.IoC;
using SalesOrderReceiverService.Worker;
using Serilog;


IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddInfrastructure(hostContext.Configuration);
        services.AddInfrastructureSeed(hostContext.Configuration);
        services.AddInfrastructureSerilog(hostContext.Configuration);
        services.AddHostedService<SalesOrderReceiverServiceWorker>();        
    })  
    .UseSerilog()
    .UseWindowsService()
    .Build();

host.Run();
