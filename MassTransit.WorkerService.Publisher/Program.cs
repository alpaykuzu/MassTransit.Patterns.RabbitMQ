using MassTransit;
using MassTransit.WorkerService.Publisher;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddMassTransit(configurator =>
{
    configurator.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("url");
    });
});

builder.Services.AddHostedService(provider =>
{
    using IServiceScope scope = provider.CreateScope();
    IPublishEndpoint publishEndpoint = scope.ServiceProvider.GetRequiredService<IPublishEndpoint>();    
    return new Worker(publishEndpoint);
});

var host = builder.Build();
host.Run();