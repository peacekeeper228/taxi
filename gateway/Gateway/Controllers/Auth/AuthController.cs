using System.Net;
using Gateway.Clients.Auth;
using Gateway.Clients.DbProvider;
using Gateway.Controllers.Auth.Responses;
using Gateway.Controllers.Auth.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers.Auth;

[Route("gateway/[controller]")]
public class AuthController : Controller {
    private readonly IAuthServiceClient _authServiceClient;
    private readonly IDbProviderClient _dbProviderClient;

    public AuthController(
        IAuthServiceClient authServiceClient,
        IDbProviderClient dbProviderClient
    ) {
        _authServiceClient = authServiceClient;
        _dbProviderClient = dbProviderClient;
    }

    /// <summary>
    /// Send short-live code on phone or email
    /// Either phone or email must be provided
    /// </summary>
    /// <param name="phone">Phone (optional)</param>
    /// <param name="email">Email (optional)</param>
    /// <param name="cancellationToken"></param>
    [HttpPost]
    [Route("sendcode")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Conflict)]
    public async Task<IActionResult> SendCodeAsync(string? phone, string? email, CancellationToken cancellationToken) {
        if (string.IsNullOrEmpty(phone) && string.IsNullOrEmpty(email)) {
            return BadRequest("Either phone or email must be provided");
        }

        var (existed, expiresAt) = await _authServiceClient.SendCodeAsync(phone, email, cancellationToken);

        if (existed) {
            return Conflict(new SendCodeResponse(
                Existed: existed,
                ExpiresAt: expiresAt
            ));
        }

        return Ok(new SendCodeResponse(
            Existed: existed,
            ExpiresAt: expiresAt
        ));
    }

    /// <summary>
    /// Register as customer providing short-live code
    /// </summary>
    /// <param name="request">Request body</param>
    /// <param name="cancellationToken"></param>
    [HttpPost]
    [Route("registerascustomer")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> RegisterAsCusotmerAsync(
        [FromBody] RegisterRequest request,
        CancellationToken cancellationToken
    ) {
        var (response, attempts) = await _authServiceClient.TryCodeAsync(
            request.Credential,
            request.Code,
            cancellationToken);

        if (response == AuthResponse.CodeNotExists) {
            return NotFound("Short-live code not exists");
        }

        if (response == AuthResponse.InvalidCode) {
            return BadRequest(attempts);
        }

        if (!await _dbProviderClient.CreateCustomerAsync(
            request.Firstname,
            request.LastName,
            request.Patronymic,
            request.Email,
            cancellationToken
        )) {
            return StatusCode(500);
        }

        return Ok();
    }

    /// <summary>
    /// Register as driver providing short-live code
    /// </summary>
    /// <param name="request">Request body</param>
    /// <param name="cancellationToken"></param>
    [HttpPost]
    [Route("registerasdriver")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> RegisterAsDriverAsync(
        [FromBody] RegisterRequest request,
        CancellationToken cancellationToken
    ) {
        var (response, attempts) = await _authServiceClient.TryCodeAsync(
            request.Credential,
            request.Code,
            cancellationToken);

        if (response == AuthResponse.CodeNotExists) {
            return NotFound("Short-live code not exists");
        }

        if (response == AuthResponse.InvalidCode) {
            return BadRequest(attempts);
        }

        if (!await _dbProviderClient.CreateDriverAsync(
            request.Firstname,
            request.LastName,
            request.Patronymic,
            request.Email,
            cancellationToken
        )) {
            return StatusCode(500);
        }

        return Ok();
    }
}