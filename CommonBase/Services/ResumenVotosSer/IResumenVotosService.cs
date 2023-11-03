using CommonBase.Models.ResumenVotos;

namespace CommonBase.Services.ResumenVotosSer
{
    public interface IResumenVotosService
    {
        Task<ResumenVotosModel> GetResumenVotos();
    }
}
