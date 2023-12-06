using CommonBase.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Services.Factura
{
    public interface IFacturaService
    {
        Task Save(FacturaDto facturaDto);

        Task Update(FacturaDto facturaDto);

        Task Delete(int IdFactura);

        Task<FacturaDto> GetById(int IdFactura);

        Task<List<FacturaDto>> GetAll(int? from, int? to, string? searchCrieria);

        Task<int> GetCount(string? searchCrieria);
    }
}
