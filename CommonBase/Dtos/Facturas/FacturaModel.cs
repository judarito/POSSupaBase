﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Dtos.Facturas
{
    public class FacturaModel
    {
        public int Id { get; set; }
        public int IdTercero { get; set; }
        public string? Cliente { get; set; }
        public int IdTipoPago { get; set; }
        public string? TipoPago { get; set; }
        public  int IdEstadoEntrega { get; set; }
        public string? EstadoEntrega { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int DiasVencimiento { get; set; }
        public decimal TotalFactura { get; set; }
        public List<DetalleFacturaModel>? Detalle { get; set;}
    }
}
