using System;
using System.Collections.Generic;
using System.Linq;
using Capa_Datos;
using Capa_Entidades;

namespace Capa_Logica
{
    public class FiltroReporte
    {
        public string Busqueda { get; set; }
        public bool Activos { get; set; } = true;
        public bool Inactivos { get; set; } = true;
        public decimal? MontoMin { get; set; }
        public decimal? MontoMax { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public int Orden { get; set; } 
    }

    public class ReportesLogica
    {
        private ReportesDatos _datos = new ReportesDatos();

        public List<ReporteAlertaCredito> ReporteAlertasCredito(FiltroReporte f)
        {
            var q = _datos.ObtenerAlertasCredito().AsEnumerable();

            q = q.Where(r => (r.Activo && f.Activos) || (!r.Activo && f.Inactivos));

            if (!string.IsNullOrWhiteSpace(f.Busqueda))
            {
                string b = f.Busqueda.Trim();
                q = q.Where(r => (r.Razon_Social ?? "").IndexOf(b, StringComparison.OrdinalIgnoreCase) >= 0
                              || r.ID.ToString().Contains(b));
            }

            if (f.MontoMin.HasValue) q = q.Where(r => r.Consumo_Real >= f.MontoMin.Value);
            if (f.MontoMax.HasValue) q = q.Where(r => r.Consumo_Real <= f.MontoMax.Value);

            DateTime hastaFin = f.Hasta.Date.AddDays(1).AddTicks(-1);
            q = q.Where(r => r.Fecha == null || (r.Fecha >= f.Desde.Date && r.Fecha <= hastaFin));

            if (f.Orden == 1) q = q.OrderByDescending(r => r.Consumo_Real);
            else if (f.Orden == 2) q = q.OrderBy(r => r.Consumo_Real);

            return q.ToList();
        }

        public List<ReporteHistorialNotas> ReporteHistorialNotas(FiltroReporte f)
        {
            var q = _datos.ObtenerHistorialNotas().AsEnumerable();

            q = q.Where(r => (r.Activo && f.Activos) || (!r.Activo && f.Inactivos));

            if (!string.IsNullOrWhiteSpace(f.Busqueda))
            {
                string b = f.Busqueda.Trim();
                q = q.Where(r => (r.Razon_Social ?? "").IndexOf(b, StringComparison.OrdinalIgnoreCase) >= 0
                              || (r.Tipo_Nota ?? "").IndexOf(b, StringComparison.OrdinalIgnoreCase) >= 0
                              || r.ID_Nota.ToString().Contains(b));
            }

            if (f.MontoMin.HasValue) q = q.Where(r => r.Monto >= f.MontoMin.Value);
            if (f.MontoMax.HasValue) q = q.Where(r => r.Monto <= f.MontoMax.Value);

            DateTime hastaFin = f.Hasta.Date.AddDays(1).AddTicks(-1);
            q = q.Where(r => r.Fecha >= f.Desde.Date && r.Fecha <= hastaFin);

            if (f.Orden == 1) q = q.OrderByDescending(r => r.Monto);
            else if (f.Orden == 2) q = q.OrderBy(r => r.Monto);

            return q.ToList();
        }
    }
}