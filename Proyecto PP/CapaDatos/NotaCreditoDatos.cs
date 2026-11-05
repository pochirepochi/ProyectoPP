using System;
using System.Data;
using Microsoft.Data.SqlClient;
using CapaEntidades;

namespace CapaDatos
{
    public class NotaCreditoDatos
    {
        private string cadenaConexion = "Server=DESKTOP-BOPA3MP;Database=grupo6;Trusted_Connection=True;TrustServerCertificate=True;";

        public int EmitirNotaCredito(NotaCreditoVenta objNota, int idUsuario)
        {
            int idGenerado = 0;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand("SP_EmitirNotaCredito", conexion))
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