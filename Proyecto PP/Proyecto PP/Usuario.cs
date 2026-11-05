using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Capa_Entidades; 
using Capa_Logica;
using Capa_Datos;

namespace Proyecto_PP
{
    public partial class Usuario : Form
    {
        private bool reqLongitud = false;
        private bool reqMayus = false;
        private bool reqAlfanum = false;
        private bool reqEspecial = false;

        private readonly byte[] ClaveAES = Encoding.UTF8.GetBytes("ClaveSecretaProyectoPP1234567890");
        private readonly byte[] VectorAES = Encoding.UTF8.GetBytes("VectorInicio1234");

        public Usuario()
        {
            InitializeComponent();
        }

        private void Usuario_Load(object sender, EventArgs e) { }

        private void btnGuardarPass_Click(object sender, EventArgs e)
        {
            if (txtNueva.Text != txtConfirmar.Text)
            {
                MessageBox.Show("Las contraseñas nuevas no coinciden.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lblCaracter8.Visible || lblMayus.Visible || lblNumyLet.Visible || lblEspecial.Visible)
            {
                MessageBox.Show("Por favor, cumplí con todos los requisitos exigidos.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hashActual = HashSHA256(txtActual.Text);
            bool esValida = DatosSeguridad.ValidarContraseñaActual(Sesion.NombreUsuario, hashActual);

            if (esValida)
            {
                string hashNueva = HashSHA256(txtNueva.Text);


                if (DatosSeguridad.EsContrasenaRepetida(Sesion.IdUsuario, hashNueva, 3))
                {
                    MessageBox.Show("Por seguridad, no podés usar una de tus últimas 3 contraseñas. Por favor, elegí una diferente.", "Aviso de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtNueva.Clear();
                    txtConfirmar.Clear();
                    txtNueva.Focus();
                    return;
                }


                DatosSeguridad.ActualizarPassword(Sesion.NombreUsuario, hashNueva, 0);

                MessageBox.Show("Contraseña actualizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtActual.Clear();
                txtNueva.Clear();
                txtConfirmar.Clear();
            }
            else
            {
                MessageBox.Show("La contraseña actual es incorrecta.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNueva_TextChanged(object sender, EventArgs e)
        {
            ValidarContrasenaEnTiempoReal();
        }

        private void ValidarContrasenaEnTiempoReal()
        {
            string texto = txtNueva.Text;

            lblCaracter8.Visible = reqLongitud && (texto.Length < 8);
            lblMayus.Visible = reqMayus && !texto.Any(char.IsUpper);
            lblNumyLet.Visible = reqAlfanum && !(texto.Any(char.IsLetter) && texto.Any(char.IsDigit));
            lblEspecial.Visible = reqEspecial && !texto.Any(c => "@!$".Contains(c));
        }

        private void CargarPreguntas()
        {
            flowPreguntas.Controls.Clear();
            flowPreguntas.FlowDirection = FlowDirection.TopDown;
            flowPreguntas.WrapContents = false;
            flowPreguntas.AutoScroll = true;

            DataTable dt = DatosSeguridad.ObtenerPreguntas(Sesion.NombreUsuario);

            if (dt == null || dt.Rows.Count == 0)
            {
                dt = DatosSeguridad.TraerPreguntas();
            }

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string textoPregunta = "";
                    if (row.Table.Columns.Contains("preguntas"))
                        textoPregunta = row["preguntas"].ToString();
                    else if (row.Table.Columns.Contains("pregunta"))
                        textoPregunta = row["pregunta"].ToString();

                    // Forzamos a buscar la columna 'respuesta' tal como está en la base de datos
                    string colResp = "respuesta";

                    bool yaRespondida = row.Table.Columns.Contains(colResp) && row[colResp] != DBNull.Value && !string.IsNullOrWhiteSpace(row[colResp].ToString());

                    TextBox txt = new TextBox
                    {
                        Width = 300,
                        Margin = new Padding(5, 0, 5, 15),
                        Text = ""
                    };

                    if (yaRespondida)
                    {
                        string respuestaDesencriptada = DesencriptarAES(row[colResp].ToString());
                        textoPregunta += $" ({respuestaDesencriptada})";
                        txt.Text = respuestaDesencriptada;
                    }
                    else
                    {
                        textoPregunta += " (Falta responder)";
                    }

                    Label lbl = new Label
                    {
                        Text = textoPregunta,
                        AutoSize = true,
                        Margin = new Padding(5, 10, 5, 2),
                        Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold)
                    };

                    flowPreguntas.Controls.Add(lbl);

                    if (row.Table.Columns.Contains("id_pregseg") && row["id_pregseg"] != DBNull.Value)
                        txt.Tag = row["id_pregseg"];
                    else if (row.Table.Columns.Contains("id_catalogo") && row["id_catalogo"] != DBNull.Value)
                        txt.Tag = row["id_catalogo"];
                    else
                        txt.Tag = 0;

                    flowPreguntas.Controls.Add(txt);
                }
            }
            else
            {
                MessageBox.Show("No se pudieron cargar las preguntas del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabPregseg)
            {
                CargarPreguntas();
            }
        }

        private void btnPreguntas_Click(object sender, EventArgs e)
        {
            bool huboCambio = false;

            using (SqlConnection con = ConexionDB.ObtenerConexion())
            {
                con.Open();
                foreach (Control control in flowPreguntas.Controls)
                {
                    if (control is TextBox txt && !string.IsNullOrWhiteSpace(txt.Text))
                    {
                        int idPregunta = Convert.ToInt32(txt.Tag);
                        string respuestaEncriptada = EncriptarAES(txt.Text.Trim());

                        using (SqlCommand cmd = new SqlCommand("sp_GuardarRespuestaSeguridad", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@idUsuario", Sesion.IdUsuario);
                            cmd.Parameters.AddWithValue("@idCatalogo", idPregunta);
                            cmd.Parameters.AddWithValue("@respuestaTexto", respuestaEncriptada);
                            cmd.ExecuteNonQuery();
                        }

                        huboCambio = true;
                    }
                }
            }

            if (huboCambio)
            {
                MessageBox.Show("Preguntas de seguridad guardadas/actualizadas con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarPreguntas();
            }
            else
            {
                MessageBox.Show("No se realizaron cambios porque dejaste los campos vacíos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void txtActual_TextChanged(object sender, EventArgs e) { }
        private void txtConfirmar_TextChanged(object sender, EventArgs e) { }
        private void flowPreguntas_Paint(object sender, PaintEventArgs e) { }

        private string HashSHA256(string texto)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(texto));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++) builder.Append(bytes[i].ToString("x2"));
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

        private void tabCambiarContrasena_Click(object sender, EventArgs e) { }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Close();
        }

        private void Usuario_Load_1(object sender, EventArgs e)
        {
            using (SqlConnection con = ConexionDB.ObtenerConexion())
            {
                string query = "SELECT reqLongitud, reqMayus, reqAlfanum, reqEspecial FROM dbo.usuarios WHERE nombre_usuario = @usuario";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@usuario", Sesion.NombreUsuario);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            reqLongitud = Convert.ToBoolean(reader["reqLongitud"]);
                            reqMayus = Convert.ToBoolean(reader["reqMayus"]);
                            reqAlfanum = Convert.ToBoolean(reader["reqAlfanum"]);
                            reqEspecial = Convert.ToBoolean(reader["reqEspecial"]);
                        }
                    }
                }
            }
            ValidarContrasenaEnTiempoReal();
        }

        private void label4_Click(object sender, EventArgs e) { }
    }
}