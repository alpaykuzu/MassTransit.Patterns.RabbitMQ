using MassTransit;
using MassTransit.Shared.Messages;

string rabbitMQUri = "url";

string queueName = "test-queue";

IBusControl bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.Host(rabbitMQUri);
});

ISendEndpoint sendEndpoint = await bus.GetSendEndpoint(new Uri($"{rabbitMQUri}/{queueName}"));


Console.WriteLine("Enter a message to send:");
string message = Console.ReadLine();
await sendEndpoint.Send<IMessage>(new Message{ Text = message });


Console.Read();