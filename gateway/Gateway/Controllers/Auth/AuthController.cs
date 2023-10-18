using System.Net;
using Gateway.Clients.Auth;
using Gateway.Controllers.Auth.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers.Auth;

[Route("gateway/[controller]")]
public class AuthController : Controller {
    private readonly IAuthServiceClient _authServiceClient;

    public AuthController(
        IAuthServiceClient authServiceClient
    ) {
        _authServiceClient = authServiceClient;
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
    /// Register providing short-live code
    /// </summary>
    /// <param name="credential">Phone or email</param>
    /// <param name="code">Short-live code received</param>
    /// <param name="password">Password (optional)</param>
    /// <param name="cancellationToken"></param>
    [HttpPost]
    [Route("register")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> RegisterAsync(string credential, int code, string? password, CancellationToken cancellationToken) {
        var (response, attempts) = await _authServiceClient.TryCodeAsync(credential, code, cancellationToken);

        if (response == AuthResponse.CodeNotExists) {
            return NotFound("Short-live code not exists");
        }

        if (response == AuthResponse.InvalidCode) {
            return BadRequest(attempts);
        }

        return Ok();
    }
}