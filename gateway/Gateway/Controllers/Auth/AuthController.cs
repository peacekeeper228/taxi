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

    [HttpPost]
    [Route("sendcode")]
    public async Task<IActionResult> SendCodeAsync(string? phone, string? email, CancellationToken cancellationToken) {
        if (string.IsNullOrEmpty(phone) && string.IsNullOrEmpty(email)) {
            return BadRequest("Either phone or email must be provided");
        }

        var (existed, expiresAt) = await _authServiceClient.SendCodeAsync(phone, email, cancellationToken);

        return Ok(new SendCodeResponse(
            Existed: existed,
            ExpiresAt: expiresAt
        ));
    }
}