using CommonBase.Dtos;
using CommonBase.Dtos.Facturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Services.Factura
{
    public interface IFacturaService
    {
        Task SaveOrUpdate(FacturaSaveModel facturaDto);

        Task Delete(int IdFactura);

        Task<FacturaModel> GetById(int IdFactura);

        Task<FacturasModel> GetAll(int? from, int? to, string? searchCrieria, DateTime DtInicio, DateTime DtFin);
               
    }
}
