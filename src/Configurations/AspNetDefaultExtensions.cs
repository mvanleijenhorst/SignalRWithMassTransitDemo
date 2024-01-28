using SignalRBlazorDemo.Components;

namespace SignalRBlazorDemo.Configurations
{
    public static class AspNetDefaultExtensions
    {
        public static IServiceCollection AddAspNetDefault(this IServiceCollection services)
        {
            services.AddRazorComponents()
                .AddInteractiveServerComponents();

            return services;
        }

        public static WebApplication UseAspNetDefault(this WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAntiforgery();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            return app;
        }
    }
}
