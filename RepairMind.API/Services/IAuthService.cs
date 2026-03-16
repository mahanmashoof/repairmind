using RepairMind.API.Models;

namespace RepairMind.API.Services;

public interface IAuthService
{
    Task<string?> RegisterAsync(RegisterRequest request);
    Task<string?> LoginAsync(LoginRequest request);
}