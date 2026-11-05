using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Capa_Datos
{
    public static class DatosSeguridad
    {
        public static string ObtenerEmailUsuario(string nombreUsuario)
        {
            string email = "";
            using (SqlConnection con = ConexionDB.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT email FROM [dbo].[usuarios] WHERE nombre_usuario = @usuario", con))
                {
                    cmd.Parameters.AddWithValue("@usuario", nombreUsuario);
                    con.Open();
                    var resultado = cmd.ExecuteScalar();
                    if (resultado != null && resultado != DBNull.Value)
                    {
                        email = resultado.ToString();
                    }
                }
            }
            return email;
        }

        public static DataTable TraerPreguntas()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = ConexionDB.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerPreguntas", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;
        }

        public static bool ValidarRespuestaSeguridad(string usuario, int idCatalogo, string respuestaHash)
        {
            using (SqlConnection con = ConexionDB.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ValidarRespuestaSeguridad", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre_usuario", usuario);
                    cmd.Parameters.AddWithValue("@id_catalogo", idCatalogo);
                    cmd.Parameters.AddWithValue("@respuesta_hash", respuestaHash);

                    SqlParameter paramValido = new SqlParameter("@es_valido", SqlDbType.Bit);
                    paramValido.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramValido);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    return (bool)paramValido.Value;
                }
            }
        }

        public static DataTable ObtenerPreguntas(string nombreUsuario)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = ConexionDB.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerPreguntasUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre_usuario", nombreUsuario);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;
        }

        public static void ActualizarPassword(string nombreUsuario, string nuevaClaveHash, int forzarCambio)
        {
            using (SqlConnection con = ConexionDB.ObtenerConexion())
            {
                con.Open();

                int idUsuario = 0;
                using (SqlCommand cmdId = new SqlCommand("SELECT id_usuario FROM [dbo].[usuarios] WHERE nombre_usuario = @user", con))
                {
                    cmdId.Parameters.AddWithValue("@user", nombreUsuario);
                    var result = cmdId.ExecuteScalar();
                    if (result != null) idUsuario = Convert.ToInt32(result);
                }

                if (idUsuario > 0)
                {
  
                    using (SqlCommand cmd = new SqlCommand("sp_ActualizarContraseña", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                        cmd.Parameters.AddWithValue("@nuevaClave", nuevaClaveHash);
                        cmd.ExecuteNonQuery();
                    }


                    using (SqlCommand cmdForzar = new SqlCommand("UPDATE [dbo].[contraseña] SET forzar_cambio = @forzar WHERE id_usuario = @idUsuario AND es_activa = 1", con))
                    {
                        cmdForzar.Parameters.AddWithValue("@forzar", forzarCambio);
                        cmdForzar.Parameters.AddWithValue("@idUsuario", idUsuario);
                        cmdForzar.ExecuteNonQuery();
                    }


                    int idConNuevo = 0;
                    using (SqlCommand cmdGetId = new SqlCommand("SELECT TOP 1 id_con FROM [dbo].[contraseña] WHERE id_usuario = @idUsuario AND es_activa = 1 ORDER BY id_con DESC", con))
                    {
                        cmdGetId.Parameters.AddWithValue("@idUsuario", idUsuario);
                        var res = cmdGetId.ExecuteScalar();
                        if (res != null) idConNuevo = Convert.ToInt32(res);
                    }

                    if (idConNuevo > 0)
                    {
                        using (SqlCommand cmdHistorial = new SqlCommand("sp_RegistrarHistorialContraseña", con))
                        {
                            cmdHistorial.CommandType = CommandType.StoredProcedure;
                            cmdHistorial.Parameters.AddWithValue("@idUsuario", idUsuario);
                            cmdHistorial.Parameters.AddWithValue("@idCon", idConNuevo);
                            cmdHistorial.Parameters.AddWithValue("@contraseña", nuevaClaveHash);
                            cmdHistorial.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public static bool EsContrasenaRepetida(int idUsuario, string nuevaClaveHash, int cantidadARevisar)
        {
            using (SqlConnection con = ConexionDB.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_Contraseñas_VerificarUltimas", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
                    cmd.Parameters.AddWithValue("@contraseña_nueva", nuevaClaveHash);
                    cmd.Parameters.AddWithValue("@cantidad_a_revisar", cantidadARevisar);

                    con.Open();
                    int coincidencias = Convert.ToInt32(cmd.ExecuteScalar());
                    return coincidencias > 0; 
                }
            }
        }

        public static void GuardarRespuesta(int idUsuario, int idPreguntaAsignada, string textoRespuesta)
        {
            using (SqlConnection con = ConexionDB.ObtenerConexion())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("sp_GuardarRespuestaSeguridad", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.Parameters.AddWithValue("@idCatalogo", idPreguntaAsignada);
                    cmd.Parameters.AddWithValue("@respuestaTexto", textoRespuesta);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static bool ValidarContraseñaActual(string nombreUsuario, string hashActual)
        {
            using (SqlConnection con = ConexionDB.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@p_nombre_usuario", nombreUsuario);
                    cmd.Parameters.AddWithValue("@p_contrasena", hashActual);

                    con.Open();

                    var result = cmd.ExecuteScalar();
                    return result != null && Convert.ToInt32(result) > 0;
                }
            }
        }

        public static void ActualizarRespuestaSeguridad(int idUsuario, int idPregunta, string respuestaHash)
        {

            GuardarRespuesta(idUsuario, idPregunta, respuestaHash);
        }
    }
}