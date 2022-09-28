namespace TwitterSample.Service;

public class TwitterFeedProcessHostedService : BackgroundService
{
    private readonly ILogger<TwitterFeedProcessHostedService> _logger;
    private readonly IServiceProvider _serviceProvider;

    public TwitterFeedProcessHostedService(ILogger<TwitterFeedProcessHostedService> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("TwitterFeedProcessService is starting");
        await BackgroundProcessing(stoppingToken);
        _logger.LogInformation("TwitterFeedProcessService is running");
    }

    private async Task BackgroundProcessing(CancellationToken stoppingToken)
    {
        var twitterStatService = _serviceProvider.GetRequiredService<ITwitterStatService>();
        var errors = 0;

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                _logger.LogCritical(twitterStatService.ToString());
                await Task.Delay(10000, stoppingToken);

            }
            catch (Exception ex)
            {
                errors++;
                _logger.LogError(ex, "TwitterFeedProcessHostedService BackgroundProcessing Exception");
                if (errors > 10)
                {
                    throw new InvalidOperationException("More than ten errors have occured");
                }
            }
        }
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Twitter Service is stopping.");
        await base.StopAsync(stoppingToken);
    }
}