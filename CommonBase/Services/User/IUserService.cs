using CommonBase.Models.UserModel;

namespace CommonBase.Services.User
{
    public interface IUserService
    {
        Task<List<UserModel>> GetUsers(int IdTenant);
        Task<UserModel> GetUserByIdSupabase(Guid idSupabase);
        Task<UserModel> GetUserById(int id);
    }
}
