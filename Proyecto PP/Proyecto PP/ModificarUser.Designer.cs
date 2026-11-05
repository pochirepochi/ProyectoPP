namespace Proyecto_PP
{
    partial class ModificarUser
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
            txtUsuario = new TextBox();
            txtEmail = new TextBox();
            btnGuardar = new Button();
            label1 = new Label();
            label2 = new Label();
            cmbRoles = new ComboBox();
            label3 = new Label();
            btnVolver = new Button();
            flpPreguntas = new FlowLayoutPanel();
            grpAdmin = new GroupBox();
            txtConfirmarContra = new TextBox();
            label5 = new Label();
            label4 = new Label();
            txtNuevaContra = new TextBox();
            chkHabilitarCambio = new CheckBox();
            grpAdmin.SuspendLayout();
            SuspendLayout();
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(289, 80);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(168, 23);
            txtUsuario.TabIndex = 0;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(289, 160);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(168, 23);
            txtEmail.TabIndex = 1;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(289, 283);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(289, 62);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 3;
            label1.Text = "Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(289, 142);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 4;
            label2.Text = "Email";
            // 
            // cmbRoles
            // 
            cmbRoles.FormattingEnabled = true;
            cmbRoles.Location = new Point(289, 231);
            cmbRoles.Name = "cmbRoles";
            cmbRoles.Size = new Size(168, 23);
            cmbRoles.TabIndex = 2;
            cmbRoles.SelectedIndexChanged += cmbRoles_SelectedIndexChanged_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(289, 213);
            label3.Name = "label3";
            label3.Size = new Size(24, 15);
            label3.TabIndex = 6;
            label3.Text = "Rol";
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(382, 283);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 4;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // flpPreguntas
            // 
            flpPreguntas.AutoSize = true;
            flpPreguntas.FlowDirection = FlowDirection.TopDown;
            flpPreguntas.Location = new Point(463, 88);
            flpPreguntas.Name = "flpPreguntas";
            flpPreguntas.Size = new Size(200, 100);
            flpPreguntas.TabIndex = 7;
            flpPreguntas.Visible = false;
            flpPreguntas.Paint += flpPreguntas_Paint;
            // 
            // grpAdmin
            // 
            grpAdmin.Controls.Add(txtConfirmarContra);
            grpAdmin.Controls.Add(label5);
            grpAdmin.Controls.Add(label4);
            grpAdmin.Controls.Add(txtNuevaContra);
            grpAdmin.Location = new Point(12, 80);
            grpAdmin.Name = "grpAdmin";
            grpAdmin.Size = new Size(271, 148);
            grpAdmin.TabIndex = 8;
            grpAdmin.TabStop = false;
            grpAdmin.Text = "Admin";
            grpAdmin.Visible = false;
            // 
            // txtConfirmarContra
            // 
            txtConfirmarContra.Location = new Point(6, 85);
            txtConfirmarContra.Name = "txtConfirmarContra";
            txtConfirmarContra.Size = new Size(173, 23);
            txtConfirmarContra.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 67);
            label5.Name = "label5";
            label5.Size = new Size(129, 15);
            label5.TabIndex = 11;
            label5.Text = "Confirmar nueva clave:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 23);
            label4.Name = "label4";
            label4.Size = new Size(74, 15);
            label4.TabIndex = 10;
            label4.Text = "Nueva clave:";
            // 
            // txtNuevaContra
            // 
            txtNuevaContra.Location = new Point(6, 41);
            txtNuevaContra.Name = "txtNuevaContra";
            txtNuevaContra.Size = new Size(173, 23);
            txtNuevaContra.TabIndex = 9;
            // 
            // chkHabilitarCambio
            // 
            chkHabilitarCambio.AutoSize = true;
            chkHabilitarCambio.Location = new Point(12, 55);
            chkHabilitarCambio.Name = "chkHabilitarCambio";
            chkHabilitarCambio.Size = new Size(106, 19);
            chkHabilitarCambio.TabIndex = 9;
            chkHabilitarCambio.Text = "Cambiar clave?";
            chkHabilitarCambio.UseVisualStyleBackColor = true;
            chkHabilitarCambio.Visible = false;
            chkHabilitarCambio.CheckedChanged += chkHabilitarCambio_CheckedChanged;
            // 
            // ModificarUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(chkHabilitarCambio);
            Controls.Add(grpAdmin);
            Controls.Add(flpPreguntas);
            Controls.Add(btnVolver);
            Controls.Add(label3);
            Controls.Add(cmbRoles);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnGuardar);
            Controls.Add(txtEmail);
            Controls.Add(txtUsuario);
            MinimumSize = new Size(816, 489);
            Name = "ModificarUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ModificarUser";
            Load += ModificarUser_Load;
            grpAdmin.ResumeLayout(false);
            grpAdmin.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsuario;
        private TextBox txtEmail;
        private Button btnGuardar;
        private Label label1;
        private Label label2;
        private ComboBox cmbRoles;
        private Label label3;
        private Button btnVolver;
        private FlowLayoutPanel flpPreguntas;
        private GroupBox grpAdmin;
        private TextBox txtConfirmarContra;
        private Label label5;
        private Label label4;
        private TextBox txtNuevaContra;
        private CheckBox chkHabilitarCambio;
    }
}