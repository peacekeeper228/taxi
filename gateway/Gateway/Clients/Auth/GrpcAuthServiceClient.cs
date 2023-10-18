using AuthService.Proto;

namespace Gateway.Clients.Auth;

public class GrpcAuthServiceClient : IAuthServiceClient {
    private readonly AuthService.Proto.Auth.AuthClient _client;

    public GrpcAuthServiceClient(
        AuthService.Proto.Auth.AuthClient client
    ) {
        _client = client;
    }

    public async Task<(bool, long)> SendCodeAsync(string? phone, string? email, CancellationToken cancellationToken) {
        var request = new SendCodeRequest();

        if (string.IsNullOrEmpty(phone)) {
            request.Email = email;
        }
        else {
            request.Phone = phone;
        }

        var response = await _client.SendCodeAsync(request, cancellationToken: cancellationToken);

        return (response.Existed, response.ExpiresAt);
    }

    public async Task<(AuthResponse, int)> TryCodeAsync(string credential, int code, CancellationToken cancellationToken) {
        var request = new TryCodeRequest {
            Credentials = credential,
            Code = code,
        };

        var response = await _client.TryCodeAsync(request, cancellationToken: cancellationToken);

        if (response.StatusCase == TryCodeResponse.StatusOneofCase.CodeNotExists) {
            return (AuthResponse.CodeNotExists, 0);
        }

        if (response.StatusCase == TryCodeResponse.StatusOneofCase.InvalidCode) {
            return (AuthResponse.InvalidCode, response.InvalidCode.Attempts);
        }

        return (AuthResponse.Success, 0);
    }
}