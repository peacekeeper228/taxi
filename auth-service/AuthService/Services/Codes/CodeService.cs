using AuthService.Repositories.Codes;

namespace AuthService.Services.Codes;

public class CodeService {
    private readonly ICodeRepository _codeRepository;

    public CodeService(
        ICodeRepository codeRepository
    ) {
        _codeRepository = codeRepository;
    }

    public Task<(bool, long)> CreateAsync(string credential, CancellationToken cancellationToken) {
        return _codeRepository.CreateAsync(credential, cancellationToken);
    }

    public Task<(CodeResponse, int)> TryCodeAsync(string credential, int tryCode, CancellationToken cancellationToken) {
        return _codeRepository.TryCodeAsync(credential, tryCode, cancellationToken);
    }
}