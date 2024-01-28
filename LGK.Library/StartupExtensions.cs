using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Sinks.Grafana.Loki;

namespace LGK.Library;

public static class StartupExtensions
{
    public static string GetAssemblyName()
    {
        return System.Reflection.Assembly.GetEntryAssembly()?.GetName().Name ?? string.Empty;
    }

    public static string GetAssemblyVersion()
    {
        return System.Reflection.Assembly.GetEntryAssembly()?.GetName().Version?.ToString() ?? string.Empty;
    }

    public static void AddMicroService(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = GetAssemblyName(), Version = GetAssemblyVersion() });
            c.EnableAnnotations();
            c.AddSecurityDefinition("Bearer",
                new OpenApiSecurityScheme
                {
                    Description = "Untuk penggunaan di swagger di kolom value Contoh: 'Bearer tokenAnda'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
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
                    Array.Empty<string>()
                }
            });
        });

        services.AddSwaggerGen(options => { options.CustomSchemaIds(type => type.ToString()); });

        services.AddSession(options =>
        {
            // Set a short timeout for easy testing.
            options.IdleTimeout = TimeSpan.FromHours(3);
            options.Cookie.HttpOnly = true;
            // Make the session cookie essential
            options.Cookie.IsEssential = true;
        });

        services.AddDistributedMemoryCache();

        services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                                       ForwardedHeaders.XForwardedProto;
            // Only loopback proxies are allowed by default.
            // Clear that restriction because forwarders are enabled by explicit 
            // configuration.
            options.KnownNetworks.Clear();
            options.KnownProxies.Clear();
        });
    }

    public static void UseMicroServiceConfig(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("../swagger/v1/swagger.json", $"RMS Service {GetAssemblyName()}"));

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseSession();


        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
        });

        app.UseAuthentication();
        app.UseAuthorization();
        //app.UseForwardedHeaders();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }

    public static IHostBuilder UseMicroServiceBuilder(this IHostBuilder builder)
    {
        return builder.UseSerilog();
    }

    public static IHostBuilder UseSerilog(this IHostBuilder builder)
    {
        Serilog.ILogger log = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.GrafanaLoki(
                "http://localhost:3100", new[] { new LokiLabel() { Key = "App", Value = GetAssemblyName() } })
            .CreateLogger();
        return builder.UseSerilog(log);
    }
}