using MassTransit;
using MassTransit.SignalR;
using Microsoft.AspNetCore.ResponseCompression;
using SignalRBlazorDemo.MassTransitExample;
using SignalRBlazorDemo.SignalR;

namespace SignalRBlazorDemo.Configurations
{
    public static class MassTransitWithBackplaneExtensions
    {
        public static IServiceCollection AddMassTransitWithBackplane(this IServiceCollection services)
        {
            services.AddMassTransit(service =>
            {
                service.SetKebabCaseEndpointNameFormatter();
                service.AddSignalRHub<ChatHub>();
                service.UsingInMemory((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });
                service.AddConsumersFromNamespaceContaining<ChatEventMessageConsumer>();
            });

            return services;
        }
    }
}
