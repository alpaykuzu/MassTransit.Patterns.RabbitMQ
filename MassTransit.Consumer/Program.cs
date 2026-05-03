using MassTransit;
using MassTransit.Consumer.Consumers;
using MassTransit.Shared.Messages;

string rabbitMQUri = "url";

string queueName = "test-queue";

IBusControl bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.Host(rabbitMQUri);

    cfg.ReceiveEndpoint(queueName, endpoint =>
    {
        endpoint.Consumer<MessageConsumer>();
    });
});

await bus.StartAsync();

Console.Read();
