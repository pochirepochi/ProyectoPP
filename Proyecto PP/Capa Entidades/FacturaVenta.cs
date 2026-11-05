using System;
using System.Collections.Generic;
using System.Text;

namespace Capa_Entidades
{
    public class FacturaVenta
    {
        public int ID { get; set; }
        public int FK_Cliente { get; set; }
        public string Numero_Factura { get; set; } = string.Empty;
    }
}