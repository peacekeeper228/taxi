using System.Net;
using Gateway.Clients.DbProvider;
using Gateway.Controllers.Auth.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers.Orders;

[Route("gateway/[controller]")]
public class OrderController : Controller {
    private readonly IDbProviderClient _dbProviderClient;

    public OrderController(
        IDbProviderClient dbProviderClient
    ) {
        _dbProviderClient = dbProviderClient;
    }

    /// <summary>
    /// Create order
    /// </summary>
    /// <param name="sourcelat">Source latitude</param>
    /// <param name="sourcelng">Source longitude</param>
    /// <param name="destlat">Destination latitude</param>
    /// <param name="destlng">Destination longitude</param>
    /// <param name="pathlength">Length of path</param>
    /// <param name="customer">Customer email</param>
    /// <param name="driver">Driver email</param>
    /// <param name="cancellationToken"></param>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> CreateOrderAsync(
        float sourcelat,
        float sourcelng,
        float destlat,
        float destlng,
        float pathlength,
        string customer,
        string driver,
        CancellationToken cancellationToken
    ) {
        var response = await _dbProviderClient.CreateOrderAsync(
            sourcelat,
            sourcelng,
            destlat,
            destlng,
            pathlength,
            customer,
            driver,
            cancellationToken
        );

        return Ok();
    }
}