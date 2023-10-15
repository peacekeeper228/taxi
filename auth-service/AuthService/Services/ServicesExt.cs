using AuthService.Services.Codes;

namespace AuthService.Services;

public static class ServicesExt {
    public static IServiceCollection AddServices(this IServiceCollection services) {
        return services
            .AddScoped<CodeService>();
    }
}