using MassTransit;
using SignalRBlazorDemo.MassTransitExample;

namespace SignalRBlazorDemo.Configurations;

public static class MassTransitWithConsumerOnlyExtensions
{
    public static IServiceCollection AddMassTransitWithBasicSignalR(this IServiceCollection services)
    {
        services.AddMassTransit(service =>
        {
            service.AddConsumer<ChatEventMessageConsumer>();

            service.UsingInMemory((context, cfg) =>
            {
                cfg.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}
