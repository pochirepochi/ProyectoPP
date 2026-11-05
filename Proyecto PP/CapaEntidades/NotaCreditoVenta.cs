using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class NotaCreditoVenta
    {
        public int ID { get; set; }
        public int FK_Factura_Venta { get; set; }
        public int FK_Cliente { get; set; }
        public decimal Monto { get; set; }
        public required string Motivo { get; set; }
    }
}
