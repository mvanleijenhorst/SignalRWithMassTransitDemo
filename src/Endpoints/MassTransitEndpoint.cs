using MassTransit;
using MassTransit.Transports;
using Microsoft.AspNetCore.Mvc;
using SignalRBlazorDemo.MassTransitExample;

namespace SignalRBlazorDemo.Endpoints;

public class MassTransitEndpoint
{
    private readonly IPublishEndpoint _publishEndpoint;

    public MassTransitEndpoint(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }


    public async Task<string> GetAsync()
    {
        var message = new ChatEvent("MassTransit", "Hello from MassTransit");
        await _publishEndpoint.Publish(message);
        return "Message send";
    }
}
