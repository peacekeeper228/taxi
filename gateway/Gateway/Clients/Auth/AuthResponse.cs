namespace Gateway.Clients.Auth;

public enum AuthResponse {
    Invalid = 0,
    Success = 1,
    CodeNotExists = 2,
    InvalidCode = 3,
}