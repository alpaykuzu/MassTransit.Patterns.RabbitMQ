using MassTransit.Shared.Messages;

namespace MassTransit.WorkerService.Publisher
{
    public class Worker : BackgroundService
    {
        readonly IPublishEndpoint _publishEndpoint;

        public Worker(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int i = 0;
            while (true)
            {
                Message message = new Message
                {
                    Text = $"Message {i++}"
                };
                await _publishEndpoint.Publish(message, stoppingToken);
            }
            ;
        }
    }
}
