using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System;
using System.Windows.Forms;

namespace Proyecto_PP
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FrmClientes pantallaClientes = new FrmClientes();
            pantallaClientes.ShowDialog();
        }

        private void btnAjustes_Click(object sender, EventArgs e)
        {
            FrmAjustesVenta pantallaAjustes = new FrmAjustesVenta();
            pantallaAjustes.ShowDialog();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            FrmReportes pantallaReportes = new FrmReportes();
            pantallaReportes.ShowDialog();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}

