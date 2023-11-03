using CommonBase.Models;

namespace CommonBase.Services.Lideres
{
    public interface ILideresService
    {
        Task<HttpResponseMessage> Create(Lider lider);
        Task<Lider[]> GetAll();

        Task<Lider> GetById(int? id);

        Task<HttpResponseMessage> Update(Lider lider);

        Task<HttpResponseMessage> Delete(int id);
    }
}
