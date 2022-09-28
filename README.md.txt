# Setup

## Credentials
** Production version would use encrypted credentials or a vault.

### Customize
Go to Program.cs and set your credentials path in the configuration builder.

Place the following file at the same level as the cloned repository (2 levels above project root)
Settings/TwitterSettings.json

Replace {yourbearertoken} with your bearer token.

### File format
{
	"TwitterSettings":
	{	
		"TwitterApiBearerToken": "{yourbearertoken}",
		"TwitterBaseClientUrl": "https://api.twitter.com",
		"TwitterBaseClientVersion": "2",
		"TwitterSampleStreamPath": "tweets/sample/stream"
	}
}