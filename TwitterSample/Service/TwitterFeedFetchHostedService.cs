namespace TwitterSample.Service;

public class TwitterFeedFetchHostedService : BackgroundService
{
    private readonly ILogger<TwitterFeedFetchHostedService> _logger;
    private readonly IServiceProvider _serviceProvider;

    public TwitterFeedFetchHostedService(ILogger<TwitterFeedFetchHostedService> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("TwitterFeedFetch is starting");
        await BackgroundProcessing(stoppingToken);
        _logger.LogInformation("TwitterFeedFetch is running");
    }

    private async Task BackgroundProcessing(CancellationToken stoppingToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var twitterService = scope.ServiceProvider.GetService<ITwitterSampleStreamService>();
        ArgumentNullException.ThrowIfNull(twitterService);
        var errors = 0;

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await twitterService.StartTwitterSampleStreamAsync();
            }
            catch (Exception ex)
            {
                errors++;
                _logger.LogError(ex, "TwitterFeedFetchHostedService BackgroundProcessing Exception");

            }
        }
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Twitter Service is stopping.");
        await base.StopAsync(stoppingToken);
    }
}