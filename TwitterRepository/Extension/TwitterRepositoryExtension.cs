namespace TwitterRepository.Extension;

public static class TwitterRepositoryExtension
{
    public static IServiceCollection AddTwitterRepository(this IServiceCollection services)
    {
        services.AddServicesWithAttributeOfType<ScopedServiceAttribute>();
        return services;
    }

    public static IConfigurationBuilder AddLocalConfiguration(this IConfigurationBuilder builder)
    {
        var tempConfig = builder.Build();
        return builder.Add(new LocalConfigurationSource(tempConfig));
    }
}