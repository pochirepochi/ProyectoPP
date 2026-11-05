using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class ContactoCliente
    {
        public int ID { get; set; }
        public int FK_Cliente { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
    }
}
