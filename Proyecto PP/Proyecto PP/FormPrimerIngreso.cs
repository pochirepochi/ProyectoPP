using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Capa_Entidades;
using Capa_Logica;
using Capa_Datos;

namespace Proyecto_PP
{
    public partial class FormPrimerIngreso : Form
    {
        private int idUsuarioActual;

        private readonly byte[] ClaveAES = Encoding.UTF8.GetBytes("ClaveSecretaProyectoPP1234567890");
        private readonly byte[] VectorAES = Encoding.UTF8.GetBytes("VectorInicio1234");

        public FormPrimerIngreso(int idUsuario)
        {
            InitializeComponent();
            this.idUsuarioActual = idUsuario;
        }

        private void CargarLabels()
        {
            DataTable dtPreguntas = DatosSeguridad.TraerPreguntas();

            if (dtPreguntas.Rows.Count < 5)
            {
                MessageBox.Show("Faltan cargar preguntas en el catálogo de la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<DataRow> listaFilas = new List<DataRow>();
            foreach (DataRow fila in dtPreguntas.Rows)
            {
                listaFilas.Add(fila);
            }

            Random random = new Random();
            var cincoPreguntasRandom = listaFilas.OrderBy(x => random.Next()).Take(5).ToList();

            Label[] labels = { lblPregunta1, lblPregunta2, lblPregunta3, lblPregunta4, lblPregunta5 };

            for (int i = 0; i < 5; i++)
            {
                labels[i].Text = cincoPreguntasRandom[i]["pregunta"].ToString();
                labels[i].Tag = Convert.ToInt32(cincoPreguntasRandom[i]["id_catalogo"]);
            }
        }

        private void FormPrimerIngreso_Load(object sender, EventArgs e)
        {
            CargarLabels();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            TextBox[] respuestas = { txtRespuesta1, txtRespuesta2, txtRespuesta3, txtRespuesta4, txtRespuesta5 };
            Label[] labels = { lblPregunta1, lblPregunta2, lblPregunta3, lblPregunta4, lblPregunta5 };

            foreach (var txt in respuestas)
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    MessageBox.Show("Por favor, completa todas las respuestas antes de guardar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt.Focus();
                    return;
                }
            }

            try
            {
                for (int i = 0; i < 5; i++)
                {
                    int idPreguntaAsignada = Convert.ToInt32(labels[i].Tag);
                    string respuestaEncriptada = EncriptarAES(respuestas[i].Text);

                    DatosSeguridad.GuardarRespuesta(this.idUsuarioActual, idPreguntaAsignada, respuestaEncriptada);
                }

                MessageBox.Show("¡Preguntas y respuestas guardadas con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar guardar: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(textoPlano);
                        }
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }
    }
}