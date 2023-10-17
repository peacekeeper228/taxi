namespace Gateway.Clients.Auth;

public interface IAuthServiceClient {
    Task<(bool, long)> SendCodeAsync(string? phone, string? email, CancellationToken cancellationToken);

    Task<(AuthResponse, int)> TryCodeAsync(string credential, int code, CancellationToken cancellationToken);
}