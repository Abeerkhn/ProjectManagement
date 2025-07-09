using MediatR;
using Softwash.Infrastructure.ExternalServices.Firebase;

namespace Softwash.Infrastructure;
public static class ServiceExtension
{
    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();
        // GetClaims.Initialize(httpContextAccessor);
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
      
        services.Scan(scan => scan
                .FromAssemblies(Assembly.GetExecutingAssembly())
                .AddClasses(classes => classes.Where(type => type.GetConstructors()
                .Any(ctor => ctor.GetParameters()
                .Any(param => param.ParameterType == typeof(IUnitOfWork)))))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

 
        services.AddDbContext<MainContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), sqlServerOptions =>
            {
                sqlServerOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null
                );

                sqlServerOptions.CommandTimeout(60);
            });
        });


        return services;
    }
}
