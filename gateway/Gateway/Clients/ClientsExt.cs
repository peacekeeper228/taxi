using Gateway.Clients.Auth;
using Gateway.Config;
using Microsoft.Extensions.Options;
using DbInterface.Proto;
using Gateway.Clients.DbProvider;

namespace Gateway.Clients;

public static class ClientsExt {
    public static IServiceCollection AddClients(this IServiceCollection services) {
        services
            .AddGrpcClient<AuthService.Proto.Auth.AuthClient>((serviceProvider, options) => {
                var config = serviceProvider.GetRequiredService<IOptions<ClientsOptions>>();
                options.Address = new Uri(config.Value.AuthServiceHost);
            });
        services
            .AddGrpcClient<Taxi.TaxiClient>((serviceProvider, options) => {
                var config = serviceProvider.GetRequiredService<IOptions<ClientsOptions>>();
                options.Address = new Uri(config.Value.DbProviderHost);
            });

        return services
            .AddScoped<IAuthServiceClient, GrpcAuthServiceClient>()
            .AddScoped<IDbProviderClient, GrpcDbProviderClient>()
            ;
    }
}