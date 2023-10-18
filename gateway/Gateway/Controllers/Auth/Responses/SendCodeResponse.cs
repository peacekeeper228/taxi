namespace Gateway.Controllers.Auth.Responses;

public record struct SendCodeResponse(
    bool Existed,
    long ExpiresAt
);