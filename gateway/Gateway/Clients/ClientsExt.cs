using Gateway.Clients.Auth;
using Gateway.Config;
using Microsoft.Extensions.Options;

namespace Gateway.Clients;

public static class ClientsExt {
    public static IServiceCollection AddClients(this IServiceCollection services) {
        services
            .AddGrpcClient<AuthService.Proto.Auth.AuthClient>((serviceProvider, options) => {
                var config = serviceProvider.GetRequiredService<IOptions<ClientsOptions>>();
                options.Address = new Uri(config.Value.AuthServiceHost);
            });

        return services
            .AddScoped<IAuthServiceClient, GrpcAuthServiceClient>();
    }
}