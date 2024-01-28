using SignalRBlazorDemo.Configurations;

namespace SignalRBlazorDemo;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services
            .AddAspNetDefault()
            .AddEndpoints()
            .AddBasicSignalR()
            //.AddMassTransitWithBasicSignalR();
            .AddMassTransitWithBackplane();

        builder.Build()
           .UseAspNetDefault()
           .UseEndpoints()
           .UseSignalR()
           .Run();
    }
}
