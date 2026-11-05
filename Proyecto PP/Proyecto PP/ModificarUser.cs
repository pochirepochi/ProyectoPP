using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Capa_Entidades;
using Capa_Logica;
using Capa_Datos;

namespace Proyecto_PP
{
    public partial class ModificarUser : Form
    {
        private int idUsuarioEditar;

        private readonly byte[] ClaveAES = Encoding.UTF8.GetBytes("ClaveSecretaProyectoPP1234567890");
        private readonly byte[] VectorAES = Encoding.UTF8.GetBytes("VectorInicio1234");

        public ModificarUser(int idUsuario)
        {
            InitializeComponent();
            idUsuarioEditar = idUsuario;
        }

        private void ModificarUser_Load(object sender, EventArgs e)
        {
            cmbRoles.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoles.Items.Clear();
            cmbRoles.Items.Add(new KeyValuePair<int, string>(1, "Administrador"));
            cmbRoles.Items.Add(new KeyValuePair<int, string>(2, "Usuario"));
            cmbRoles.Items.Add(new KeyValuePair<int, string>(3, "Vendedor"));
            cmbRoles.DisplayMember = "Value";
            cmbRoles.ValueMember = "Key";
            cmbRoles.DropDownStyle = ComboBoxStyle.DropDownList;

            CargarDatosUsuario();
        }

