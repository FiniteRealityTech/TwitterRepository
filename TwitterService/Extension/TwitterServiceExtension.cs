namespace TwitterService.Extension;

public static class TwitterServiceExtension
{

    public static IServiceCollection AddTwitterService(this IServiceCollection services)
    {
        services.AddServicesWithAttributeOfType<ScopedServiceAttribute>();
        services.AddSingleton<ITwitterStatService, TwitterStatService>();
        return services;
    }
}