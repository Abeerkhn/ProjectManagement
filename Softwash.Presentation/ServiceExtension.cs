namespace Softwash.Presentation;

public static class ServiceExtension
{
    public static IServiceCollection ConfigurePresentationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllersWithViews();
        services.AddRazorPages();         

        return services;
    }
}