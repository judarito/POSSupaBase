using System.Collections.Generic;
using votClient.Models;
using votClient.Models.Votantes;

namespace votClient.Services.Votantes
{
    public interface IVotantesService
    {
        Task<HttpResponseMessage> Create(Votante votante);
        Task<Votante[]> GetAll();

        Task<DataPaginationVotantes> GetPaginationAll(int? Limit, int? Offset);

        Task<DataPaginationVotantes> GetByCriteria(string criteria,int? Limit, int? Offset);

        Task<Votante> GetById(int? id);

        Task<HttpResponseMessage> Update(Votante votante);

        Task<HttpResponseMessage> Delete(int id);
    }
}
