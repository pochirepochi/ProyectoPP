using System.Collections.Generic;
using System.Text;
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class ReportesDatos
    {
        private string cadenaConexion = "Server=DESKTOP-BOPA3MP;Database=grupo6;Trusted_Connection=True;TrustServerCertificate=True;";

        public DataTable ObtenerVista(string nombreVista)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string query = $"SELECT * FROM {nombreVista}";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}