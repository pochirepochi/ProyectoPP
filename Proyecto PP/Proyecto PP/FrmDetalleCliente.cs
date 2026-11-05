using System;
using System.Windows.Forms;
using Capa_Entidades;
using Capa_Logica;

namespace Proyecto_PP
{
    public partial class FrmDetalleCliente : Form
    {
        private const string TEXTO_NUEVO = "Guardar Cliente";
        private const string TEXTO_CAMBIOS = "Guardar Cambios";

        private ClienteLogica _clienteLogica = new ClienteLogica();
        private ContactoClienteLogica _contactoLogica = new ContactoClienteLogica();
        private DireccionClienteLogica _direccionLogica = new DireccionClienteLogica();

        private Cliente _clienteActual;
        private int _idCliente;
        private bool _iniciarEnEdicion;

        private bool _estadoActivo = true;

        public FrmDetalleCliente(int idCliente, bool iniciarEnEdicion = false)
        {
            InitializeComponent();
            _idCliente = idCliente;
            _iniciarEnEdicion = iniciarEnEdicion;

            cmbProvincia.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPartido.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLocalidad.DropDownStyle = ComboBoxStyle.DropDownList;

            txtCuit.MaxLength = 13;       // 11 dígitos + 2 guiones
            txtCuit.KeyPress += txtCuit_KeyPress;
            txtCuit.Leave += txtCuit_Leave;

            txtContacto.MaxLength = 20;   // alcanza para "+54 9 11 2345-6789"
            txtContacto.KeyPress += txtContacto_KeyPress;
        }

        private void FrmDetalleCliente_Load(object sender, EventArgs e)
        {
            cmbProvincia.DataSource = _direccionLogica.ListarProvincias();

            if (_idCliente == 0)
            {
                _clienteActual = new Cliente();
                _estadoActivo = true;
                ActivarModoEdicion();
            }
            else
            {
                CargarDatos();
                if (_iniciarEnEdicion) ActivarModoEdicion();
                else ActivarModoLectura();
            }
        }

        private void ActualizarBotonesEstado()
        {
            if (btnGuardar.Text == TEXTO_NUEVO)
            {
                btnActivar.Visible = false;
                btnDesactivar.Visible = false;
                return;
            }

            if (btnGuardar.Visible)
            {
                if (_estadoActivo)
                {
                    btnActivar.Visible = false;
                    btnDesactivar.Visible = true;
                }
                else
                {
                    btnActivar.Visible = true;
                    btnDesactivar.Visible = false;
                }
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            _estadoActivo = true;
            ActualizarBotonesEstado();
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            _estadoActivo = false;
            ActualizarBotonesEstado();
        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProvincia.SelectedItem != null)
                cmbPartido.DataSource = _direccionLogica.ListarPartidos(cmbProvincia.SelectedItem.ToString());
            else
                cmbPartido.DataSource = null;
        }

