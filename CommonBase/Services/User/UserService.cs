using CommonBase.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Services.User
{
    public class UserService : IUserService
    {
        private readonly Supabase.Client _client;
        public UserService(Supabase.Client client) {
            _client = client;
        }
        public async Task<UserModel> GetUserById(int id)
        {
            var modeledResponse = await _client
                 .From<UserModel>()
                 .Where(x=>x.idUser == id)
                 .Get();
            return modeledResponse?.Models?.FirstOrDefault();
        }

        public async Task<UserModel> GetUserByIdSupabase(Guid idSupabase)
        {
            var modeledResponse = await _client
                 .From<UserModel>()
                 .Where(x => x.IdUserSupabase == idSupabase)
                 .Get();
            return modeledResponse?.Models?.FirstOrDefault();
        }

        public async Task<List<UserModel>> GetUsers(int IdTenant)
        {
            var modeledResponse = await _client
                 .From<UserModel>()
                 .Where(x => x.idTenant == IdTenant)
                 .Get();
            return modeledResponse?.Models;
        }
    }
}
