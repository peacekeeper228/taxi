using DbInterface.Proto;

namespace Gateway.Clients.DbProvider;

public class GrpcDbProviderClient : IDbProviderClient {
    private readonly Taxi.TaxiClient _taxiClient;

    public GrpcDbProviderClient(
        Taxi.TaxiClient taxiClient
    ) {
        _taxiClient = taxiClient;
    }

    public async Task<bool> CreateCustomerAsync(string firstname, string lastname, string patronymic, string email, CancellationToken cancellationToken)
    {
        var request = new BIOscetchWithEmail {
            Firstname = firstname,
            Lastname = lastname,
            Patronymic = patronymic,
            Email = email,
        };

        var response = await _taxiClient.CreateCustomerAsync(request, cancellationToken: cancellationToken);

        return true;
    }

    public async Task<bool> CreateDriverAsync(string firstname, string lastname, string patronymic, string email, CancellationToken cancellationToken)
    {
        var request = new BIOscetchWithEmail {
            Firstname = firstname,
            Lastname = lastname,
            Patronymic = patronymic,
            Email = email,
        };

        var response = await _taxiClient.CreateDriverAsync(request, cancellationToken: cancellationToken);

        return true;
    }

    public async Task<bool> CreateOrderAsync(float sourcelat, float sourcelng, float destlat, float destlng, float pathlength, string customer, string driver, CancellationToken cancellationToken)
    {
        var request = new OrderMessage {
            Sourcelat = sourcelat,
            Sourcelng = sourcelng,
            Destlat = destlat,
            Destlng = destlng,
            Pathlength = pathlength,
            Customer = customer,
            Driver = driver,
        };

        var response = await _taxiClient.CreateOrderAsync(request, cancellationToken: cancellationToken);

        return true;
    }

    public async Task GetCustomerByEmailAsync(string email, CancellationToken cancellationToken)
    {
        var request = new EmailMessage {
            Email = email,
        };

        var response = await _taxiClient.GetCustomerByEmailAsync(request, cancellationToken: cancellationToken);
    }

    public async Task GetCustomerEmailAsync(string orderNumber, CancellationToken cancellationToken)
    {
        var request = new OrderNumber {
            Ordernumber = orderNumber,
        };

        var response = await _taxiClient.GetCustomerEmailAsync(request, cancellationToken: cancellationToken);
    }

    public async Task GetDriverByEmailAsync(string email, CancellationToken cancellationToken)
    {
        var request = new EmailMessage {
            Email = email,
        };

        var response = await _taxiClient.GetDriverByEmailAsync(request, cancellationToken: cancellationToken);
    }

    public async Task GetDriverEmailAsync(string orderNumber, CancellationToken cancellationToken)
    {
        var request = new OrderNumber {
            Ordernumber = orderNumber,
        };

        var response = await _taxiClient.GetDriverEmailAsync(request, cancellationToken: cancellationToken);
    }

    public async Task GetTicketInfoAsync(string code, CancellationToken cancellationToken)
    {
        var request = new CodeNumber {
            Code = code,
        };

        var response = await _taxiClient.GetTicketInfoAsync(request, cancellationToken: cancellationToken);
    }
}