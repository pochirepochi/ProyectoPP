using System.Collections.Generic;
using System.Text;
using System;
using Capa_Entidades;
using Capa_Datos;

namespace Capa_Logica
{
    public class NotaCreditoLogica
    {
        private NotaCreditoDatos _datos = new NotaCreditoDatos();

        public int EmitirNotaCredito(NotaCreditoVenta objNota, int idUsuario)
        {
            if (objNota.Monto <= 0)
            {
                throw new Exception("El monto de la Nota de Crédito debe ser mayor a cero.");
            }

            return _datos.EmitirNotaCredito(objNota, idUsuario);
        }
    }
}