        private void cmbPartido_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPartido.SelectedItem != null)
                cmbLocalidad.DataSource = _direccionLogica.ListarLocalidades(cmbPartido.SelectedItem.ToString());
            else
                cmbLocalidad.DataSource = null;
        }

        private void cmbLocalidad_SelectedIndexChanged(object sender, EventArgs e) { }

        private void CargarDatos()
        {
            try
            {
                _clienteActual = _clienteLogica.BuscarClientePorId(_idCliente);
                txtRazonSocial.Text = _clienteActual.Razon_Social;
                txtCuit.Text = _clienteActual.CUIT_DNI;
                txtLimite.Text = _clienteActual.Limite_Credito.ToString("0.00");
                txtDescuento.Text = _clienteActual.Descuento_General.ToString("0.00");

                _estadoActivo = _clienteActual.Activo;

                var contacto = _contactoLogica.ObtenerPorCliente(_idCliente);
                txtNombreContacto.Text = contacto.Nombre;
                txtContacto.Text = contacto.Telefono;

                var direccion = _direccionLogica.ObtenerPorCliente(_idCliente);
                if (!string.IsNullOrEmpty(direccion.Provincia)) cmbProvincia.Text = direccion.Provincia;
                if (!string.IsNullOrEmpty(direccion.Partido)) cmbPartido.Text = direccion.Partido;
                if (!string.IsNullOrEmpty(direccion.Localidad)) cmbLocalidad.Text = direccion.Localidad;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActivarModoLectura()
        {
            txtRazonSocial.ReadOnly = true; txtCuit.ReadOnly = true;
            txtLimite.ReadOnly = true; txtDescuento.ReadOnly = true;
            txtNombreContacto.ReadOnly = true; txtContacto.ReadOnly = true;
            cmbProvincia.Enabled = false; cmbPartido.Enabled = false; cmbLocalidad.Enabled = false;

            btnModificar.Visible = true;
            btnActivar.Visible = false;
            btnDesactivar.Visible = false;
            btnGuardar.Visible = false;
            btnDescartar.Visible = false;
        }

        private void ActivarModoEdicion()
        {
            txtRazonSocial.ReadOnly = false; txtCuit.ReadOnly = false;
            txtLimite.ReadOnly = false; txtDescuento.ReadOnly = false;
            txtNombreContacto.ReadOnly = false; txtContacto.ReadOnly = false;
            cmbProvincia.Enabled = true; cmbPartido.Enabled = true; cmbLocalidad.Enabled = true;

            btnModificar.Visible = false;
            btnGuardar.Visible = true;
            btnDescartar.Visible = true;

            // El texto del botón define si se crea o se modifica
            btnGuardar.Text = _idCliente == 0 ? TEXTO_NUEVO : TEXTO_CAMBIOS;

            ActualizarBotonesEstado();
        }

        private void btnModificar_Click(object sender, EventArgs e) => ActivarModoEdicion();

        private void btnDescartar_Click(object sender, EventArgs e) => this.Close();

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtRazonSocial.Text))
                {
                    MessageBox.Show("La Razón Social no puede estar vacía.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string errorDoc = Validaciones.ValidarDocumento(txtCuit.Text, out string cuitDniLimpio);
                if (errorDoc != null)
                {
                    MessageBox.Show(errorDoc, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCuit.Focus();
                    return;
                }

                string telefonoIngresado = txtContacto.Text.Trim();
                if (string.IsNullOrWhiteSpace(telefonoIngresado))
                {
                    MessageBox.Show("Ingrese un teléfono de contacto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContacto.Focus();
                    return;
                }

                if (!decimal.TryParse(txtLimite.Text, out decimal limite) || limite < 0)
                {
                    MessageBox.Show("El Límite de Crédito debe ser un número válido mayor o igual a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtDescuento.Text, out decimal descuento) || descuento < 0 || descuento > 100)
                {
                    MessageBox.Show("El Descuento debe ser un número válido entre 0 y 100.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _clienteActual.Razon_Social = txtRazonSocial.Text.Trim();
                _clienteActual.CUIT_DNI = cuitDniLimpio;
                _clienteActual.Limite_Credito = limite;
                _clienteActual.Descuento_General = descuento;
                _clienteActual.Activo = _estadoActivo;

                // El texto del botón decide si se crea o se modifica
                bool esNuevo = btnGuardar.Text == TEXTO_NUEVO;
                int idGuardado;

                if (esNuevo)
                {
                    idGuardado = _clienteLogica.RegistrarCliente(_clienteActual, 1);
                }
                else
                {
                    idGuardado = _clienteActual.ID;
                    _clienteLogica.ActualizarCliente(_clienteActual, 1);
                }

                // ContactoClienteLogica normaliza y valida el teléfono
                _contactoLogica.GuardarContacto(new ContactoCliente
                {
                    FK_Cliente = idGuardado,
                    Nombre = txtNombreContacto.Text.Trim(),
                    Telefono = telefonoIngresado
                });

                _direccionLogica.GuardarDireccion(new DireccionCliente
                {
                    FK_Cliente = idGuardado,
                    Provincia = cmbProvincia.Text,
                    Partido = cmbPartido.Text,
                    Localidad = cmbLocalidad.Text
                });

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtCuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo dígitos y guiones
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
                e.Handled = true;
        }

        private void txtCuit_Leave(object sender, EventArgs e)
        {
            // Si es un CUIT (11 dígitos), lo muestra como XX-XXXXXXXX-X
            string d = Validaciones.SoloDigitos(txtCuit.Text);
            if (d.Length == 11)
                txtCuit.Text = $"{d.Substring(0, 2)}-{d.Substring(2, 8)}-{d.Substring(10, 1)}";
        }

        private void txtContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Dígitos, +, espacios, guiones y paréntesis
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && "+ -()".IndexOf(e.KeyChar) < 0)
                e.Handled = true;
        }

        private void txtSoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
            {
                e.Handled = true;
            }
        }

        private void txtNumerosDecimales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.' || e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1 || (sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }
    }
}