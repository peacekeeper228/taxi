using StackExchange.Redis;
using Microsoft.Extensions.Options;
using AuthService.Config;

namespace AuthService.Contexts;

public class RedisContext {
    private readonly ConnectionMultiplexer _connectionMultiplexer;

    public RedisContext(IOptions<RedisConfig> options) {
        _connectionMultiplexer = ConnectionMultiplexer.Connect($"{options.Value.HostName}:{options.Value.Port},password={options.Value.Password}");
    }

    public IDatabase GetDatabase(int id) {
        return _connectionMultiplexer.GetDatabase(id);
    }
}