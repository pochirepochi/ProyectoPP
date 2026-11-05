using System;
using System.Data;
using Microsoft.Data.SqlClient;
using CapaEntidades;

namespace CapaDatos
{
    public class ContactoClienteDatos
    {
        private string cadenaConexion = "Server=DESKTOP-BOPA3MP;Database=grupo6;Trusted_Connection=True;TrustServerCertificate=True;";

        public void GuardarContacto(ContactoCliente contacto)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GuardarContactoCliente", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FK_Cliente", contacto.FK_Cliente);
                    cmd.Parameters.AddWithValue("@Nombre", contacto.Nombre ?? "Principal");
                    cmd.Parameters.AddWithValue("@Telefono", contacto.Telefono ?? string.Empty);

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ContactoCliente ObtenerPorCliente(int idCliente)
        {
            ContactoCliente contacto = new ContactoCliente();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ObtenerContactoPorCliente", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FK_Cliente", idCliente);

                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            contacto.ID = Convert.ToInt32(reader["ID"]);
                            contacto.FK_Cliente = Convert.ToInt32(reader["FK_Cliente"]);
                            contacto.Nombre = reader["Nombre"].ToString();
                            contacto.Telefono = reader["Telefono"]?.ToString();
                        }
                    }
                }
            }
            return contacto;
        }
    }
}