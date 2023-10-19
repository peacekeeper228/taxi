namespace Gateway.Clients.DbProvider;

public interface IDbProviderClient {
    Task GetCustomerByEmailAsync(string email, CancellationToken cancellationToken);
    Task GetDriverByEmailAsync(string email, CancellationToken cancellationToken);
    Task GetCustomerEmailAsync(string orderNumber, CancellationToken cancellationToken);
    Task GetDriverEmailAsync(string orderNumber, CancellationToken cancellationToken);
    Task GetTicketInfoAsync(string code, CancellationToken cancellationToken);
    Task<bool> CreateCustomerAsync(
        string firstname,
        string lastname,
        string patronymic,
        string email,
        CancellationToken cancellationToken
    );
    Task<bool> CreateDriverAsync(
        string firstname,
        string lastname,
        string patronymic,
        string email,
        CancellationToken cancellationToken
    );
    Task<bool> CreateOrderAsync(
        float sourcelat,
        float sourcelng,
        float destlat,
        float destlng,
        float pathlength,
        string customer,
        string driver,
        CancellationToken cancellationToken
    );
}