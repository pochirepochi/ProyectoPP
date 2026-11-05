using System;
using System.Windows.Forms;
using Capa_Logica;

namespace Proyecto_PP
{
    public partial class FrmReportes : Form
    {
        private enum TipoReporte { Ninguno, Alertas, Notas }

        private ReportesLogica _reportesLogica = new ReportesLogica();
        private TipoReporte _reporteActual = TipoReporte.Ninguno;

        public FrmReportes()
        {
            InitializeComponent();
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            HabilitarFiltros(false);
            chkActivo.Checked = true;
            chkDesactivo.Checked = true;

            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Value = new DateTime(2020, 1, 1);

            DateTime hoy = DateTime.Today;
            dateTimePicker2.MaxDate = hoy;
            dateTimePicker2.Value = hoy;
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
            _reporteActual = TipoReporte.Alertas;
            HabilitarFiltros(true);
            AplicarFiltros();
        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            _reporteActual = TipoReporte.Notas;
            HabilitarFiltros(true);
            AplicarFiltros();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmPrincipal pantallaPrincipal = new FrmPrincipal();
            pantallaPrincipal.Show();
            this.Hide();
        }

        private FiltroReporte ArmarFiltro()
        {
            return new FiltroReporte
            {
                Busqueda = txtBuscar.Text,
                Activos = chkActivo.Checked,
                Inactivos = chkDesactivo.Checked,
                MontoMin = decimal.TryParse(txtMontoMin.Text, out decimal min) ? min : (decimal?)null,
                MontoMax = decimal.TryParse(txtMontoMax.Text, out decimal max) ? max : (decimal?)null,
                Desde = dateTimePicker1.Value,
                Hasta = dateTimePicker2.Value,
                Orden = chkMontoMayorAMenor.Checked ? 1 : chkMontoMenorAMayor.Checked ? 2 : 0
            };
        }

        private void AplicarFiltros()
        {
            if (_reporteActual == TipoReporte.Ninguno) return;

            try
            {
                FiltroReporte filtro = ArmarFiltro();

                if (_reporteActual == TipoReporte.Alertas)
                    dgvReportes.DataSource = _reportesLogica.ReporteAlertasCredito(filtro);
                else
                    dgvReportes.DataSource = _reportesLogica.ReporteHistorialNotas(filtro);

                ConfigurarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnas()
        {
            if (dgvReportes.Columns["Activo"] != null)
                dgvReportes.Columns["Activo"].Visible = false;

            if (dgvReportes.Columns["ID"] != null)
                dgvReportes.Columns["ID"].Visible = false;

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

            if (dgvReportes.Columns["Fecha"] != null)
                dgvReportes.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e) { AplicarFiltros(); }

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

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value.Date > DateTime.Today)
            {
                dateTimePicker2.Value = DateTime.Today;
                return;
            }
            AplicarFiltros();
        }

        private void txtNumerosDecimales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
                e.Handled = true;

            if ((e.KeyChar == '.' || e.KeyChar == ',') &&
                ((sender as TextBox).Text.IndexOf('.') > -1 || (sender as TextBox).Text.IndexOf(',') > -1))
                e.Handled = true;
        }

        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void groupBox3_Enter(object sender, EventArgs e) { }
        private void dgvReportes_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvReportes_MouseDown(object sender, MouseEventArgs e) { }
    }
}