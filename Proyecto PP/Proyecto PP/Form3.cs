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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            if (string.IsNullOrEmpty(usuario))
            {
                MessageBox.Show("Por favor, ingresa el usuario.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            flowPreguntas.Controls.Clear();
            DataTable dt = DatosSeguridad.ObtenerPreguntas(usuario);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Label lbl = new Label { Text = row[1].ToString(), AutoSize = true, Margin = new Padding(0, 10, 0, 0) };
                    flowPreguntas.Controls.Add(lbl);

                    TextBox txt = new TextBox { Width = 300, Tag = row[0] };
                    flowPreguntas.Controls.Add(txt);
                }
            }
            else
            {
                MessageBox.Show("Usuario no encontrado o sin preguntas configuradas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();

            if (flowPreguntas.Controls.Count == 0)
            {
                MessageBox.Show("Primero debes buscar el usuario para contestar las preguntas.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (Control control in flowPreguntas.Controls)
            {
                if (control is TextBox txt)
                {
                    if (string.IsNullOrWhiteSpace(txt.Text))
                    {
                        MessageBox.Show("Por favor, completá todas las respuestas de seguridad.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt.Focus();
                        return;
                    }
                }
            }

            if (!ValidarRespuestasDelUsuario())
            {
                MessageBox.Show("Las respuestas de seguridad son incorrectas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string mailUsuario = DatosSeguridad.ObtenerEmailUsuario(usuario);

            if (string.IsNullOrEmpty(mailUsuario) || !mailUsuario.Contains("@"))
            {
                MessageBox.Show("El usuario no tiene un correo válido registrado en el sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string nuevaClave = GenerarClaveAleatoria();
                string claveHasheada = HashSHA256(nuevaClave);

                DatosSeguridad.ActualizarPassword(usuario, claveHasheada, 1);

                string asunto = "Recuperación de contraseña";
                string cuerpo = $"Hola {usuario},<br><br>Tu nueva contraseña es: <b>{nuevaClave}</b><br><br>Te recomendamos cambiarla al ingresar.";

                EnviarMail.sendMail(mailUsuario, asunto, cuerpo);

                Cursor.Current = Cursors.Default;
                MessageBox.Show("¡Contraseña restablecida! Revisá tu correo.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form1 form1 = new Form1();
                form1.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Error al procesar: " + ex.Message, "Error Real", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarRespuestasDelUsuario()
        {
            string usuario = txtUsuario.Text.Trim();
            int respuestasContestadas = 0;

            foreach (Control control in flowPreguntas.Controls)
            {
                if (control is TextBox txt)
                {
                    respuestasContestadas++;
                    int idPregunta = Convert.ToInt32(txt.Tag);
                    string respuestaPlana = txt.Text.Trim();
                    string respuestaHash = HashSHA256(respuestaPlana);

                    if (!DatosSeguridad.ValidarRespuestaSeguridad(usuario, idPregunta, respuestaHash))
                    {
                        return false;
                    }
                }
            }

            return respuestasContestadas > 0;
        }

        private string GenerarClaveAleatoria()
        {
            string mayus = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string minus = "abcdefghijklmnopqrstuvwxyz";
            string nums = "0123456789";
            string esp = "@!$";

            Random rnd = new Random();
            string clave = "";

            clave += mayus[rnd.Next(mayus.Length)];
            clave += minus[rnd.Next(minus.Length)];
            clave += nums[rnd.Next(nums.Length)];
            clave += esp[rnd.Next(esp.Length)];

            string todos = mayus + minus + nums + esp;
            for (int i = 0; i < 4; i++)
            {
                clave += todos[rnd.Next(todos.Length)];
            }

            return new string(clave.OrderBy(x => rnd.Next()).ToArray());
        }

        private string HashSHA256(string texto)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(texto));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes) builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
        }

        private void flowPreguntas_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Close();
        }
    }
}