namespace Proyecto_PP
{
    partial class Usuario
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
            components = new System.ComponentModel.Container();
            tabControl = new TabControl();
            tabCambiarContrasena = new TabPage();
            lblEspecial = new Label();
            lblNumyLet = new Label();
            lblMayus = new Label();
            lblCaracter8 = new Label();
            btnVolver = new Button();
            btnGuardarPass = new Button();
            txtNueva = new TextBox();
            label3 = new Label();
            txtConfirmar = new TextBox();
            label2 = new Label();
            txtActual = new TextBox();
            label1 = new Label();
            tabPregseg = new TabPage();
            btnPreguntas = new Button();
            flowPreguntas = new FlowLayoutPanel();
            tmrValidacion = new System.Windows.Forms.Timer(components);
            tabControl.SuspendLayout();
            tabCambiarContrasena.SuspendLayout();
            tabPregseg.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabCambiarContrasena);
            tabControl.Controls.Add(tabPregseg);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(800, 450);
            tabControl.SizeMode = TabSizeMode.Fixed;
            tabControl.TabIndex = 0;
            tabControl.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabCambiarContrasena
            // 
            tabCambiarContrasena.Controls.Add(lblEspecial);
            tabCambiarContrasena.Controls.Add(lblNumyLet);
            tabCambiarContrasena.Controls.Add(lblMayus);
            tabCambiarContrasena.Controls.Add(lblCaracter8);
            tabCambiarContrasena.Controls.Add(btnVolver);
            tabCambiarContrasena.Controls.Add(btnGuardarPass);
            tabCambiarContrasena.Controls.Add(txtNueva);
            tabCambiarContrasena.Controls.Add(label3);
            tabCambiarContrasena.Controls.Add(txtConfirmar);
            tabCambiarContrasena.Controls.Add(label2);
            tabCambiarContrasena.Controls.Add(txtActual);
            tabCambiarContrasena.Controls.Add(label1);
            tabCambiarContrasena.Location = new Point(4, 24);
            tabCambiarContrasena.Name = "tabCambiarContrasena";
            tabCambiarContrasena.Padding = new Padding(3);
            tabCambiarContrasena.Size = new Size(792, 422);
            tabCambiarContrasena.TabIndex = 0;
            tabCambiarContrasena.Text = "cambiar clave";
            tabCambiarContrasena.UseVisualStyleBackColor = true;
            tabCambiarContrasena.Click += tabCambiarContrasena_Click;
            // 
            // lblEspecial
            // 
            lblEspecial.AutoSize = true;
            lblEspecial.Location = new Point(8, 248);
            lblEspecial.Name = "lblEspecial";
            lblEspecial.Size = new Size(166, 15);
            lblEspecial.TabIndex = 8;
            lblEspecial.Text = "Debe usar un caracter especial";
            // 
            // lblNumyLet
            // 
            lblNumyLet.AutoSize = true;
            lblNumyLet.Location = new Point(8, 233);
            lblNumyLet.Name = "lblNumyLet";
            lblNumyLet.Size = new Size(193, 15);
            lblNumyLet.TabIndex = 7;
            lblNumyLet.Text = "La clave debe usar numeros y letras";
            // 
            // lblMayus
            // 
            lblMayus.AutoSize = true;
            lblMayus.Location = new Point(8, 218);
            lblMayus.Name = "lblMayus";
            lblMayus.Size = new Size(140, 15);
            lblMayus.TabIndex = 6;
            lblMayus.Text = "Al menos una mayuscula";
            // 
            // lblCaracter8
            // 
            lblCaracter8.AutoSize = true;
            lblCaracter8.Location = new Point(8, 203);
            lblCaracter8.Name = "lblCaracter8";
            lblCaracter8.Size = new Size(116, 15);
            lblCaracter8.TabIndex = 8;
            lblCaracter8.Text = "Maximo 8 caracteres";
            lblCaracter8.Click += label4_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(709, 391);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 4;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnGuardarPass
            // 
            btnGuardarPass.Location = new Point(8, 312);
            btnGuardarPass.Name = "btnGuardarPass";
            btnGuardarPass.Size = new Size(75, 23);
            btnGuardarPass.TabIndex = 3;
            btnGuardarPass.Text = "GUARDAR";
            btnGuardarPass.UseVisualStyleBackColor = true;
            btnGuardarPass.Click += btnGuardarPass_Click;
            // 
            // txtNueva
            // 
            txtNueva.Location = new Point(8, 97);
            txtNueva.Name = "txtNueva";
            txtNueva.Size = new Size(251, 23);
            txtNueva.TabIndex = 1;
            txtNueva.TextChanged += txtNueva_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 79);
            label3.Name = "label3";
            label3.Size = new Size(105, 15);
            label3.TabIndex = 4;
            label3.Text = "Contrasena nueva:";
            // 
            // txtConfirmar
            // 
            txtConfirmar.Location = new Point(8, 163);
            txtConfirmar.Name = "txtConfirmar";
            txtConfirmar.Size = new Size(251, 23);
            txtConfirmar.TabIndex = 2;
            txtConfirmar.TextChanged += txtConfirmar_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 145);
            label2.Name = "label2";
            label2.Size = new Size(99, 15);
            label2.TabIndex = 2;
            label2.Text = "Confirmar nueva:";
            // 
            // txtActual
            // 
            txtActual.Location = new Point(8, 35);
            txtActual.Name = "txtActual";
            txtActual.Size = new Size(251, 23);
            txtActual.TabIndex = 0;
            txtActual.TextChanged += txtActual_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 17);
            label1.Name = "label1";
            label1.Size = new Size(105, 15);
            label1.TabIndex = 0;
            label1.Text = "Contrasena actual:";
            // 
            // tabPregseg
            // 
            tabPregseg.Controls.Add(btnPreguntas);
            tabPregseg.Controls.Add(flowPreguntas);
            tabPregseg.Location = new Point(4, 24);
            tabPregseg.Name = "tabPregseg";
            tabPregseg.Padding = new Padding(3);
            tabPregseg.Size = new Size(792, 422);
            tabPregseg.TabIndex = 1;
            tabPregseg.Text = "Preguntas de seguridad";
            tabPregseg.UseVisualStyleBackColor = true;
            // 
            // btnPreguntas
            // 
            btnPreguntas.Location = new Point(311, 403);
            btnPreguntas.Name = "btnPreguntas";
            btnPreguntas.Size = new Size(148, 23);
            btnPreguntas.TabIndex = 0;
            btnPreguntas.Text = "Guardar Preguntas";
            btnPreguntas.UseVisualStyleBackColor = true;
            btnPreguntas.Click += btnPreguntas_Click;
            // 
            // flowPreguntas
            // 
            flowPreguntas.Dock = DockStyle.Fill;
            flowPreguntas.Location = new Point(3, 3);
            flowPreguntas.Name = "flowPreguntas";
            flowPreguntas.Size = new Size(786, 416);
            flowPreguntas.TabIndex = 0;
            flowPreguntas.Paint += flowPreguntas_Paint;
            // 
            // Usuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl);
            MinimumSize = new Size(816, 489);
            Name = "Usuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Usuario";
            Load += Usuario_Load_1;
            tabControl.ResumeLayout(false);
            tabCambiarContrasena.ResumeLayout(false);
            tabCambiarContrasena.PerformLayout();
            tabPregseg.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabCambiarContrasena;
        private TabPage tabPregseg;
        private TextBox txtNueva;
        private Label label3;
        private TextBox txtConfirmar;
        private Label label2;
        private TextBox txtActual;
        private Label label1;
        private Button btnGuardarPass;
        private Button btnPreguntas;
        private FlowLayoutPanel flowPreguntas;
        private System.Windows.Forms.Timer tmrValidacion;
        private Button btnVolver;
        private Label lblEspecial;
        private Label lblNumyLet;
        private Label lblMayus;
        private Label lblCaracter8;
    }
}