        private void CargarDatosUsuario()
        {
            using (SqlConnection con = ConexionDB.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerUsuarioPorId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", idUsuarioEditar);

                try
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtUsuario.Text = dr["nombre_usuario"].ToString();
                        txtEmail.Text = dr["email"].ToString();

                        int rolActual = Convert.ToInt32(dr["id_Rol"]);
                        bool esAdmin = (rolActual == 1);

                        chkHabilitarCambio.Visible = esAdmin;
                        chkHabilitarCambio.Checked = false;
                        grpAdmin.Visible = false;
                        flpPreguntas.Visible = esAdmin;

                        foreach (KeyValuePair<int, string> item in cmbRoles.Items)
                        {
                            if (item.Key == rolActual) { cmbRoles.SelectedItem = item; break; }
                        }
                    }
                    dr.Close();

                    if (flpPreguntas.Visible) CargarPreguntasSeguridad();
                }
                catch (Exception ex) { MessageBox.Show("Error al cargar datos: " + ex.Message); }
            }
        }

        private void CargarPreguntasSeguridad()
        {
            flpPreguntas.Controls.Clear();
            using (SqlConnection con = ConexionDB.ObtenerConexion())
            {
                string query = @"SELECT p.pregunta, r.id_catalogo, r.respuesta 
                                 FROM dbo.Catalogo_Preguntas p 
                                 INNER JOIN dbo.Respuestas_Seguridad r ON p.id_catalogo = r.id_catalogo 
                                 WHERE r.id_usuario = @idUsuario";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuarioEditar);

                try
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        string respuestaCifrada = dr["respuesta"].ToString();
                        string respuestaClara = DesencriptarAES(respuestaCifrada);

                        string textoLabel = $"{dr["pregunta"].ToString()} ({respuestaClara})";

                        Label lbl = new Label { Text = textoLabel, AutoSize = true, Margin = new Padding(0, 10, 0, 0) };

                        TextBox txt = new TextBox
                        {
                            Text = "",
                            Width = 250,
                            Tag = $"{dr["id_catalogo"]}|{respuestaCifrada}"
                        };

                        flpPreguntas.Controls.Add(lbl);
                        flpPreguntas.Controls.Add(txt);
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error al cargar preguntas: " + ex.Message); }
            }
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Por favor, completa los campos obligatorios.");
                return;
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(txtEmail.Text.Trim());
            }
            catch
            {
                MessageBox.Show("El email ingresado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = ConexionDB.ObtenerConexion())
            {
                con.Open();
                SqlTransaction trans = con.BeginTransaction();

                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ModificarUsuario", con, trans))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuarioEditar);
                        cmd.Parameters.AddWithValue("@nombre", txtUsuario.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@idRol", ((KeyValuePair<int, string>)cmbRoles.SelectedItem).Key);
                        cmd.ExecuteNonQuery();
                    }

                    if (grpAdmin.Visible && !string.IsNullOrEmpty(txtNuevaContra.Text))
                    {
                        if (txtNuevaContra.Text != txtConfirmarContra.Text) throw new Exception("Las contraseñas no coinciden.");

                        string nuevaClaveHash = EncriptarSHA256(txtNuevaContra.Text);

                        using (SqlCommand cmdPass = new SqlCommand("sp_ActualizarContraseña", con, trans))
                        {
                            cmdPass.CommandType = CommandType.StoredProcedure;
                            cmdPass.Parameters.AddWithValue("@idUsuario", idUsuarioEditar);
                            cmdPass.Parameters.AddWithValue("@nuevaClave", nuevaClaveHash);
                            cmdPass.ExecuteNonQuery();
                        }

                        int idConNuevo = 0;
                        using (SqlCommand cmdGetId = new SqlCommand("SELECT TOP 1 id_con FROM [dbo].[contraseña] WHERE id_usuario = @idUsuario AND es_activa = 1 ORDER BY id_con DESC", con, trans))
                        {
                            cmdGetId.Parameters.AddWithValue("@idUsuario", idUsuarioEditar);
                            var res = cmdGetId.ExecuteScalar();
                            if (res != null) idConNuevo = Convert.ToInt32(res);
                        }

                        if (idConNuevo > 0)
                        {
                            using (SqlCommand cmdHistorial = new SqlCommand("sp_RegistrarHistorialContraseña", con, trans))
                            {
                                cmdHistorial.CommandType = CommandType.StoredProcedure;
                                cmdHistorial.Parameters.AddWithValue("@idUsuario", idUsuarioEditar);
                                cmdHistorial.Parameters.AddWithValue("@idCon", idConNuevo);
                                cmdHistorial.Parameters.AddWithValue("@contraseña", nuevaClaveHash);
                                cmdHistorial.ExecuteNonQuery();
                            }
                        }
                    }

                    if (flpPreguntas.Visible)
                    {
                        using (SqlCommand cmdDel = new SqlCommand("sp_EliminarPreguntasUsuario", con, trans))
                        {
                            cmdDel.CommandType = CommandType.StoredProcedure;
                            cmdDel.Parameters.AddWithValue("@idUsuario", idUsuarioEditar);
                            cmdDel.ExecuteNonQuery();
                        }

                        foreach (Control ctrl in flpPreguntas.Controls)
                        {
                            if (ctrl is TextBox txt && txt.Tag != null)
                            {
                                using (SqlCommand cmdQ = new SqlCommand("sp_GuardarRespuestaSeguridad", con, trans))
                                {
                                    string[] tagData = txt.Tag.ToString().Split('|');
                                    int idCatalogo = Convert.ToInt32(tagData[0]);
                                    string respuestaOriginalCifrada = tagData[1];

                                    string respuestaFinal = string.IsNullOrWhiteSpace(txt.Text)
                                                            ? respuestaOriginalCifrada
                                                            : EncriptarAES(txt.Text.Trim());

                                    cmdQ.CommandType = CommandType.StoredProcedure;
                                    cmdQ.Parameters.AddWithValue("@idUsuario", idUsuarioEditar);
                                    cmdQ.Parameters.AddWithValue("@idCatalogo", idCatalogo);
                                    cmdQ.Parameters.AddWithValue("@respuestaTexto", respuestaFinal);
                                    cmdQ.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    trans.Commit();
                    MessageBox.Show("Usuario y configuraciones actualizadas con éxito.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Error al guardar: " + ex.Message);
                }
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

        private string EncriptarAES(string textoPlano)
        {
            if (string.IsNullOrEmpty(textoPlano)) return textoPlano;
            using (Aes aes = Aes.Create())
            {
                aes.Key = ClaveAES;
                aes.IV = VectorAES;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs)) sw.Write(textoPlano);
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        private string DesencriptarAES(string textoCifrado)
        {
            if (string.IsNullOrEmpty(textoCifrado)) return "";
            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = ClaveAES;
                    aes.IV = VectorAES;
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                    using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(textoCifrado)))
                    {
                        using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader sr = new StreamReader(cs)) return sr.ReadToEnd();
                        }
                    }
                }
            }
            catch
            {
                return "";
            }
        }

        private void btnVolver_Click(object sender, EventArgs e) => this.Close();

        private void chkHabilitarCambio_CheckedChanged(object sender, EventArgs e)
        {
            grpAdmin.Visible = chkHabilitarCambio.Checked;
            if (!chkHabilitarCambio.Checked)
            {
                txtNuevaContra.Clear();
                txtConfirmarContra.Clear();
            }
        }

        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e) { }

        private void flpPreguntas_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbRoles_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}