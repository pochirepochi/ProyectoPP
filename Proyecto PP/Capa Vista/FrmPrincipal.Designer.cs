namespace CapaVista
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnClientes = new Button();
            btnAjustes = new Button();
            btnReportes = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Impact", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(1343, 113);
            label1.TabIndex = 0;
            label1.Text = "Grupo 6 — Clientes y Ajustes de Venta";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnClientes
            // 
            btnClientes.Font = new Font("Georgia", 20.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnClientes.Location = new Point(12, 182);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(444, 225);
            btnClientes.TabIndex = 1;
            btnClientes.Text = "Gestión de Clientes";
            btnClientes.UseVisualStyleBackColor = true;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnAjustes
            // 
            btnAjustes.Font = new Font("Georgia", 20.25F, FontStyle.Italic);
            btnAjustes.Location = new Point(462, 182);
            btnAjustes.Name = "btnAjustes";
            btnAjustes.Size = new Size(444, 225);
            btnAjustes.TabIndex = 2;
            btnAjustes.Text = "Ajustes de Venta ";
            btnAjustes.UseVisualStyleBackColor = true;
            btnAjustes.Click += btnAjustes_Click;
            // 
            // btnReportes
            // 
            btnReportes.Font = new Font("Georgia", 20.25F, FontStyle.Italic);
            btnReportes.Location = new Point(912, 182);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(443, 225);
            btnReportes.TabIndex = 3;
            btnReportes.Text = "Consultas y Reportes";
            btnReportes.UseVisualStyleBackColor = true;
            btnReportes.Click += btnReportes_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1367, 590);
            Controls.Add(btnReportes);
            Controls.Add(btnAjustes);
            Controls.Add(btnClientes);
            Controls.Add(label1);
            MinimumSize = new Size(1383, 629);
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmPrincipal";
            Load += FrmPrincipal_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button btnClientes;
        private Button btnAjustes;
        private Button btnReportes;
    }
}