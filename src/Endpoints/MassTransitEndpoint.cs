using MassTransit;
using MassTransit.SignalR.Contracts;
using MassTransit.SignalR.Utils;
using Microsoft.AspNetCore.SignalR.Protocol;
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

    public async Task<string> GetChatToAll()
    {
        IReadOnlyList<IHubProtocol> protocols = new IHubProtocol[] { new JsonHubProtocol() };
        await _publishEndpoint.Publish<All<ChatHub>>(new
        {
            Messages = protocols.ToProtocolDictionary(nameof(ChatEvent), new object[] { "backend-process", "Hello" })
        });
        return "Message send";
    }

}


