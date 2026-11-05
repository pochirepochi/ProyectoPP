namespace Proyecto_PP
{
    partial class FrmAjustesVenta
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
            cmbClientes = new ComboBox();
            label1 = new Label();
            txtMotivo = new TextBox();
            txtMonto = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            rbCredito = new RadioButton();
            rbDebito = new RadioButton();
            btnEmitir = new Button();
            btnVolver = new Button();
            groupBox1 = new GroupBox();
            cmbFactura = new ComboBox();
            groupBox2 = new GroupBox();
            btnLimpiar = new Button();
            groupBox3 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // cmbClientes
            // 
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(158, 64);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(264, 23);
            cmbClientes.TabIndex = 0;
            cmbClientes.SelectedIndexChanged += cmbClientes_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(158, 46);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 1;
            label1.Text = "Clientes:";
            // 
            // txtMotivo
            // 
            txtMotivo.Location = new Point(158, 226);
            txtMotivo.Multiline = true;
            txtMotivo.Name = "txtMotivo";
            txtMotivo.Size = new Size(264, 23);
            txtMotivo.TabIndex = 3;
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(291, 152);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(300, 23);
            txtMonto.TabIndex = 2;
            txtMonto.TextChanged += txtMonto_TextChanged;
            txtMonto.KeyPress += txtMonto_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(158, 208);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 100;
            label2.Text = "Motivo:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(291, 134);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 6;
            label3.Text = "Monto:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 134);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 7;
            label4.Text = "Factura:";
            // 
            // rbCredito
            // 
            rbCredito.AutoSize = true;
            rbCredito.Location = new Point(103, 96);
            rbCredito.Name = "rbCredito";
            rbCredito.Size = new Size(176, 19);
            rbCredito.TabIndex = 4;
            rbCredito.TabStop = true;
            rbCredito.Text = "Nota de Crédito (Descuento)";
            rbCredito.UseVisualStyleBackColor = true;
            // 
            // rbDebito
            // 
            rbDebito.AutoSize = true;
            rbDebito.Location = new Point(302, 96);
            rbDebito.Name = "rbDebito";
            rbDebito.Size = new Size(159, 19);
            rbDebito.TabIndex = 5;
            rbDebito.TabStop = true;
            rbDebito.Text = "Nota de Débito (Recargo)";
            rbDebito.UseVisualStyleBackColor = true;
            // 
            // btnEmitir
            // 
            btnEmitir.BackColor = Color.SpringGreen;
            btnEmitir.Location = new Point(266, 64);
            btnEmitir.Name = "btnEmitir";
            btnEmitir.Size = new Size(213, 69);
            btnEmitir.TabIndex = 6;
            btnEmitir.Text = "Emitir Ajuste";
            btnEmitir.UseVisualStyleBackColor = false;
            btnEmitir.Click += btnEmitir_Click_1;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.Red;
            btnVolver.Location = new Point(266, 404);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(213, 69);
            btnVolver.TabIndex = 7;
            btnVolver.Text = "VOLVER\r\npantalla principal";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmbFactura);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cmbClientes);
            groupBox1.Controls.Add(txtMotivo);
            groupBox1.Controls.Add(txtMonto);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(67, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(597, 290);
            groupBox1.TabIndex = 101;
            groupBox1.TabStop = false;
            groupBox1.Text = "Detalles del Ajuste";
            // 
            // cmbFactura
            // 
            cmbFactura.FormattingEnabled = true;
            cmbFactura.Location = new Point(6, 152);
            cmbFactura.Name = "cmbFactura";
            cmbFactura.Size = new Size(273, 23);
            cmbFactura.TabIndex = 103;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rbCredito);
            groupBox2.Controls.Add(rbDebito);
            groupBox2.Location = new Point(67, 308);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(597, 223);
            groupBox2.TabIndex = 102;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tipo de Comprobante";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.Orange;
            btnLimpiar.Location = new Point(266, 226);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(213, 69);
            btnLimpiar.TabIndex = 103;
            btnLimpiar.Text = "Limpiar Campos";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnLimpiar);
            groupBox3.Controls.Add(btnEmitir);
            groupBox3.Controls.Add(btnVolver);
            groupBox3.Location = new Point(670, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(712, 519);
            groupBox3.TabIndex = 104;
            groupBox3.TabStop = false;
            groupBox3.Text = "Acciones";
            // 
            // FrmAjustesVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1394, 546);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            MinimumSize = new Size(1410, 585);
            Name = "FrmAjustesVenta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmAjustesVenta";
            Load += FrmAjustesVenta_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbClientes;
        private Label label1;
        private TextBox txtMotivo;
        private TextBox txtMonto;
        private Label label2;
        private Label label3;
        private Label label4;
        private RadioButton rbCredito;
        private RadioButton rbDebito;
        private Button btnEmitir;
        private Button btnVolver;
        private GroupBox groupBox1;
        private ComboBox cmbFactura;
        private GroupBox groupBox2;
        private Button btnLimpiar;
        private GroupBox groupBox3;
    }
}