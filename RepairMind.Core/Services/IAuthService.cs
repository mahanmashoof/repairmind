using RepairMind.Core.Models;

namespace RepairMind.Core.Services;

public interface IAuthService
{
    Task<string?> RegisterAsync(RegisterRequest request);
    Task<string?> LoginAsync(LoginRequest request);
}