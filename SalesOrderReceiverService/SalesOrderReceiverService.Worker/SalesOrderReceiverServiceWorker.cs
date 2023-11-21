using SalesOrderReceiverService.Application.Interfaces;

namespace SalesOrderReceiverService.Worker;

public class SalesOrderReceiverServiceWorker : BackgroundService
{
    private readonly ILogger<SalesOrderReceiverServiceWorker> _logger;
    private readonly IConfiguration _configuration;
    private readonly IServiceProvider _serviceProvider;

    public SalesOrderReceiverServiceWorker(ILogger<SalesOrderReceiverServiceWorker> logger,
                                           IConfiguration configuration,
                                           IServiceProvider serviceProvider)
    {
        _logger = logger;
        _configuration = configuration;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation($"SalesOrderReceiverServiceWorker -> Worker running at: {DateTimeOffset.Now}");
            await SalesOrderReceiverRun(stoppingToken);
            int interval = int.Parse(_configuration["Worker:Interval"].ToString());
            await Task.Delay(interval, stoppingToken);
        }
    }

    private async Task SalesOrderReceiverRun(CancellationToken stoppingToken)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var scopedProcessingService = scope.ServiceProvider.GetRequiredService<ISalesOrderReceiverAppService>();
            await scopedProcessingService.SalesOrderReceiverRun();
        }
    }
}
