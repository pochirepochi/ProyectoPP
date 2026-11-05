    using System;

namespace CapaEntidades
{
    public class Cliente
    {
        public int ID { get; set; }
        public string CUIT_DNI { get; set; } = string.Empty;
        public string Razon_Social { get; set; } = string.Empty;
        public decimal Limite_Credito { get; set; }
        public decimal Descuento_General { get; set; }
        public bool Activo { get; set; }
    }
}