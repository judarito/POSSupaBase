using votClient.Models.Login;

namespace votClient.Services.Login
{
    public interface ILoginService
    {
        Task<SessionResponse> Login(SessionRequest session);
    }
}
