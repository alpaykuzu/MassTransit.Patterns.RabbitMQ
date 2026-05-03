using MassTransit;
using MassTransit.RequestResponsePattern.Consumer.Consumers;

string rabbitMQUri = "url";

IBusControl bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.Host(rabbitMQUri);

    cfg.ReceiveEndpoint("request-queue", endpoint =>
    {
        endpoint.Consumer<RequestMessageConsumer>();
    });
});

await bus.StartAsync();

Console.Read();