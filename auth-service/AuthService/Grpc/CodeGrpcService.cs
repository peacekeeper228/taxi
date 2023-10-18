using AuthService.Proto;
using AuthService.Services.Codes;
using AuthService.Repositories.Codes;
using Grpc.Core;

namespace AuthService.Grpc;

public class CodeGrpcService : Auth.AuthBase {
    private readonly CodeService _codeService;

    public CodeGrpcService(
        CodeService codeService
    ) {
        _codeService = codeService;
    }

    public override async Task<SendCodeResponse> SendCode(SendCodeRequest request, ServerCallContext context) {
        var credential = request.CredentialsCase switch {
            SendCodeRequest.CredentialsOneofCase.Phone => request.Phone,
            SendCodeRequest.CredentialsOneofCase.Email => request.Email,
            _ => throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid credentials provided")),
        };

        var (existed, expiresAt) = await _codeService.CreateAsync(credential, context.CancellationToken);

        return new SendCodeResponse {
            Existed = existed,
            ExpiresAt = expiresAt,
        };
    }

    public override async Task<TryCodeResponse> TryCode(TryCodeRequest request, ServerCallContext context) {
        var (response, attempts) = await _codeService.TryCodeAsync(request.Credentials, request.Code, context.CancellationToken);

        if (response == CodeResponse.CodeNotExists) {
            return new TryCodeResponse {
                CodeNotExists = new TryCodeResponse.Types.CodeNotExists(),
            };
        }

        if (response == CodeResponse.InvalidCode) {
            return new TryCodeResponse {
                InvalidCode = new TryCodeResponse.Types.InvalidCode {
                    Attempts = attempts,
                },
            };
        }

        return new TryCodeResponse {
            Success = new TryCodeResponse.Types.Success(),
        };
    }

    public async Task<CheckTokenResponse> CheckToken(CheckTokenRequest request, ServerCallContext context) {
        return new CheckTokenResponse {
            Success = new CheckTokenResponse.Types.Success {
                UserId = 1337,
            },
        };
    }
}