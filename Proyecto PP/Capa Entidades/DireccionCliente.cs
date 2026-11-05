using System.Collections.Generic;
using System.Text;
using System;

namespace Capa_Entidades
{
    public class DireccionCliente
    {
        public int ID { get; set; }
        public int FK_Cliente { get; set; }
        public required string Provincia { get; set; }
        public required string Partido { get; set; }
        public required string Localidad { get; set; }
    }
}