using SignalRBlazorDemo.Components;
using Microsoft.AspNetCore.ResponseCompression;
using SignalRBlazorDemo.SignalR;
using SignalRBlazorDemo.Endpoints;
using MassTransit;
using SignalRBlazorDemo.MassTransitExample;

namespace SignalRBlazorDemo;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // API Endpoint Controllers
        builder.Services.AddTransient<MassTransitEndpoint>();

        // SignalR
        builder.Services.AddResponseCompression(opts =>
        {
            opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                  new[] { "application/octet-stream" });
        });

        // mass transit
        builder.Services.AddMassTransit(x =>
        {
            x.AddConsumer<ChatEventMessageConsumer>();

            // Gebruik in-memory transport
            x.UsingInMemory((context, cfg) =>
            {
                //cfg.TransportConcurrencyLimit = 100; // Je kunt deze waarde aanpassen op basis van je behoeften

                cfg.ConfigureEndpoints(context);
            });
        });

        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();
        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseAntiforgery();

        // API Endpoints
        app.MapGet("/api/chat", (MassTransitEndpoint endpoint) => endpoint.GetAsync());

        // SignalR
        app.UseResponseCompression();
        app.MapHub<ChatHub>("/chathub");

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}
