using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Capa_Entidades;

namespace Capa_Datos
{
    public class ReportesDatos : ConexionDB
    {
        public List<ReporteAlertaCredito> ObtenerAlertasCredito()
        {
            var lista = new List<ReporteAlertaCredito>();

            using (SqlConnection conexion = ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT ID, Razon_Social, Limite_Credito, Consumo_Real, Fecha, Activo FROM V_Reporte_Alerta_Credito", conexion))
            {
                conexion.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new ReporteAlertaCredito
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            Razon_Social = dr["Razon_Social"].ToString(),
                            Limite_Credito = Convert.ToDecimal(dr["Limite_Credito"]),
                            Consumo_Real = Convert.ToDecimal(dr["Consumo_Real"]),
                            Fecha = dr["Fecha"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["Fecha"]),
                            Activo = Convert.ToBoolean(dr["Activo"])
                        });
                    }
                }
            }
            return lista;
        }

        public List<ReporteHistorialNotas> ObtenerHistorialNotas()
        {
            var lista = new List<ReporteHistorialNotas>();

            using (SqlConnection conexion = ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT Tipo_Nota, ID_Nota, Razon_Social, Monto, Fecha, Activo FROM V_Reporte_Historial_Notas", conexion))
            {
                conexion.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new ReporteHistorialNotas
                        {
                            Tipo_Nota = dr["Tipo_Nota"].ToString(),
                            ID_Nota = Convert.ToInt32(dr["ID_Nota"]),
                            Razon_Social = dr["Razon_Social"].ToString(),
                            Monto = Convert.ToDecimal(dr["Monto"]),
                            Fecha = Convert.ToDateTime(dr["Fecha"]),
                            Activo = Convert.ToBoolean(dr["Activo"])
                        });
                    }
                }
            }
            return lista;
        }
    }
}