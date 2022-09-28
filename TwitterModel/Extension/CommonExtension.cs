namespace TwitterModel.Extension;

public static class CommonExtension
{
    public static TJson? ToJsonObject<TJson>(this string value)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        return JsonSerializer.Deserialize<TJson>(value, options);
    }

    public static IConfigurationBuilder AddLocalConfiguration(this IConfigurationBuilder builder)
    {
        var tempConfig = builder.Build();
        return builder.Add(new LocalConfigurationSource(tempConfig));
    }
}