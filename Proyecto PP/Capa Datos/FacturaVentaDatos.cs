using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Capa_Entidades;

namespace Capa_Datos
{
    public class FacturaVentaDatos : ConexionDB
    {
        public List<FacturaVenta> ObtenerFacturasPorCliente(int idCliente)
        {
            List<FacturaVenta> lista = new List<FacturaVenta>();
            using (SqlConnection conexion = ObtenerConexion())
            {
                string query = "SELECT ID, FK_Cliente, Numero_Factura FROM Facturas_Venta WHERE FK_Cliente = @IDCliente";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@IDCliente", idCliente);
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new FacturaVenta()
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                FK_Cliente = Convert.ToInt32(reader["FK_Cliente"]),
                                Numero_Factura = reader["Numero_Factura"]!.ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}