using SignalRBlazorDemo.Endpoints;

namespace SignalRBlazorDemo.Configurations;

public static class EndpointExtensions
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services)
    {
        services.AddSwaggerGen();
        services.AddEndpointsApiExplorer();
        services.AddTransient<MassTransitEndpoint>();
        return services;
    }

    public static WebApplication UseEndpoints(this WebApplication app)
    {
        app.MapGet("/api/chat", (MassTransitEndpoint endpoint) => endpoint.GetChat());
        app.MapGet("/api/chat2all", (MassTransitEndpoint endpoint) => endpoint.GetChatToAll());

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        });

        return app;
    }
}
