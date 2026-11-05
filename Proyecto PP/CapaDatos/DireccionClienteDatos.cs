using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CapaEntidades;

namespace CapaDatos
{
    public class DireccionClienteDatos
    {
        private string cadenaConexion = "Server=DESKTOP-BOPA3MP;Database=grupo6;Trusted_Connection=True;TrustServerCertificate=True;";

        public void GuardarDireccion(DireccionCliente direccion)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GuardarDireccionCliente", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FK_Cliente", direccion.FK_Cliente);
                    cmd.Parameters.AddWithValue("@Provincia", direccion.Provincia ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Partido", direccion.Partido ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Localidad", direccion.Localidad ?? string.Empty);

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DireccionCliente ObtenerPorCliente(int idCliente)
        {
            DireccionCliente direccion = new DireccionCliente { Provincia = "", Partido = "", Localidad = "" };
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ObtenerDireccionPorCliente", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FK_Cliente", idCliente);

                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            direccion.ID = Convert.ToInt32(reader["ID"]);
                            direccion.FK_Cliente = Convert.ToInt32(reader["FK_Cliente"]);
                            direccion.Provincia = reader["Provincia"].ToString();
                            direccion.Partido = reader["Partido"].ToString();
                            direccion.Localidad = reader["Localidad"].ToString();
                        }
                    }
                }
            }
            return direccion;
        }

        // Métodos para llenar los ComboBox
        // Reemplazá el método ListarOpciones que tenías al final por estos tres específicos:
        public List<string> ListarProvincias()
        {
            List<string> lista = new List<string>();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ListarProvincias", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                        while (reader.Read()) lista.Add(reader["Nombre"].ToString());
                }
            }
            return lista;
        }

        public List<string> ListarPartidos(string provincia)
        {
            List<string> lista = new List<string>();
            if (string.IsNullOrEmpty(provincia)) return lista;

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ListarPartidosPorProvincia", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Provincia", provincia);
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                        while (reader.Read()) lista.Add(reader["Nombre"].ToString());
                }
            }
            return lista;
        }

        public List<string> ListarLocalidades(string partido)
        {
            List<string> lista = new List<string>();
            if (string.IsNullOrEmpty(partido)) return lista;

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ListarLocalidadesPorPartido", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Partido", partido);
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                        while (reader.Read()) lista.Add(reader["Nombre"].ToString());
                }
            }
            return lista;
        }
    }
}