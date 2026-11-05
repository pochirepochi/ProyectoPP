using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Capa_Entidades;
using Capa_Logica;

namespace Proyecto_PP
{
    public partial class FrmAjustesVenta : Form
    {
        private ClienteLogica _clienteLogica = new ClienteLogica();
        private NotaCreditoLogica _notaCreditoLogica = new NotaCreditoLogica();
        private NotaDebitoLogica _notaDebitoLogica = new NotaDebitoLogica();
        private FacturaVentaLogica _facturaLogica = new FacturaVentaLogica();

        public FrmAjustesVenta()
        {
            InitializeComponent();
            cmbClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFactura.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void FrmAjustesVenta_Load(object sender, EventArgs e)
        {
            CargarClientes();
            rbCredito.Checked = true;
        }

        private void CargarClientes()
        {
            try
            {
                cmbClientes.DataSource = _clienteLogica.ListarClientes();
                cmbClientes.DisplayMember = "Razon_Social";
                cmbClientes.ValueMember = "ID";
                cmbClientes.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedValue != null && int.TryParse(cmbClientes.SelectedValue.ToString(), out int idCliente))
            {
                try
                {
                    var facturasDelCliente = _facturaLogica.ObtenerFacturasPorCliente(idCliente);

                    if (facturasDelCliente.Count == 0)
                    {
                        cmbFactura.DataSource = null;
                        cmbFactura.Text = "Sin facturas registradas";
                        cmbFactura.Enabled = false;
                        txtMonto.Enabled = false;
                        txtMotivo.Enabled = false;
                    }
                    else
                    {
                        cmbFactura.DataSource = facturasDelCliente;
                        cmbFactura.DisplayMember = "InfoMostrar";
                        cmbFactura.ValueMember = "ID";

                        cmbFactura.Enabled = true;
                        txtMonto.Enabled = true;
                        txtMotivo.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar las facturas: " + ex.Message);
                }
            }
        }

        private void btnEmitir_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (cmbClientes.SelectedValue == null) throw new Exception("Seleccione un cliente.");

                if (cmbFactura.SelectedValue == null || !int.TryParse(cmbFactura.SelectedValue.ToString(), out int idFactura))
                    throw new Exception("Seleccione una factura válida.");

                if (!decimal.TryParse(txtMonto.Text, out decimal monto)) throw new Exception("El monto debe ser un número válido.");
                if (string.IsNullOrWhiteSpace(txtMotivo.Text)) throw new Exception("Debe ingresar un motivo.");

                int idCliente = Convert.ToInt32(cmbClientes.SelectedValue);

                if (rbCredito.Checked)
                {
                    NotaCreditoVenta nota = new NotaCreditoVenta()
                    {
                        FK_Factura_Venta = idFactura,
                        FK_Cliente = idCliente,
                        Monto = monto,
                        Motivo = txtMotivo.Text
                    };

                    _notaCreditoLogica.EmitirNotaCredito(nota, 1);
                    MessageBox.Show("Nota de Crédito emitida y guardada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (rbDebito.Checked)
                {
                    NotaDebitoVenta nota = new NotaDebitoVenta()
                    {
                        FK_Factura_Venta = idFactura,
                        FK_Cliente = idCliente,
                        Monto = monto,
                        Motivo = txtMotivo.Text
                    };

                    _notaDebitoLogica.EmitirNotaDebito(nota, 1);
                    MessageBox.Show("Nota de Débito emitida y guardada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            cmbClientes.SelectedIndex = -1;
            cmbFactura.DataSource = null;
            cmbFactura.Text = "";
            txtMonto.Clear();
            txtMotivo.Clear();
            rbCredito.Checked = true;
            cmbClientes.Focus();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmPrincipal pantallaPrincipal = new FrmPrincipal();
            pantallaPrincipal.Show();
            this.Hide();
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            
        }
    }
}