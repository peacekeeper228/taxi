namespace Gateway.Controllers.Auth.Requests;

/// <summary>
/// Request body for registration
/// </summary>
public class RegisterRequest {
    /// <summary>
    /// Phone or email
    /// </summary>
    /// <value></value>
    public string Credential { get; init; } = null!;

    /// <summary>
    /// Short-live code received
    /// </summary>
    /// <value></value>
    public int Code { get; init; }

    /// <summary>
    /// Password (optional)
    /// </summary>
    /// <value></value>
    public string? Password { get; init; }

    /// <summary>
    /// Firstname
    /// </summary>
    /// <value></value>
    public string Firstname { get; init; } = null!;

    /// <summary>
    /// Lastname
    /// </summary>
    /// <value></value>
    public string LastName { get; init; } = null!;

    /// <summary>
    /// Patronymic
    /// </summary>
    /// <value></value>
    public string Patronymic { get; init; } = null!;

    /// <summary>
    /// Email
    /// </summary>
    /// <value></value>
    public string Email { get; init; } = null!;
}