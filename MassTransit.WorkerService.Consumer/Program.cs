using MassTransit;
using MassTransit.WorkerService.Consumer;
using MassTransit.WorkerService.Consumer.Consumers;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddMassTransit(configurator =>
{
    configurator.AddConsumer<MessageConsumer>();
    configurator.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("url");

        cfg.ReceiveEndpoint("message-queue", e =>
        {
            e.ConfigureConsumer<MessageConsumer>(context);
        });
    });
});

var host = builder.Build();
await host.RunAsync();
