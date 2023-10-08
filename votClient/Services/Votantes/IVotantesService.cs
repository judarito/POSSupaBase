using votClient.Models;

namespace votClient.Services.Votantes
{
    public interface IVotantesService
    {
        Task<HttpResponseMessage> Create(Votante votante);
        Task<Votante[]> GetAll();

        Task<Votante[]> GetByCeculaOrNombre(string  criteria);

        Task<Votante> GetById(int? id);

        Task<HttpResponseMessage> Update(Votante votante);

        Task<HttpResponseMessage> Delete(int id);
    }
}
