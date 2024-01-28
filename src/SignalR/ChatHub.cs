using Microsoft.AspNetCore.SignalR;
using SignalRBlazorDemo.MassTransitExample;

namespace SignalRBlazorDemo.SignalR;

public class ChatHub : Hub
{
    public async Task SendAsync(string user, string message)
    {
        await Clients.All.SendAsync(nameof(ChatEvent), user, message);
    }
}
