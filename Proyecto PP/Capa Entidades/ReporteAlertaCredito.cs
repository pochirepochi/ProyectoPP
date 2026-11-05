using System;

namespace Capa_Entidades
{
    public class ReporteAlertaCredito
    {
        public int ID { get; set; }
        public string Razon_Social { get; set; }
        public decimal Limite_Credito { get; set; }
        public decimal Consumo_Real { get; set; }
        public DateTime? Fecha { get; set; }
        public bool Activo { get; set; }
    }
}