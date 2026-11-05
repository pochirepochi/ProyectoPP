using System.Collections.Generic;
using Capa_Datos;
using Capa_Entidades;

namespace Capa_Logica
{
    public class FacturaVentaLogica
    {
        private FacturaVentaDatos _facturaDatos = new FacturaVentaDatos();

        public List<FacturaVenta> ObtenerFacturasPorCliente(int idCliente)
        {
            return _facturaDatos.ObtenerFacturasPorCliente(idCliente);
        }
    }
}