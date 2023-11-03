using CommonBase.Models.Login;

namespace CommonBase.Services.Login
{
    public interface ILoginService
    {
        Task<SessionResponse> Login(SessionRequest session);
    }
}
