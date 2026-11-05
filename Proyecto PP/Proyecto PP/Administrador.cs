using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Capa_Entidades;
using Capa_Logica;
using Capa_Datos;

namespace Proyecto_PP
{
    public partial class Administrador : Form
    {
        public Administrador()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Administrador_Load_1);
        }

        private void Administrador_Load_1(object sender, EventArgs e)
        {
            CargarUsuariosEnGrilla();
        }

        public void CargarUsuariosEnGrilla()
        {
            using (SqlConnection con = ConexionDB.ObtenerConexion())
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ListarUsuariosActivos", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvUsuarios.DataSource = dt;
                        RenombrarColumnas();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la grilla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RenombrarColumnas()
        {
            if (dgvUsuarios.Columns["Id_Usuario"] != null)
                dgvUsuarios.Columns["Id_Usuario"].HeaderText = "ID";

            if (dgvUsuarios.Columns["Nombre_Usuario"] != null)
                dgvUsuarios.Columns["Nombre_Usuario"].HeaderText = "Usuario";

            if (dgvUsuarios.Columns["Nombre"] != null)
                dgvUsuarios.Columns["Nombre"].HeaderText = "Nombre";

            if (dgvUsuarios.Columns["Apellido"] != null)
                dgvUsuarios.Columns["Apellido"].HeaderText = "Apellido";

            if (dgvUsuarios.Columns["Email"] != null)
                dgvUsuarios.Columns["Email"].HeaderText = "Correo Electrónico";

            if (dgvUsuarios.Columns["Nombre_Rol"] != null)
                dgvUsuarios.Columns["Nombre_Rol"].HeaderText = "Rol";
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            Registro pantallaRegistro = new Registro();
            pantallaRegistro.ShowDialog();
            CargarUsuariosEnGrilla();
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null)
            {

                int idUsuario = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells[0].Value);

                ModificarUser pantallaEditar = new ModificarUser(idUsuario);
                pantallaEditar.ShowDialog();

                CargarUsuariosEnGrilla();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un usuario de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null)
            {
                int idUsuario = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells[0].Value);

                string nombre = dgvUsuarios.CurrentRow.Cells[1].Value.ToString();

                DialogResult respuesta = MessageBox.Show($"¿Estás seguro de que deseas dar de baja a {nombre}?",
                    "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    using (SqlConnection con = ConexionDB.ObtenerConexion())
                    {
                        try
                        {
                            con.Open();
                            using (SqlCommand cmd = new SqlCommand("sp_BajaUsuario", con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;


                                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                                cmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Usuario desactivado con éxito del sistema.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarUsuariosEnGrilla();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al intentar eliminar: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un usuario de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Close();
        }

        private void btnPantallaprin_Click(object sender, EventArgs e)
        {
            FrmPrincipal pantallaPrincipal = new FrmPrincipal();
            pantallaPrincipal.Show();
        }
    }
}