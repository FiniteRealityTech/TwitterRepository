var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddLocalConfiguration();
});

builder.Host
    .UseSerilog((context, lc) => lc
        .WriteTo.Console()
        .WriteTo.Debug()
        .WriteTo.File("./logs/log_", rollingInterval: RollingInterval.Hour));

builder.Services.AddTwitterService();
builder.Services.AddHostedService<TwitterFeedFetchHostedService>();
builder.Services.AddHostedService<TwitterFeedProcessHostedService>();

var app = builder.Build();
app.Run();