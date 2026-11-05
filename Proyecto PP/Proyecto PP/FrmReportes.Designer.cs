namespace Proyecto_PP   
{
    partial class FrmReportes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportes));
            dgvReportes = new DataGridView();
            btnAlertas = new Button();
            btnNotas = new Button();
            btnVolver = new Button();
            txtBuscar = new TextBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            groupBox6 = new GroupBox();
            label5 = new Label();
            label4 = new Label();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            groupBox5 = new GroupBox();
            label3 = new Label();
            txtMontoMax = new TextBox();
            label2 = new Label();
            txtMontoMin = new TextBox();
            groupBox3 = new GroupBox();
            chkDesactivo = new CheckBox();
            chkActivo = new CheckBox();
            groupBox2 = new GroupBox();
            chkMontoMenorAMayor = new CheckBox();
            chkMontoMayorAMenor = new CheckBox();
            groupBox4 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvReportes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // dgvReportes
            // 
            dgvReportes.AllowUserToAddRows = false;
            dgvReportes.AllowUserToDeleteRows = false;
            dgvReportes.AllowUserToResizeRows = false;
            dgvReportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReportes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReportes.Location = new Point(146, 71);
            dgvReportes.Name = "dgvReportes";
            dgvReportes.ReadOnly = true;
            dgvReportes.Size = new Size(790, 392);
            dgvReportes.TabIndex = 0;
            dgvReportes.CellContentClick += dgvReportes_CellContentClick;
            dgvReportes.MouseDown += dgvReportes_MouseDown;
            // 
            // btnAlertas
            // 
            btnAlertas.Location = new Point(702, 469);
            btnAlertas.Name = "btnAlertas";
            btnAlertas.Size = new Size(234, 59);
            btnAlertas.TabIndex = 0;
            btnAlertas.Text = "Ver Alertas de Crédito";
            btnAlertas.UseVisualStyleBackColor = true;
            btnAlertas.Click += btnAlertas_Click;
            // 
            // btnNotas
            // 
            btnNotas.Location = new Point(146, 469);
            btnNotas.Name = "btnNotas";
            btnNotas.Size = new Size(234, 59);
            btnNotas.TabIndex = 1;
            btnNotas.Text = "Ver Historial de Notas";
            btnNotas.UseVisualStyleBackColor = true;
            btnNotas.Click += btnNotas_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(12, 536);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(120, 45);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "VOLVER\r\npantalla principal";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(280, 42);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(498, 23);
            txtBuscar.TabIndex = 4;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(248, 42);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(26, 23);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 23;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(280, 24);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 24;
            label1.Text = "Razon Social";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox6);
            groupBox1.Controls.Add(groupBox5);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Location = new Point(942, 71);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(457, 280);
            groupBox1.TabIndex = 25;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtros";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(label5);
            groupBox6.Controls.Add(label4);
            groupBox6.Controls.Add(dateTimePicker2);
            groupBox6.Controls.Add(dateTimePicker1);
            groupBox6.Location = new Point(6, 189);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(445, 85);
            groupBox6.TabIndex = 3;
            groupBox6.TabStop = false;
            groupBox6.Text = "Fecha";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(239, 29);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 3;
            label5.Text = "Hasta:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 29);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 2;
            label4.Text = "Desde:";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(239, 47);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 1;
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(6, 47);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 0;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(label3);
            groupBox5.Controls.Add(txtMontoMax);
            groupBox5.Controls.Add(label2);
            groupBox5.Controls.Add(txtMontoMin);
            groupBox5.Location = new Point(6, 102);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(445, 85);
            groupBox5.TabIndex = 2;
            groupBox5.TabStop = false;
            groupBox5.Text = "Monto";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(252, 38);
            label3.Name = "label3";
            label3.Size = new Size(93, 15);
            label3.TabIndex = 3;
            label3.Text = "Monto Maximo:";
            // 
            // txtMontoMax
            // 
            txtMontoMax.Location = new Point(252, 56);
            txtMontoMax.Name = "txtMontoMax";
            txtMontoMax.Size = new Size(187, 23);
            txtMontoMax.TabIndex = 2;
            txtMontoMax.TextChanged += txtMontoMax_TextChanged;
            txtMontoMax.KeyPress += txtNumerosDecimales_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 38);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 1;
            label2.Text = "Monto Minimo:";
            // 
            // txtMontoMin
            // 
            txtMontoMin.Location = new Point(6, 56);
            txtMontoMin.Name = "txtMontoMin";
            txtMontoMin.Size = new Size(187, 23);
            txtMontoMin.TabIndex = 0;
            txtMontoMin.TextChanged += txtMontoMin_TextChanged;
            txtMontoMin.KeyPress += txtNumerosDecimales_KeyPress;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(chkDesactivo);
            groupBox3.Controls.Add(chkActivo);
            groupBox3.Location = new Point(6, 22);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(445, 74);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "Estado";
            groupBox3.Enter += groupBox3_Enter;
            // 
            // chkDesactivo
            // 
            chkDesactivo.AutoSize = true;
            chkDesactivo.Location = new Point(311, 36);
            chkDesactivo.Name = "chkDesactivo";
            chkDesactivo.Size = new Size(77, 19);
            chkDesactivo.TabIndex = 2;
            chkDesactivo.Text = "Desactivo";
            chkDesactivo.UseVisualStyleBackColor = true;
            chkDesactivo.CheckedChanged += chkDesactivo_CheckedChanged;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(25, 36);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(60, 19);
            chkActivo.TabIndex = 1;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            chkActivo.CheckedChanged += chkActivo_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(chkMontoMenorAMayor);
            groupBox2.Controls.Add(chkMontoMayorAMenor);
            groupBox2.Location = new Point(6, 41);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(445, 100);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Montos";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // chkMontoMenorAMayor
            // 
            chkMontoMenorAMayor.AutoSize = true;
            chkMontoMenorAMayor.Location = new Point(311, 46);
            chkMontoMenorAMayor.Name = "chkMontoMenorAMayor";
            chkMontoMenorAMayor.Size = new Size(107, 19);
            chkMontoMenorAMayor.TabIndex = 1;
            chkMontoMenorAMayor.Text = "Menor a Mayor";
            chkMontoMenorAMayor.UseVisualStyleBackColor = true;
            chkMontoMenorAMayor.CheckedChanged += chkMontoMenorAMayor_CheckedChanged;
            // 
            // chkMontoMayorAMenor
            // 
            chkMontoMayorAMenor.AutoSize = true;
            chkMontoMayorAMenor.Location = new Point(25, 46);
            chkMontoMayorAMenor.Name = "chkMontoMayorAMenor";
            chkMontoMayorAMenor.Size = new Size(107, 19);
            chkMontoMayorAMenor.TabIndex = 0;
            chkMontoMayorAMenor.Text = "Mayor a menor";
            chkMontoMayorAMenor.UseVisualStyleBackColor = true;
            chkMontoMayorAMenor.CheckedChanged += chkMontoMayorAMenor_CheckedChanged;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(groupBox2);
            groupBox4.Location = new Point(942, 357);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(457, 171);
            groupBox4.TabIndex = 26;
            groupBox4.TabStop = false;
            groupBox4.Text = "Orden";
            // 
            // FrmReportes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1411, 593);
            Controls.Add(groupBox4);
            Controls.Add(groupBox1);
            Controls.Add(btnNotas);
            Controls.Add(btnAlertas);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(txtBuscar);
            Controls.Add(btnVolver);
            Controls.Add(dgvReportes);
            MinimumSize = new Size(1427, 632);
            Name = "FrmReportes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmReportes";
            Load += FrmReportes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReportes).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox4.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvReportes;
        private Button btnAlertas;
        private Button btnNotas;
        private Button btnVolver;
        private TextBox txtBuscar;
        private PictureBox pictureBox1;
        private Label label1;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private CheckBox chkDesactivo;
        private CheckBox chkActivo;
        private GroupBox groupBox2;
        private CheckBox chkMontoMenorAMayor;
        private CheckBox chkMontoMayorAMenor;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private Label label3;
        private TextBox txtMontoMax;
        private Label label2;
        private TextBox txtMontoMin;
        private Label label5;
        private Label label4;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
    }
}