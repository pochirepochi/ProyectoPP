using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Capa_Datos
   {
    public class ConexionDB
    {
        private static string cadena = "Data Source=DESKTOP-BOPA3MP;Initial Catalog=ProyectoPP;Integrated Security=True;TrustServerCertificate=True;Encrypt=False";

        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(cadena);
            return conexion;
        }

        public SqlConnection con;

        public ConexionDB()
        {
            con = new SqlConnection(cadena);
        }

        public void Abrir()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al abrir la BD: " + ex.Message);
            }
        }

        public void Cerrar()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }
    }
}
