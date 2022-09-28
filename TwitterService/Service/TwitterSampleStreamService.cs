namespace TwitterService.Service;

public class TwitterSampleStreamService : ITwitterSampleStreamService
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<TwitterSampleStreamService> _logger;
    private readonly RestClient _restClient;
    private int tweetCount = 0;
    private readonly ITwitterStatService _twitterStatService;

    public TwitterSampleStreamService(IConfiguration configuration, ILogger<TwitterSampleStreamService> logger, ITwitterStatService twitterStatService)
    {
        _logger = logger;
        _configuration = configuration;

        var baseClientUrl = _configuration.GetValue<string>(TwitterConstant.TWITTER_BASE_CLIENT_URL);
        var baseClientVersion = _configuration.GetValue<string>(TwitterConstant.TWITTER_BASE_CLIENT_VERSION);
        var twitterClientId = _configuration.GetValue<string>(TwitterConstant.TWITTER_API_KEY);
        var twitterClientSecret = _configuration.GetValue<string>(TwitterConstant.TWITTER_API_SECRET);

        var options = new RestClientOptions($"{baseClientUrl}/{baseClientVersion}");

        _restClient = new RestClient(options)
        {
            Authenticator = new TwitterAuthenticator(baseClientUrl, twitterClientId, twitterClientSecret)
        };

        _twitterStatService = twitterStatService;
    }

    public async Task StartTwitterSampleStreamAsync()
    {
        var twitterBearerToken = _configuration.GetValue<string>(TwitterConstant.TWITTER_API_BEARER_TOKEN);
        var credentials = new TwitterCredentials
        {
            BearerToken = twitterBearerToken,
        };

        var client = new TwitterClient(credentials);
        var stream = client.StreamsV2.CreateSampleStream();

        stream.TweetReceived += async (sender, args) =>
        {
            try
            {
                _twitterStatService.IncrementTweetCount();
                var tweet = JsonSerializer.Deserialize<TwitterSampleStream>(args.Json);

                if (tweet == null)
                {
                    return;
                }

                var text = tweet.data.text;

                var regex = new Regex(@"#\w+");
                var hashtagMatches = regex.Matches(text).ToList();

                foreach (var hashtag in hashtagMatches)
                {
                    var stat = new StatTracker
                    {
                        Count = 1,
                        Value = hashtag.Value
                    };

                    _twitterStatService.Add(stat);
                }
            }
            catch (Exception)
            {

                stream.StopStream();
            }
        };

        await stream.StartAsync();
    }
}