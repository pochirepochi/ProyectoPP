using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Capa_Entidades;

namespace Capa_Datos
{
    public class NotaDebitoDatos : ConexionDB
    {
        public int EmitirNotaDebito(NotaDebitoVenta objNota, int idUsuario)
        {
            int idGenerado = 0;
            using (SqlConnection conexion = ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("SP_EmitirNotaDebito", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FK_Factura_Venta", objNota.FK_Factura_Venta);
                    cmd.Parameters.AddWithValue("@FK_Cliente", objNota.FK_Cliente);
                    cmd.Parameters.AddWithValue("@Monto", objNota.Monto);
                    cmd.Parameters.AddWithValue("@Motivo", objNota.Motivo);
                    cmd.Parameters.AddWithValue("@FK_Usuario", idUsuario);

                    conexion.Open();
                    var resultado = cmd.ExecuteScalar();
                    if (resultado != null) idGenerado = Convert.ToInt32(resultado);
                }
            }
            return idGenerado;
        }
    }
}