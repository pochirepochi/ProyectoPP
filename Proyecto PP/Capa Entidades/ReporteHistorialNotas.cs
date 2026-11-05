using System;

namespace Capa_Entidades
{
    public class ReporteHistorialNotas
    {
        public string Tipo_Nota { get; set; }
        public int ID_Nota { get; set; }
        public string Razon_Social { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public bool Activo { get; set; }
    }
}