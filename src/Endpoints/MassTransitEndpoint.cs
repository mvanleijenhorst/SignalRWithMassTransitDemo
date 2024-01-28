using MassTransit;
using MassTransit.SignalR.Contracts;
using SignalRBlazorDemo.MassTransitExample;
using SignalRBlazorDemo.SignalR;

namespace SignalRBlazorDemo.Endpoints;

public class MassTransitEndpoint
{
    private readonly IPublishEndpoint _publishEndpoint;

    public MassTransitEndpoint(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }


    public async Task<string> GetChat()
    {
        var message = new ChatEvent("MassTransit", "Hello from MassTransit");
        await _publishEndpoint.Publish(message);
        return "Message send";
    }
}


