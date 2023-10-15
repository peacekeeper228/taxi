namespace AuthService.Repositories.Codes;

public interface ICodeRepository {
    Task<(bool, long)> CreateAsync(string credential, CancellationToken cancellationToken);
    Task<(CodeResponse, int)> TryCodeAsync(string credential, int tryCode, CancellationToken cancellationToken);
}