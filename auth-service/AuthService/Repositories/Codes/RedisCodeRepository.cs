using AuthService.Contexts;
using StackExchange.Redis;
using System.Text;

namespace AuthService.Repositories.Codes;

public class RedisCodeRepository : ICodeRepository {
    private readonly IDatabase _database;
    private const int Code = 1111;
    private const int AttemptsInitialCount = 3;
    private const int DatabaseId = 1;

    public RedisCodeRepository(RedisContext context) {
        _database = context.GetDatabase(DatabaseId);
    }

    public async Task<(bool, long)> CreateAsync(string credential, CancellationToken cancellationToken) {
        var key = Encoding.Unicode.GetBytes(credential);

        var val = await _database.StringGetAsync(key);

        if (val.HasValue) {
            var expiryTime = await _database.KeyTimeToLiveAsync(key);

            var expiresAt = DateTimeOffset.UtcNow + expiryTime;

            return (true, expiresAt.Value.ToUnixTimeMilliseconds());
        }

        var value = new byte[8];

        BitConverter.GetBytes(AttemptsInitialCount).CopyTo(value, 0);

        BitConverter.GetBytes(Code).CopyTo(value, 4);

        await _database.StringSetAsync(key, value, TimeSpan.FromMinutes(5));

        return (false, DateTimeOffset.UtcNow.AddMinutes(5).ToUnixTimeMilliseconds());
    }

    public async Task<(CodeResponse, int)> TryCodeAsync(string credential, int tryCode, CancellationToken cancellationToken) {
        var key = Encoding.Unicode.GetBytes(credential);

        var val = await _database.StringGetAsync(key);

        if (val.HasValue) {
            var byteVal = (byte[])val;
            var attempts = ConvertLittleEndian(byteVal.AsSpan(0, 4));
            var code = ConvertLittleEndian(byteVal.AsSpan(4, 4));

            if (code != tryCode) {
                if (--attempts == 0) {
                    await _database.KeyDeleteAsync(key);

                    return (CodeResponse.InvalidCode, attempts);
                }

                BitConverter.GetBytes(attempts).CopyTo(byteVal, 0);

                await _database.StringSetAsync(key, byteVal);

                return (CodeResponse.InvalidCode, attempts);
            }

            await _database.KeyDeleteAsync(key);

            return (CodeResponse.Success, attempts);
        }

        return (CodeResponse.CodeNotExists, 0);
    }

    private static int ConvertLittleEndian(ReadOnlySpan<byte> array) {
        int pos = 0;
        int result = 0;
        foreach (byte by in array) {
            result |= by << pos;
            pos += 8;
        }
        return result;
    }
}