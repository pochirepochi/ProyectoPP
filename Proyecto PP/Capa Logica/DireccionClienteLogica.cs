using System.Collections.Generic;
using Capa_Datos;
using Capa_Entidades;

namespace Capa_Logica
{
    public class DireccionClienteLogica
    {
        private DireccionClienteDatos _datos = new DireccionClienteDatos();

        public void GuardarDireccion(DireccionCliente direccion)
        {
            _datos.GuardarDireccion(direccion);
        }

        public DireccionCliente ObtenerPorCliente(int idCliente)
        {
            return _datos.ObtenerPorCliente(idCliente);
        }

        public List<string> ListarProvincias() => _datos.ListarProvincias();
        public List<string> ListarPartidos(string provincia) => _datos.ListarPartidos(provincia);
        public List<string> ListarLocalidades(string partido) => _datos.ListarLocalidades(partido);
    }
}