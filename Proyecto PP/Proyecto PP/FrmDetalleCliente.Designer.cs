namespace Proyecto_PP
{
    partial class FrmDetalleCliente
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
            txtRazonSocial = new TextBox();
            txtLimite = new TextBox();
            txtCuit = new TextBox();
            txtDescuento = new TextBox();
            btnModificar = new Button();
            btnGuardar = new Button();
            btnDescartar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtContacto = new TextBox();
            txtNombreContacto = new TextBox();
            label7 = new Label();
            label9 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            btnDesactivar = new Button();
            btnActivar = new Button();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            groupBox5 = new GroupBox();
            cmbPartido = new ComboBox();
            label11 = new Label();
            cmbLocalidad = new ComboBox();
            label10 = new Label();
            cmbProvincia = new ComboBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // txtRazonSocial
            // 
            txtRazonSocial.Location = new Point(6, 53);
            txtRazonSocial.Name = "txtRazonSocial";
            txtRazonSocial.Size = new Size(175, 23);
            txtRazonSocial.TabIndex = 0;
            // 
            // txtLimite
            // 
            txtLimite.Location = new Point(6, 45);
            txtLimite.Name = "txtLimite";
            txtLimite.Size = new Size(175, 23);
            txtLimite.TabIndex = 1;
            txtLimite.KeyPress += txtNumerosDecimales_KeyPress;
            // 
            // txtCuit
            // 
            txtCuit.Location = new Point(391, 53);
            txtCuit.Name = "txtCuit";
            txtCuit.Size = new Size(186, 23);
            txtCuit.TabIndex = 2;
            txtCuit.KeyPress += txtSoloNumeros_KeyPress;
            // 
            // txtDescuento
            // 
            txtDescuento.Location = new Point(391, 45);
            txtDescuento.Name = "txtDescuento";
            txtDescuento.Size = new Size(175, 23);
            txtDescuento.TabIndex = 3;
            txtDescuento.KeyPress += txtNumerosDecimales_KeyPress;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.Yellow;
            btnModificar.Location = new Point(406, 66);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(123, 51);
            btnModificar.TabIndex = 5;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(128, 255, 128);
            btnGuardar.Location = new Point(96, 66);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(123, 51);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnDescartar
            // 
            btnDescartar.BackColor = Color.Red;
            btnDescartar.Location = new Point(692, 66);
            btnDescartar.Name = "btnDescartar";
            btnDescartar.Size = new Size(123, 51);
            btnDescartar.TabIndex = 7;
            btnDescartar.Text = "Descartar Cambios";
            btnDescartar.UseVisualStyleBackColor = false;
            btnDescartar.Click += btnDescartar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 35);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 8;
            label1.Text = "Razon Social:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(391, 35);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 9;
            label2.Text = "CUIT/DNI";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 27);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 10;
            label3.Text = "Limite:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(391, 27);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 11;
            label4.Text = "Descuento:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 28);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 12;
            label5.Text = "Telefono:";
            // 
            // txtContacto
            // 
            txtContacto.Location = new Point(6, 46);
            txtContacto.MaxLength = 12;
            txtContacto.Name = "txtContacto";
            txtContacto.Size = new Size(186, 23);
            txtContacto.TabIndex = 13;
            txtContacto.KeyPress += txtSoloNumeros_KeyPress;
            // 
            // txtNombreContacto
            // 
            txtNombreContacto.Location = new Point(391, 46);
            txtNombreContacto.Name = "txtNombreContacto";
            txtNombreContacto.Size = new Size(186, 23);
            txtNombreContacto.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(391, 28);
            label7.Name = "label7";
            label7.Size = new Size(125, 15);
            label7.TabIndex = 16;
            label7.Text = "Nombre del Contacto:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 246);
            label9.Name = "label9";
            label9.Size = new Size(61, 15);
            label9.TabIndex = 21;
            label9.Text = "Localidad:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtRazonSocial);
            groupBox1.Controls.Add(txtCuit);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(583, 102);
            groupBox1.TabIndex = 22;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos Personales";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnDesactivar);
            groupBox2.Controls.Add(btnActivar);
            groupBox2.Controls.Add(btnDescartar);
            groupBox2.Controls.Add(btnModificar);
            groupBox2.Controls.Add(btnGuardar);
            groupBox2.Location = new Point(12, 334);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(927, 176);
            groupBox2.TabIndex = 23;
            groupBox2.TabStop = false;
            groupBox2.Text = "Acciones";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // btnDesactivar
            // 
            btnDesactivar.BackColor = Color.Red;
            btnDesactivar.Location = new Point(406, 66);
            btnDesactivar.Name = "btnDesactivar";
            btnDesactivar.Size = new Size(123, 51);
            btnDesactivar.TabIndex = 9;
            btnDesactivar.Text = "Desactivar Cliente";
            btnDesactivar.UseVisualStyleBackColor = false;
            btnDesactivar.Click += btnDesactivar_Click;
            // 
            // btnActivar
            // 
            btnActivar.BackColor = Color.FromArgb(128, 255, 128);
            btnActivar.Location = new Point(406, 66);
            btnActivar.Name = "btnActivar";
            btnActivar.Size = new Size(123, 51);
            btnActivar.TabIndex = 8;
            btnActivar.Text = "Activar Cliente";
            btnActivar.UseVisualStyleBackColor = false;
            btnActivar.Click += btnActivar_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtContacto);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(txtNombreContacto);
            groupBox3.Controls.Add(label7);
            groupBox3.Location = new Point(12, 120);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(583, 105);
            groupBox3.TabIndex = 24;
            groupBox3.TabStop = false;
            groupBox3.Text = "Datos de Contacto";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(txtLimite);
            groupBox4.Controls.Add(label3);
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(txtDescuento);
            groupBox4.Location = new Point(12, 231);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(583, 97);
            groupBox4.TabIndex = 25;
            groupBox4.TabStop = false;
            groupBox4.Text = "Configuracion de venta";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(cmbPartido);
            groupBox5.Controls.Add(label11);
            groupBox5.Controls.Add(cmbLocalidad);
            groupBox5.Controls.Add(label10);
            groupBox5.Controls.Add(label9);
            groupBox5.Controls.Add(cmbProvincia);
            groupBox5.Location = new Point(601, 12);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(338, 316);
            groupBox5.TabIndex = 26;
            groupBox5.TabStop = false;
            groupBox5.Text = "Datos de Direccion";
            // 
            // cmbPartido
            // 
            cmbPartido.FormattingEnabled = true;
            cmbPartido.Location = new Point(6, 154);
            cmbPartido.Name = "cmbPartido";
            cmbPartido.Size = new Size(309, 23);
            cmbPartido.TabIndex = 22;
            cmbPartido.SelectedIndexChanged += cmbPartido_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(6, 136);
            label11.Name = "label11";
            label11.Size = new Size(48, 15);
            label11.TabIndex = 3;
            label11.Text = "Partido:";
            // 
            // cmbLocalidad
            // 
            cmbLocalidad.FormattingEnabled = true;
            cmbLocalidad.Location = new Point(6, 264);
            cmbLocalidad.Name = "cmbLocalidad";
            cmbLocalidad.Size = new Size(309, 23);
            cmbLocalidad.TabIndex = 2;
            cmbLocalidad.SelectedIndexChanged += cmbLocalidad_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 35);
            label10.Name = "label10";
            label10.Size = new Size(56, 15);
            label10.TabIndex = 1;
            label10.Text = "Provincia";
            // 
            // cmbProvincia
            // 
            cmbProvincia.FormattingEnabled = true;
            cmbProvincia.Location = new Point(6, 53);
            cmbProvincia.Name = "cmbProvincia";
            cmbProvincia.Size = new Size(309, 23);
            cmbProvincia.TabIndex = 0;
            cmbProvincia.SelectedIndexChanged += cmbProvincia_SelectedIndexChanged;
            // 
            // FrmDetalleCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(951, 521);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox2);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            MinimumSize = new Size(967, 560);
            Name = "FrmDetalleCliente";
            Load += FrmDetalleCliente_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtRazonSocial;
        private TextBox txtLimite;
        private TextBox txtCuit;
        private TextBox txtDescuento;
        private Button btnModificar;
        private Button btnGuardar;
        private Button btnDescartar;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtContacto;
        private TextBox txtNombreContacto;
        private Label label7;
        private Label label9;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private ComboBox cmbPartido;
        private Label label11;
        private ComboBox cmbLocalidad;
        private Label label10;
        private ComboBox cmbProvincia;
        private Button btnDesactivar;
        private Button btnActivar;
    }
}