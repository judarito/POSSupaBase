using CommonBase.Models;

namespace CommonBase.Services.Puestos
{
    public interface IPuestosService
    {
        Task<PuestoVotacion[]> GetAll();

        Task<PuestoVotacion> GetById(int? id);
    }
}
