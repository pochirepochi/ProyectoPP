using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Capa_Entidades;
using Capa_Logica;
using Capa_Datos;

namespace Proyecto_PP
{
    public partial class Registro : Form
    {
        private static Random random = new Random();

        public Registro()
        {
            InitializeComponent();
        }

        private void Registro_Load(object sender, EventArgs e)
        {
            cmbProvincia.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoles.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbProvincia.Items.AddRange(new string[] {
                "Buenos Aires", "CABA", "Catamarca", "Chaco", "Chubut", "Córdoba",
                "Corrientes", "Entre Ríos", "Formosa", "Jujuy", "La Pampa", "La Rioja",
                "Mendoza", "Misiones", "Neuquén", "Río Negro", "Salta", "San Juan",
                "San Luis", "Santa Cruz", "Santa Fe", "Santiago del Estero",
                "Tierra del Fuego", "Tucumán"
            });

            cmbProvincia.SelectedIndex = 0;

            cmbRoles.Items.Clear();
            cmbRoles.Items.Add(new KeyValuePair<int, string>(1, "Administrador"));
            cmbRoles.Items.Add(new KeyValuePair<int, string>(2, "Usuario"));
            cmbRoles.Items.Add(new KeyValuePair<int, string>(3, "Vendedor")); // Agregá esta línea

            cmbRoles.DisplayMember = "Value";
            cmbRoles.ValueMember = "Key";
            cmbRoles.SelectedIndex = 1;

            txtUsuario.ReadOnly = true;
        }

        private string GenerarContraseñaSegura()
        {
            string minusculas = "abcdefghijklmnopqrstuvwxyz";
            string mayusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numeros = "0123456789";
            string especiales = "!@#$%^&*()_+-=";

            string caracteresPermitidos = minusculas;
            StringBuilder contraseña = new StringBuilder();

            contraseña.Append(minusculas[random.Next(minusculas.Length)]);

            if (chkMayuscula.Checked)
            {
                caracteresPermitidos += mayusculas;
                contraseña.Append(mayusculas[random.Next(mayusculas.Length)]);
            }

            if (chkAlfanumerica.Checked)
            {
                caracteresPermitidos += numeros;
                contraseña.Append(numeros[random.Next(numeros.Length)]);
            }

            if (chkEspecial.Checked)
            {
                caracteresPermitidos += especiales;
                contraseña.Append(especiales[random.Next(especiales.Length)]);
            }

            int longitudFinal = chkLongitud.Checked ? 8 : 6;

            while (contraseña.Length < longitudFinal)
            {
                contraseña.Append(caracteresPermitidos[random.Next(caracteresPermitidos.Length)]);
            }

            return string.Concat(contraseña.ToString().ToCharArray().OrderBy(s => random.Next()));
        }

        private string GenerarNombreUsuarioUnico(string nombre, string apellido)
        {
            string baseUsuario = (nombre.Trim() + "." + apellido.Trim()).ToLower().Replace(" ", "");
            string usuarioFinal = baseUsuario;
            int contador = 1;

            while (ExisteUsuario(usuarioFinal))
            {
                usuarioFinal = baseUsuario + contador.ToString();
                contador++;
            }

            return usuarioFinal;
        }

        private string EncriptarSHA256(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(texto));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes) builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }

        private void btnCompletarRegistro_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtCont.Text))
            {
                MessageBox.Show("Por favor, completá todos los campos obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtDocumento.Text.Trim().Length < 7)
            {
                MessageBox.Show("El DNI debe tener al menos 7 números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocumento.Focus();
                return;
            }

            if (ExisteUsuario(txtUsuario.Text.Trim()))
            {
                MessageBox.Show("Ese nombre de usuario ya está en uso. Por favor, elegí otro.", "Usuario duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return;
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(txtEmail.Text.Trim());
            }
            catch
            {
                MessageBox.Show("El email ingresado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }

            if (!(cmbRoles.SelectedItem is KeyValuePair<int, string> itemSeleccionado))
            {
                MessageBox.Show("Debes seleccionar un rol válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idRolSeleccionado = itemSeleccionado.Key;
            string clavePlana = txtCont.Text;
            string claveEncriptada = EncriptarSHA256(clavePlana);
            string telefonoFinal = "+54 9 " + txtTelefono.Text.Trim();
            string direccionCompleta = $"{txtCalle.Text.Trim()}, {txtLocalidad.Text.Trim()}, {cmbProvincia.SelectedItem.ToString()}";

            using (SqlConnection con = ConexionDB.ObtenerConexion())
            {
                try
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@nombre_usuario", txtUsuario.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@clave", claveEncriptada);
                        cmd.Parameters.AddWithValue("@idRol", idRolSeleccionado);
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                        cmd.Parameters.AddWithValue("@dni", txtDocumento.Text.Trim());
                        cmd.Parameters.AddWithValue("@telefono", telefonoFinal);
                        cmd.Parameters.AddWithValue("@direccion", direccionCompleta);
                        cmd.Parameters.AddWithValue("@reqLongitud", chkLongitud.Checked);
                        cmd.Parameters.AddWithValue("@reqMayus", chkMayuscula.Checked);
                        cmd.Parameters.AddWithValue("@reqAlfanum", chkAlfanumerica.Checked);
                        cmd.Parameters.AddWithValue("@reqEspecial", chkEspecial.Checked);

                        cmd.ExecuteNonQuery();
                    }

                    try
                    {
                        ArmarMail.DireccionCorreo = txtEmail.Text.Trim();
                        ArmarMail.Asunto = "Bienvenido a nuestro sistema";
                        ArmarMail.NuevaContraseña = clavePlana;
                        ArmarMail.Preparar();

                        MessageBox.Show("Usuario registrado y correo enviado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception exMail)
                    {
                        MessageBox.Show("El usuario se registró, pero falló el envío del mail: " + exMail.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e) => this.Close();

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Por favor, ingresá nombre y apellido primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Focus();
                return;
            }

            txtUsuario.Text = GenerarNombreUsuarioUnico(txtNombre.Text, txtApellido.Text);
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool ExisteUsuario(string nombreUsuario)
        {
            using (SqlConnection con = ConexionDB.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_VerificarUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@usuario", nombreUsuario);

                    con.Open();

                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        private void btnGenerarClave_Click(object sender, EventArgs e)
        {
            txtCont.Text = GenerarContraseñaSegura();
        }
    }
}