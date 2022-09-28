namespace TwitterModel.Config;

public class LocalConfigurationSource : IConfigurationSource
{
    public LocalConfigurationSource(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    public IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        return new LocalConfigurationProvider(Configuration);
    }
}