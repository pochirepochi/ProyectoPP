using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CapaLogica;

namespace CapaVista
{
    public partial class FrmReportes : Form
    {
        private ReportesLogica _reportesLogica = new ReportesLogica();
        private DataTable _dtReporteActual;

        public FrmReportes()
        {
            InitializeComponent();
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            HabilitarFiltros(false);
            chkActivo.Checked = true;
            chkDesactivo.Checked = true;
        }

        private void HabilitarFiltros(bool estado)
        {
            txtBuscar.Enabled = estado;
            chkMontoMayorAMenor.Enabled = estado;
            chkMontoMenorAMayor.Enabled = estado;
            chkActivo.Enabled = estado;
            chkDesactivo.Enabled = estado;
            txtMontoMin.Enabled = estado;
            txtMontoMax.Enabled = estado;
            dateTimePicker1.Enabled = estado;
            dateTimePicker2.Enabled = estado;
        }

        private void btnAlertas_Click(object sender, EventArgs e)
        {
            try
            {
                _dtReporteActual = _reportesLogica.ReporteAlertasCredito();
                HabilitarFiltros(true);
                AplicarFiltros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (dgvReportes.Columns.Contains("Activo"))
            {
                dgvReportes.Columns["Activo"].Visible = false;
            }
        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            try
            {
                _dtReporteActual = _reportesLogica.ReporteHistorialNotas();
                HabilitarFiltros(true);
                AplicarFiltros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (dgvReportes.Columns.Contains("Activo"))
            {
                dgvReportes.Columns["Activo"].Visible = false;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmPrincipal pantallaPrincipal = new FrmPrincipal();
            pantallaPrincipal.Show();
            this.Hide();
        }

        private void AplicarFiltros()
        {
            if (_dtReporteActual == null) return;

            DataView dv = _dtReporteActual.DefaultView;
            List<string> condiciones = new List<string>();

            // 1. Filtro de Texto
            string busqueda = txtBuscar.Text.Trim().Replace("'", "''");
            if (!string.IsNullOrEmpty(busqueda))
            {
                List<string> filtrosTexto = new List<string>();
                foreach (DataColumn columna in _dtReporteActual.Columns)
                {
                    filtrosTexto.Add($"CONVERT([{columna.ColumnName}], 'System.String') LIKE '%{busqueda}%'");
                }
                if (filtrosTexto.Count > 0)
                {
                    condiciones.Add($"({string.Join(" OR ", filtrosTexto)})");
                }
            }

            // 2. Filtro de Estado
            if (_dtReporteActual.Columns.Contains("Activo"))
            {
                if (chkActivo.Checked && !chkDesactivo.Checked)
                    condiciones.Add("Activo = true");
                else if (!chkActivo.Checked && chkDesactivo.Checked)
                    condiciones.Add("Activo = false");
                else if (!chkActivo.Checked && !chkDesactivo.Checked)
                    condiciones.Add("1 = 0");
            }

            // Detectar columna de monto
            string columnaMonto = null;
            if (_dtReporteActual.Columns.Contains("Consumo_Real")) columnaMonto = "Consumo_Real";
            else if (_dtReporteActual.Columns.Contains("Monto")) columnaMonto = "Monto";
            else if (_dtReporteActual.Columns.Contains("Limite_Credito")) columnaMonto = "Limite_Credito";

            // 3. Filtro de Montos Mínimo y Máximo
            if (columnaMonto != null)
            {
                if (decimal.TryParse(txtMontoMin.Text, out decimal montoMin))
                {
                    // Se usa InvariantCulture para que el DataView reconozca el punto decimal independientemente de la región
                    condiciones.Add($"[{columnaMonto}] >= {montoMin.ToString(System.Globalization.CultureInfo.InvariantCulture)}");
                }
                if (decimal.TryParse(txtMontoMax.Text, out decimal montoMax))
                {
                    condiciones.Add($"[{columnaMonto}] <= {montoMax.ToString(System.Globalization.CultureInfo.InvariantCulture)}");
                }
            }

            // 4. Filtro de Fechas
            if (_dtReporteActual.Columns.Contains("Fecha"))
            {
                // El DataView exige formato de fecha en inglés para el RowFilter (#MM/dd/yyyy#)
                string fechaDesde = dateTimePicker1.Value.ToString("MM/dd/yyyy 00:00:00");
                string fechaHasta = dateTimePicker2.Value.ToString("MM/dd/yyyy 23:59:59");
                condiciones.Add($"Fecha >= #{fechaDesde}# AND Fecha <= #{fechaHasta}#");
            }

            // Aplicar todas las condiciones juntas
            dv.RowFilter = string.Join(" AND ", condiciones);

            // 5. Ordenamiento
            if (columnaMonto != null)
            {
                if (chkMontoMayorAMenor.Checked)
                    dv.Sort = $"[{columnaMonto}] DESC";
                else if (chkMontoMenorAMayor.Checked)
                    dv.Sort = $"[{columnaMonto}] ASC";
                else
                    dv.Sort = string.Empty;
            }

            dgvReportes.DataSource = dv;
            RenombrarColumnas();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void chkMontoMayorAMenor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMontoMayorAMenor.Checked) chkMontoMenorAMayor.Checked = false;
            AplicarFiltros();
        }

        private void chkMontoMenorAMayor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMontoMenorAMayor.Checked) chkMontoMayorAMenor.Checked = false;
            AplicarFiltros();
        }

        private void chkActivo_CheckedChanged(object sender, EventArgs e) { AplicarFiltros(); }
        private void chkDesactivo_CheckedChanged(object sender, EventArgs e) { AplicarFiltros(); }

        private void txtMontoMin_TextChanged(object sender, EventArgs e) { AplicarFiltros(); }
        private void txtMontoMax_TextChanged(object sender, EventArgs e) { AplicarFiltros(); }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { AplicarFiltros(); }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e) { AplicarFiltros(); }

        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void groupBox3_Enter(object sender, EventArgs e) { }

        private void RenombrarColumnas()
        {
            if (dgvReportes.Columns["Tipo_Nota"] != null)
                dgvReportes.Columns["Tipo_Nota"].HeaderText = "Tipo de Nota";

            if (dgvReportes.Columns["ID_Nota"] != null)
                dgvReportes.Columns["ID_Nota"].HeaderText = "Número Nota";

            if (dgvReportes.Columns["Razon_Social"] != null)
                dgvReportes.Columns["Razon_Social"].HeaderText = "Razón Social";

            if (dgvReportes.Columns["Limite_Credito"] != null)
                dgvReportes.Columns["Limite_Credito"].HeaderText = "Límite de Crédito";

            if (dgvReportes.Columns["Consumo_Real"] != null)
                dgvReportes.Columns["Consumo_Real"].HeaderText = "Consumo Real";
        }
    }
}