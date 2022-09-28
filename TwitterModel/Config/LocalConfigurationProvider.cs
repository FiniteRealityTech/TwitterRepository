namespace TwitterModel.Config;

public class LocalConfigurationProvider : ConfigurationProvider
{
    public LocalConfigurationProvider(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    public override void Load()
    {
        using var sr = new StreamReader("../../Settings/TwitterSettings.json");

        var credentialString = sr.ReadToEnd();
        ArgumentNullException.ThrowIfNull(credentialString);

        var credentials = credentialString.ToJsonObject<TwitterData>();
        ArgumentNullException.ThrowIfNull(credentials);

        Data = credentials.TwitterSettings;
    }
}