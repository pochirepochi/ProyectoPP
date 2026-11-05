using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using Capa_Entidades;
using Capa_Logica;
using Capa_Datos;

namespace Proyecto_PP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtCont.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCont.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCont.Focus();
                return;
            }

            string usuario = txtUsuario.Text.Trim();
            string clavePlana = txtCont.Text;
            string claveHasheada = EncriptarSHA256(clavePlana);

            try
            {
                using (SqlConnection con = ConexionDB.ObtenerConexion())
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_nombre_usuario", usuario);
                        cmd.Parameters.AddWithValue("@p_contrasena", claveHasheada);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                int idUsuario = dr["id_usuario"] != DBNull.Value ? Convert.ToInt32(dr["id_usuario"]) : 0;
                                int idRol = dr["id_Rol"] != DBNull.Value ? Convert.ToInt32(dr["id_Rol"]) : 0;

                                Sesion.IdUsuario = idUsuario;
                                Sesion.NombreUsuario = usuario;
                                Sesion.IdRol = idRol;

                                DataTable dtPreguntas = DatosSeguridad.ObtenerPreguntas(usuario);
                                if (dtPreguntas.Rows.Count == 0)
                                {
                                    MessageBox.Show("Detectamos que no has configurado tus preguntas de seguridad. Es obligatorio para ingresar.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    FormPrimerIngreso ventanaPrimerIngreso = new FormPrimerIngreso(idUsuario);

                                    if (ventanaPrimerIngreso.ShowDialog() != DialogResult.OK)
                                    {
                                        MessageBox.Show("No es posible ingresar al sistema sin la configuración de seguridad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }

                                this.Hide();

                                if (idRol == 1)
                                {
                                    new Administrador().ShowDialog();
                                }
                                else if (idRol == 3)
                                {
                                    new FrmPrincipal().ShowDialog();
                                }
                                else
                                {
                                    new Usuario().ShowDialog();
                                }

                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void ckbMostrar_CheckedChanged(object sender, EventArgs e) => txtCont.UseSystemPasswordChar = !ckbMostrar.Checked;
        private void lblOlvidar_Click(object sender, EventArgs e) => new Form3().Show();
        private void btnSalir_Click(object sender, EventArgs e) => this.Close();

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}