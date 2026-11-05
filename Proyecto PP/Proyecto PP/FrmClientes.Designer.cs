namespace Proyecto_PP
{
    partial class FrmClientes
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClientes));
            dgvClientes = new DataGridView();
            btnGuardar = new Button();
            label1 = new Label();
            btnBaja = new Button();
            btnModificar = new Button();
            btnVolver = new Button();
            rbInactivos = new RadioButton();
            txtBuscar = new TextBox();
            rbActivos = new RadioButton();
            btnReactivar = new Button();
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            rbTodos = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.AllowUserToResizeRows = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(12, 97);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.Size = new Size(908, 336);
            dgvClientes.TabIndex = 15;
            dgvClientes.CellContentClick += dgvClientes_CellContentClick;
            dgvClientes.CellDoubleClick += dgvClientes_CellDoubleClick;
            dgvClientes.RowEnter += dgvClientes_RowEnter;
            dgvClientes.KeyDown += dgvClientes_KeyDown;
            dgvClientes.MouseDown += dgvClientes_MouseDown;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.LightGreen;
            btnGuardar.Location = new Point(134, 48);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(146, 68);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "ALTA CLIENTE";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 79);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 8;
            label1.Text = "Clientes:";
            // 
            // btnBaja
            // 
            btnBaja.BackColor = Color.Red;
            btnBaja.Location = new Point(134, 341);
            btnBaja.Name = "btnBaja";
            btnBaja.Size = new Size(146, 68);
            btnBaja.TabIndex = 7;
            btnBaja.Text = "BORRAR CLIENTE";
            btnBaja.UseVisualStyleBackColor = false;
            btnBaja.Click += btnBaja_Click;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.Yellow;
            btnModificar.Location = new Point(134, 197);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(146, 68);
            btnModificar.TabIndex = 6;
            btnModificar.Text = "MODIFICAR CLIENTE";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.Tan;
            btnVolver.Location = new Point(134, 479);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(146, 68);
            btnVolver.TabIndex = 9;
            btnVolver.Text = "VOLVER\r\npantalla principal";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // rbInactivos
            // 
            rbInactivos.AutoSize = true;
            rbInactivos.Location = new Point(782, 72);
            rbInactivos.Name = "rbInactivos";
            rbInactivos.Size = new Size(138, 19);
            rbInactivos.TabIndex = 16;
            rbInactivos.TabStop = true;
            rbInactivos.Text = "Clientes desactivados";
            rbInactivos.UseVisualStyleBackColor = true;
            rbInactivos.CheckedChanged += rbInactivos_CheckedChanged;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(267, 24);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(416, 23);
            txtBuscar.TabIndex = 18;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // rbActivos
            // 
            rbActivos.AutoSize = true;
            rbActivos.Location = new Point(667, 72);
            rbActivos.Name = "rbActivos";
            rbActivos.Size = new Size(109, 19);
            rbActivos.TabIndex = 20;
            rbActivos.TabStop = true;
            rbActivos.Text = "Clientes Activos";
            rbActivos.UseVisualStyleBackColor = true;
            rbActivos.CheckedChanged += rbActivos_CheckedChanged;
            // 
            // btnReactivar
            // 
            btnReactivar.BackColor = Color.DodgerBlue;
            btnReactivar.Location = new Point(134, 341);
            btnReactivar.Name = "btnReactivar";
            btnReactivar.Size = new Size(146, 68);
            btnReactivar.TabIndex = 21;
            btnReactivar.Text = "REACTIVAR CLIENTE";
            btnReactivar.UseVisualStyleBackColor = false;
            btnReactivar.Click += btnReactivar_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(235, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(26, 23);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnGuardar);
            groupBox1.Controls.Add(btnBaja);
            groupBox1.Controls.Add(btnReactivar);
            groupBox1.Controls.Add(btnModificar);
            groupBox1.Controls.Add(btnVolver);
            groupBox1.Location = new Point(926, 24);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(399, 553);
            groupBox1.TabIndex = 23;
            groupBox1.TabStop = false;
            groupBox1.Text = "Acciones";
            // 
            // rbTodos
            // 
            rbTodos.AutoSize = true;
            rbTodos.Location = new Point(542, 72);
            rbTodos.Name = "rbTodos";
            rbTodos.Size = new Size(119, 19);
            rbTodos.TabIndex = 24;
            rbTodos.TabStop = true;
            rbTodos.Text = "Todos los Clientes";
            rbTodos.UseVisualStyleBackColor = true;
            rbTodos.CheckedChanged += rbTodos_CheckedChanged;
            // 
            // FrmClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1354, 584);
            Controls.Add(rbTodos);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            Controls.Add(rbActivos);
            Controls.Add(txtBuscar);
            Controls.Add(rbInactivos);
            Controls.Add(label1);
            Controls.Add(dgvClientes);
            MinimumSize = new Size(1370, 623);
            Name = "FrmClientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += FrmClientes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvClientes;
        private Button btnGuardar;
        private Label label1;
        private Button btnBaja;
        private Button btnModificar;
        private Button btnVolver;
        private RadioButton rbInactivos;
        private TextBox txtBuscar;
        private RadioButton rbActivos;
        private Button btnReactivar;
        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private RadioButton rbTodos;
    }
}
