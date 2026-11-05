using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Capa_Entidades;

namespace Capa_Datos
{
    public class ClienteDatos : ConexionDB
    {
        public int InsertarCliente(Cliente objCliente, int idUsuario)
        {
            int idGenerado = 0;
            using (SqlConnection conexion = ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("SP_InsertarCliente", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Razon_Social", objCliente.Razon_Social);
                    cmd.Parameters.AddWithValue("@CUIT_DNI", objCliente.CUIT_DNI);
                    cmd.Parameters.AddWithValue("@Limite_Credito", objCliente.Limite_Credito);
                    cmd.Parameters.AddWithValue("@Descuento_General", objCliente.Descuento_General);
                    cmd.Parameters.AddWithValue("@Activo", objCliente.Activo);
                    cmd.Parameters.AddWithValue("@FK_Usuario", idUsuario);

                    conexion.Open();
                    var resultado = cmd.ExecuteScalar();
                    if (resultado != null) idGenerado = Convert.ToInt32(resultado);
                }
            }
            return idGenerado;
        }

        public List<Cliente> ListarClientes()
        {
            List<Cliente> lista = new List<Cliente>();
            using (SqlConnection conexion = ObtenerConexion())
            {
                string query = "SELECT ID, Razon_Social, CUIT_DNI, Limite_Credito, Descuento_General, Activo FROM Clientes";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Cliente()
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Razon_Social = reader["Razon_Social"].ToString()!,
                                CUIT_DNI = reader["CUIT_DNI"].ToString()!,
                                Limite_Credito = Convert.ToDecimal(reader["Limite_Credito"]),
                                Descuento_General = Convert.ToDecimal(reader["Descuento_General"]),
                                Activo = Convert.ToBoolean(reader["Activo"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public void ActualizarCliente(Cliente objCliente, int idUsuario)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("SP_ActualizarCliente", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Cliente", objCliente.ID);
                    cmd.Parameters.AddWithValue("@Razon_Social", objCliente.Razon_Social);
                    cmd.Parameters.AddWithValue("@CUIT_DNI", objCliente.CUIT_DNI);
                    cmd.Parameters.AddWithValue("@Limite_Credito", objCliente.Limite_Credito);
                    cmd.Parameters.AddWithValue("@Descuento_General", objCliente.Descuento_General);
                    cmd.Parameters.AddWithValue("@Activo", objCliente.Activo);
                    cmd.Parameters.AddWithValue("@FK_Usuario", idUsuario);

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void BajaCliente(int idCliente, int idUsuario)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("SP_BajaCliente", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Cliente", idCliente);
                    cmd.Parameters.AddWithValue("@FK_Usuario", idUsuario);

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool ReactivarCliente(int idCliente, int idUsuario)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                string query = "UPDATE Clientes SET Activo = 1 WHERE ID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@ID", idCliente);

                    conexion.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
        }

        public Cliente BuscarClientePorId(int idCliente)
        {
            Cliente clienteEncontrado = new Cliente();

            using (SqlConnection conexion = ObtenerConexion())
            {
                string query = "SELECT ID, Razon_Social, CUIT_DNI, Limite_Credito, Descuento_General, Activo FROM Clientes WHERE ID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@ID", idCliente);
                    conexion.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            clienteEncontrado.ID = Convert.ToInt32(reader["ID"]);
                            clienteEncontrado.Razon_Social = reader["Razon_Social"].ToString() ?? "";
                            clienteEncontrado.CUIT_DNI = reader["CUIT_DNI"].ToString() ?? "";
                            clienteEncontrado.Limite_Credito = Convert.ToDecimal(reader["Limite_Credito"]);
                            clienteEncontrado.Descuento_General = Convert.ToDecimal(reader["Descuento_General"]);
                            clienteEncontrado.Activo = Convert.ToBoolean(reader["Activo"]);
                        }
                    }
                }
            }

            return clienteEncontrado;
        }

        public bool ExisteCuit(string cuit, int idClienteExcluir = 0)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("SP_ExisteCuitCliente", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CUIT_DNI", cuit.Trim());
                    cmd.Parameters.AddWithValue("@ID_Cliente_Excluir", idClienteExcluir);

                    conexion.Open();
                    int cantidad = Convert.ToInt32(cmd.ExecuteScalar());
                    return cantidad > 0;
                }
            }
        }
    }
}