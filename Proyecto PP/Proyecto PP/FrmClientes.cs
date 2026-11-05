using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Capa_Entidades;
using Capa_Logica;

namespace Proyecto_PP
{
    public partial class FrmClientes : Form
    {
        private ClienteLogica _clienteLogica = new ClienteLogica();
        private List<Cliente> _clientesCache = new List<Cliente>();
        private int idClienteSeleccionado = 0;

        public FrmClientes()
        {
            InitializeComponent();

            dgvClientes.CellFormatting += dgvClientes_CellFormatting;
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            rbTodos.Checked = true;
            btnReactivar.Visible = true;
            btnBaja.Visible = true;
            RefrescarDesdeBD();

            dgvClientes.ClearSelection();
            dgvClientes.CurrentCell = null;
        }

        // Va a la base de datos y luego actualiza la grilla
        private void RefrescarDesdeBD()
        {
            try
            {
                _clientesCache = _clienteLogica.ListarClientes().ToList();
                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Filtra solo en memoria, sin ir a la base
        private void CargarGrilla()
        {
            var lista = _clientesCache;

            if (rbActivos.Checked)
                lista = lista.Where(c => c.Activo).ToList();
            else if (rbInactivos.Checked)
                lista = lista.Where(c => !c.Activo).ToList();

            string busqueda = txtBuscar.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(busqueda))
            {
                if (int.TryParse(busqueda, out int idBuscado))
                    lista = lista.Where(c => c.ID == idBuscado).ToList();
                else
                    lista = lista.Where(c => c.Razon_Social != null && c.Razon_Social.ToLower().Contains(busqueda)).ToList();
            }

            dgvClientes.DataSource = lista;
            ConfigurarGrilla();

            dgvClientes.ClearSelection();
            idClienteSeleccionado = 0;
        }

        private void ConfigurarGrilla()
        {
            if (dgvClientes.Columns["Activo"] != null)
            {
                dgvClientes.Columns["Activo"].Visible = false;
            }

            if (!dgvClientes.Columns.Contains("ColEditar"))
            {
                DataGridViewButtonColumn colEditar = new DataGridViewButtonColumn();
                colEditar.Name = "ColEditar";
                colEditar.HeaderText = "Editar";
                colEditar.Text = "Editar";
                colEditar.UseColumnTextForButtonValue = true;
                dgvClientes.Columns.Add(colEditar);
            }

            if (!dgvClientes.Columns.Contains("ColBaja"))
            {
                DataGridViewButtonColumn colBaja = new DataGridViewButtonColumn();
                colBaja.Name = "ColBaja";
                colBaja.HeaderText = "Acción";
                dgvClientes.Columns.Add(colBaja);
            }

            dgvClientes.RowHeadersVisible = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.MultiSelect = false;
            dgvClientes.ReadOnly = true;

            RenombrarColumnas();
        }

        private void dgvClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvClientes.Columns[e.ColumnIndex].Name == "ColBaja" && e.RowIndex >= 0)
            {
                bool estaActivo = Convert.ToBoolean(dgvClientes.Rows[e.RowIndex].Cells["Activo"].Value);
                e.Value = estaActivo ? "Dar de baja" : "Reactivar";
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string nombreColumna = dgvClientes.Columns[e.ColumnIndex].Name;
                idClienteSeleccionado = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells["ID"].Value);

