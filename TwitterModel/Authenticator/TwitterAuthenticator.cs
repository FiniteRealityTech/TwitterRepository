// https://restsharp.dev/usage.html#authenticator

namespace TwitterModel.Authenticator;

public class TwitterAuthenticator : AuthenticatorBase
{
    readonly string _baseUrl;
    readonly string _clientId;
    readonly string _clientSecret;

    public TwitterAuthenticator(string baseUrl, string clientId, string clientSecret) : base("")
    {
        _baseUrl = baseUrl;
        _clientId = clientId;
        _clientSecret = clientSecret;
    }

    protected override async ValueTask<Parameter> GetAuthenticationParameter(string accessToken)
    {
        var token = string.IsNullOrWhiteSpace(accessToken) ? await GetToken() : Token;
        Token = token;
        return new HeaderParameter(KnownHeaders.Authorization, token);
    }

    private async Task<string?> GetToken()
    {
        var options = new RestClientOptions(_baseUrl);
        using var client = new RestClient(options)
        {
            Authenticator = new HttpBasicAuthenticator(_clientId, _clientSecret),
        };

        var request = new RestRequest("oauth2/token")
            .AddParameter("grant_type", "client_credentials");
        var response = await client.PostAsync<TwitterToken>(request);
        ArgumentNullException.ThrowIfNull(response);

        return response.AccessToken;
    }
}