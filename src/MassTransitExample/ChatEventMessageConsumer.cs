using MassTransit;
using Microsoft.AspNetCore.SignalR;
using SignalRBlazorDemo.SignalR;

namespace SignalRBlazorDemo.MassTransitExample;

public class ChatEventMessageConsumer(IHubContext<ChatHub> hubContext) 
    : IConsumer<ChatEvent>
{
    private readonly IHubContext<ChatHub> _hubContext = hubContext;

    public async Task Consume(ConsumeContext<ChatEvent> context)
    {
        await _hubContext.Clients.All.SendAsync(nameof(ChatEvent), context.Message.User, context.Message.Content);
    }
}

