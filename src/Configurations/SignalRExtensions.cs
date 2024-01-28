using Microsoft.AspNetCore.ResponseCompression;
using SignalRBlazorDemo.SignalR;

namespace SignalRBlazorDemo.Configurations;

public static class SignalRExtensions
{
    public static IServiceCollection AddBasicSignalR(this IServiceCollection services)
    {
        services.AddSignalR();
        services.AddResponseCompression(opts =>
        {
            opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                  new[] { "application/octet-stream" });
        });

        return services;
    }

    public static WebApplication UseSignalR(this WebApplication app)
    {
        app.UseResponseCompression();
        app.MapHub<ChatHub>("/chathub");

        return app;
    }
}
