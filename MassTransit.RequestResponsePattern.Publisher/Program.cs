using MassTransit;
using MassTransit.Shared.RequestResponseMessages;

string rabbitMQUri = "url";

IBusControl bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.Host(rabbitMQUri);
});

await bus.StartAsync();

var request = bus.CreateRequestClient<RequestMessage>(new Uri($"{rabbitMQUri}/request-queue"));

int i = 0;
while (true)
{
    await Task.Delay(200);
    var response = await request.GetResponse<ResponseMessage>(new RequestMessage
    {
        MessageNo = i,
        Text = $"{i++}. request"
    }); 

    Console.WriteLine(response.Message.Text);
};

Console.Read();