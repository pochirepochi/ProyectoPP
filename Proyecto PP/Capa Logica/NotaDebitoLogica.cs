using System.Collections.Generic;
using System.Text;
using System;
using Capa_Entidades;
using Capa_Datos;

namespace Capa_Logica
{
    public class NotaDebitoLogica
    {
        private NotaDebitoDatos _datos = new NotaDebitoDatos();

        public int EmitirNotaDebito(NotaDebitoVenta objNota, int idUsuario)
        {
            if (objNota.Monto <= 0)
            {
                throw new Exception("El monto de la Nota de Débito debe ser mayor a cero.");
            }

            return _datos.EmitirNotaDebito(objNota, idUsuario);
        }
    }
}