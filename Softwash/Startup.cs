using Microsoft.Extensions.DependencyInjection;
using Softwash.Infrastructure.Common.Shopify;
using Microsoft.Extensions.DependencyInjection;


namespace Softwash;
public class Startup(IConfiguration configuration)
{
    public IConfiguration Configuration { get; } = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        AddSwaggerDoc(services);


        Softwash.Application.ServiceExtension.ConfigureApplicationServices(services, configuration);
        Softwash.Infrastructure.ServiceExtension.ConfigureInfrastructureServices(services, configuration);

        services.AddSingleton<AuthState>();
        services.AddControllers();
        services.AddControllers(options =>
        {
            var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
                            .Build();
            options.Filters.Add(new AuthorizeFilter(policy));
        })
       .AddJsonOptions(options =>
       {
           options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
           options.JsonSerializerOptions.PropertyNamingPolicy = null;
           options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
           options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
       })
       .ConfigureApiBehaviorOptions(options =>
       {
           options.InvalidModelStateResponseFactory = context =>
           {
               return new BadRequestObjectResult(new RequestValidationFilter(context))
               {
                   StatusCode = 400
               };
           };
       });

        services.AddRazorPages();
        services.AddRazorComponents()
                            .AddInteractiveServerComponents();

        services.AddScoped<ExceptionHandling>();
       

    


        var shopifySection = Configuration.GetSection("Shopify");
        var storeName = shopifySection["StoreName"];
        var accessToken = shopifySection["AccessToken"];

        services.AddSingleton(sp => ShopifyClientFactory.CreateShopifyClient(Configuration));

        services.AddCors(o =>
        {
            o.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        GetClaims.Initialize(httpContextAccessor);
        app.UseMiddleware<ExceptionHandling>();
        app.UseStaticFiles();   
        app.UseHttpsRedirection();
      
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseCors("CorsPolicy");

        // Swagger configuration can stay here
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Softwash"));

        app.UseStaticFiles();
        app.UseAntiforgery();

       
        app.UseEndpoints(endpoints =>
        {
           
         //  endpoints.MapFallbackToPage("/");

              endpoints.MapControllers();

        });
    }

    private void AddSwaggerDoc(IServiceCollection services)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })

    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JWTKey.Key)),
            ValidateIssuer = false,
            ValidateAudience = false,
            RequireExpirationTime = false,
            ValidateLifetime = true
        };
    });

        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme."
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                      new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                }
            });
        });
    }

    static async Task Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var shopifyClient = ShopifyClientFactory.CreateShopifyClient(configuration);
        var graphQLService = new GraphQLService(configuration );
    }

}
