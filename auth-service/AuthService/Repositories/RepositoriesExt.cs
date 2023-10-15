using AuthService.Contexts;
using AuthService.Repositories.Codes;

namespace AuthService.Repositories;

public static class RepositoriesExt {
    public static IServiceCollection AddRepositories(this IServiceCollection services) {
        return services
            .AddSingleton<RedisContext>()
            .AddScoped<ICodeRepository, RedisCodeRepository>();
    }
}