                if (nombreColumna == "ColEditar")
                {
                    FrmDetalleCliente frmDetalle = new FrmDetalleCliente(idClienteSeleccionado, true);
                    frmDetalle.Text = "Modificar cliente";
                    frmDetalle.ShowDialog();
                    RefrescarDesdeBD();
                }
                else if (nombreColumna == "ColBaja")
                {
                    bool estaActivo = Convert.ToBoolean(dgvClientes.Rows[e.RowIndex].Cells["Activo"].Value);

                    if (estaActivo)
                    {
                        DialogResult respuesta = MessageBox.Show("¿Está seguro que desea dar de baja a este cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (respuesta == DialogResult.Yes)
                        {
                            try
                            {
                                _clienteLogica.BajaCliente(idClienteSeleccionado, 1);
                                MessageBox.Show("Cliente dado de baja con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                RefrescarDesdeBD();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        DialogResult respuesta = MessageBox.Show("¿Está seguro que desea reactivar a este cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (respuesta == DialogResult.Yes)
                        {
                            try
                            {
                                _clienteLogica.ReactivarCliente(idClienteSeleccionado, 1);
                                MessageBox.Show("Cliente reactivado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                RefrescarDesdeBD();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private void dgvClientes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvClientes.Rows[e.RowIndex].Cells["ID"].Value != null)
            {
                idClienteSeleccionado = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells["ID"].Value);
            }
        }

        private void dgvClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;

                if (idClienteSeleccionado > 0)
                {
                    FrmDetalleCliente frmDetalle = new FrmDetalleCliente(idClienteSeleccionado);
                    frmDetalle.Text = "Modificar cliente";
                    frmDetalle.ShowDialog();
                    RefrescarDesdeBD();
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTodos.Checked)
            {
                btnReactivar.Visible = true;
                btnBaja.Visible = true;
                CargarGrilla();
            }
        }

        private void rbActivos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbActivos.Checked)
            {
                btnReactivar.Visible = false;
                btnBaja.Visible = true;
                CargarGrilla();
            }
        }

        private void rbInactivos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbInactivos.Checked)
            {
                btnReactivar.Visible = true;
                btnBaja.Visible = false;
                CargarGrilla();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            FrmDetalleCliente frmAlta = new FrmDetalleCliente(0, true);
            frmAlta.Text = "Dar alta al cliente";
            frmAlta.ShowDialog();
            RefrescarDesdeBD();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null || !dgvClientes.CurrentRow.Selected)
            {
                MessageBox.Show("Por favor, seleccione un cliente de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (idClienteSeleccionado == 0)
            {
                MessageBox.Show("Por favor, seleccione un cliente de la grilla primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FrmDetalleCliente frmDetalle = new FrmDetalleCliente(idClienteSeleccionado, true);
            frmDetalle.Text = "Modificar cliente";
            frmDetalle.ShowDialog();
            RefrescarDesdeBD();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado == 0)
            {
                MessageBox.Show("Por favor, seleccione un cliente de la grilla primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool estaActivo = Convert.ToBoolean(dgvClientes.CurrentRow?.Cells["Activo"].Value);

            if (!estaActivo)
            {
                MessageBox.Show("El cliente seleccionado ya se encuentra dado de baja (desactivado).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Está seguro que desea dar de baja a este cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    _clienteLogica.BajaCliente(idClienteSeleccionado, 1);
                    MessageBox.Show("Cliente dado de baja con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefrescarDesdeBD();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReactivar_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado == 0)
            {
                MessageBox.Show("Por favor, seleccione un cliente de la grilla primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool estaActivo = Convert.ToBoolean(dgvClientes.CurrentRow?.Cells["Activo"].Value);

            if (estaActivo)
            {
                MessageBox.Show("El cliente seleccionado ya se encuentra activo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Está seguro que desea reactivar a este cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    _clienteLogica.ReactivarCliente(idClienteSeleccionado, 1);
                    MessageBox.Show("Cliente reactivado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefrescarDesdeBD();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && idClienteSeleccionado > 0)
            {
                FrmDetalleCliente frmDetalle = new FrmDetalleCliente(idClienteSeleccionado);
                frmDetalle.Text = "Modificar cliente";
                frmDetalle.ShowDialog();
                RefrescarDesdeBD();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmPrincipal pantallaPrincipal = new FrmPrincipal();
            pantallaPrincipal.Show();
            this.Hide();
        }

        private void dgvClientes_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hit = dgvClientes.HitTest(e.X, e.Y);

            if (hit.Type == DataGridViewHitTestType.None)
            {
                dgvClientes.ClearSelection();
                dgvClientes.CurrentCell = null;
            }
        }

        private void RenombrarColumnas()
        {
            if (dgvClientes.Columns["ID"] != null)
                dgvClientes.Columns["ID"].HeaderText = "ID";

            if (dgvClientes.Columns["CUIT_DNI"] != null)
                dgvClientes.Columns["CUIT_DNI"].HeaderText = "CUIT / DNI";

            if (dgvClientes.Columns["Razon_Social"] != null)
                dgvClientes.Columns["Razon_Social"].HeaderText = "Razón Social";

            if (dgvClientes.Columns["Limite_Credito"] != null)
            {
                dgvClientes.Columns["Limite_Credito"].HeaderText = "Límite de Crédito";
                dgvClientes.Columns["Limite_Credito"].DefaultCellStyle.Format = "N2";
            }

            if (dgvClientes.Columns["Descuento_General"] != null)
            {
                dgvClientes.Columns["Descuento_General"].HeaderText = "Descuento General";
                dgvClientes.Columns["Descuento_General"].DefaultCellStyle.Format = "0.##\\%";
            }
        }
    }
}