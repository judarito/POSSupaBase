using votClient.Models;

namespace votClient.Services.Puestos
{
    public interface IPuestosService
    {
        Task<PuestoVotacion[]> GetAll();

        Task<PuestoVotacion> GetById(int? id);
    }
}
