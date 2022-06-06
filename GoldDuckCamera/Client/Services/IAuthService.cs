using GoldDuckCamera.Shared.Authentication;

namespace GoldDuckCamera.Client.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
        Task Logout();    
    }
}
