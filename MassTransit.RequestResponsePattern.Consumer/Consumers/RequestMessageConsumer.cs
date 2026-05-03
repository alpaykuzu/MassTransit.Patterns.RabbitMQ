using MassTransit.Shared.RequestResponseMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransit.RequestResponsePattern.Consumer.Consumers
{
    public class RequestMessageConsumer : IConsumer<RequestMessage>
    {
        public Task Consume(ConsumeContext<RequestMessage> context)
        {
            Console.WriteLine(context.Message.Text);

            context.RespondAsync<ResponseMessage>(new ResponseMessage
            {
                Text = $"{context.Message.MessageNo}. response to request"
            });

            return Task.CompletedTask;
        }
    }
}

