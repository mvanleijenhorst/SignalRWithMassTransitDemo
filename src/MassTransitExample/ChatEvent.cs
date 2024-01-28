using MassTransit;

namespace SignalRBlazorDemo.MassTransitExample;

[MessageUrn("chat-event")]
public record ChatEvent(string User, string Content);
