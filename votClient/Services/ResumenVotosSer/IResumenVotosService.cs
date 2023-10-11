using votClient.Models.ResumenVotos;

namespace votClient.Services.ResumenVotosSer
{
    public interface IResumenVotosService
    {
        Task<ResumenVotosModel> GetResumenVotos();
    }
}
