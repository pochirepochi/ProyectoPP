namespace Proyecto_PP
{
    partial class Registro
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
            label6 = new Label();
            lblCriterios = new Label();
            label8 = new Label();
            txtEmail = new TextBox();
            txtUsuario = new TextBox();
            txtCont = new TextBox();
            btnCompletarRegistro = new Button();
            btnVolver = new Button();
            cmbRoles = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label7 = new Label();
            label9 = new Label();
            txtTelefono = new TextBox();
            txtDocumento = new TextBox();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            txtCalle = new TextBox();
            label10 = new Label();
            btnGenerar = new Button();
            label11 = new Label();
            txtLocalidad = new TextBox();
            cmbProvincia = new ComboBox();
            label12 = new Label();
            label13 = new Label();
            chkLongitud = new CheckBox();
            chkMayuscula = new CheckBox();
            chkAlfanumerica = new CheckBox();
            chkEspecial = new CheckBox();
            btnGenerarClave = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(455, 59);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Email:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(455, 103);
            label6.Name = "label6";
            label6.Size = new Size(113, 15);
            label6.TabIndex = 5;
            label6.Text = "Nombre de Usuario:";
            // 
            // lblCriterios
            // 
            lblCriterios.AutoSize = true;
            lblCriterios.Location = new Point(455, 257);
            lblCriterios.Name = "lblCriterios";
            lblCriterios.Size = new Size(54, 15);
            lblCriterios.TabIndex = 6;
            lblCriterios.Text = "Criterios:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(455, 194);
            label8.Name = "label8";
            label8.Size = new Size(39, 15);
            label8.TabIndex = 7;
            label8.Text = "Clave:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(455, 77);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(189, 23);
            txtEmail.TabIndex = 7;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(455, 121);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(189, 23);
            txtUsuario.TabIndex = 30;
            // 
            // txtCont
            // 
            txtCont.Location = new Point(455, 212);
            txtCont.Name = "txtCont";
            txtCont.ReadOnly = true;
            txtCont.Size = new Size(189, 23);
            txtCont.TabIndex = 10;
            // 
            // btnCompletarRegistro
            // 
            btnCompletarRegistro.Location = new Point(280, 397);
            btnCompletarRegistro.Name = "btnCompletarRegistro";
            btnCompletarRegistro.Size = new Size(113, 38);
            btnCompletarRegistro.TabIndex = 15;
            btnCompletarRegistro.Text = "Agregar";
            btnCompletarRegistro.UseVisualStyleBackColor = true;
            btnCompletarRegistro.Click += btnCompletarRegistro_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(399, 397);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(113, 38);
            btnVolver.TabIndex = 15;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // cmbRoles
            // 
            cmbRoles.FormattingEnabled = true;
            cmbRoles.Location = new Point(455, 168);
            cmbRoles.Name = "cmbRoles";
            cmbRoles.Size = new Size(189, 23);
            cmbRoles.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(455, 150);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 14;
            label3.Text = "Roles:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(152, 59);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 15;
            label4.Text = "Nombre:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(152, 103);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 16;
            label5.Text = "Apellido:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(152, 147);
            label7.Name = "label7";
            label7.Size = new Size(166, 15);
            label7.TabIndex = 17;
            label7.Text = "Numero de documento (DNI):";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(152, 191);
            label9.Name = "label9";
            label9.Size = new Size(55, 15);
            label9.TabIndex = 18;
            label9.Text = "Telefono:";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(152, 209);
            txtTelefono.MaxLength = 10;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(189, 23);
            txtTelefono.TabIndex = 3;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(152, 165);
            txtDocumento.MaxLength = 8;
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(189, 23);
            txtDocumento.TabIndex = 2;
            txtDocumento.KeyPress += txtDocumento_KeyPress;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(152, 121);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(189, 23);
            txtApellido.TabIndex = 1;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(152, 77);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(189, 23);
            txtNombre.TabIndex = 0;
            // 
            // txtCalle
            // 
            txtCalle.Location = new Point(152, 253);
            txtCalle.Name = "txtCalle";
            txtCalle.Size = new Size(189, 23);
            txtCalle.TabIndex = 4;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(152, 235);
            label10.Name = "label10";
            label10.Size = new Size(78, 15);
            label10.TabIndex = 24;
            label10.Text = "Calle y altura:";
            // 
            // btnGenerar
            // 
            btnGenerar.Location = new Point(650, 111);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(145, 41);
            btnGenerar.TabIndex = 8;
            btnGenerar.Text = "Generar \r\nNombre de Usuario";
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Click += button1_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(152, 279);
            label11.Name = "label11";
            label11.Size = new Size(61, 15);
            label11.TabIndex = 27;
            label11.Text = "Localidad:";
            // 
            // txtLocalidad
            // 
            txtLocalidad.Location = new Point(152, 297);
            txtLocalidad.Name = "txtLocalidad";
            txtLocalidad.Size = new Size(189, 23);
            txtLocalidad.TabIndex = 5;
            txtLocalidad.TextChanged += textBox1_TextChanged;
            // 
            // cmbProvincia
            // 
            cmbProvincia.FormattingEnabled = true;
            cmbProvincia.Location = new Point(152, 341);
            cmbProvincia.Name = "cmbProvincia";
            cmbProvincia.Size = new Size(189, 23);
            cmbProvincia.TabIndex = 6;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(152, 323);
            label12.Name = "label12";
            label12.Size = new Size(59, 15);
            label12.TabIndex = 29;
            label12.Text = "Provincia:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(110, 212);
            label13.Name = "label13";
            label13.Size = new Size(36, 15);
            label13.TabIndex = 30;
            label13.Text = "+54 9";
            // 
            // chkLongitud
            // 
            chkLongitud.AutoSize = true;
            chkLongitud.Location = new Point(455, 275);
            chkLongitud.Name = "chkLongitud";
            chkLongitud.Size = new Size(133, 19);
            chkLongitud.TabIndex = 11;
            chkLongitud.Text = "Minimo 8 caracteres";
            chkLongitud.UseVisualStyleBackColor = true;
            // 
            // chkMayuscula
            // 
            chkMayuscula.AutoSize = true;
            chkMayuscula.Location = new Point(455, 300);
            chkMayuscula.Name = "chkMayuscula";
            chkMayuscula.Size = new Size(256, 19);
            chkMayuscula.TabIndex = 12;
            chkMayuscula.Text = "La clave debe usar al menos una mayuscula";
            chkMayuscula.UseVisualStyleBackColor = true;
            // 
            // chkAlfanumerica
            // 
            chkAlfanumerica.AutoSize = true;
            chkAlfanumerica.Location = new Point(455, 325);
            chkAlfanumerica.Name = "chkAlfanumerica";
            chkAlfanumerica.Size = new Size(168, 19);
            chkAlfanumerica.TabIndex = 13;
            chkAlfanumerica.Text = "Debe usar numeros y letras";
            chkAlfanumerica.UseVisualStyleBackColor = true;
            // 
            // chkEspecial
            // 
            chkEspecial.AutoSize = true;
            chkEspecial.Location = new Point(455, 350);
            chkEspecial.Name = "chkEspecial";
            chkEspecial.Size = new Size(203, 19);
            chkEspecial.TabIndex = 14;
            chkEspecial.Text = "Minimo un caracter especial(@!$)";
            chkEspecial.UseVisualStyleBackColor = true;
            // 
            // btnGenerarClave
            // 
            btnGenerarClave.Location = new Point(650, 202);
            btnGenerarClave.Name = "btnGenerarClave";
            btnGenerarClave.Size = new Size(145, 41);
            btnGenerarClave.TabIndex = 10;
            btnGenerarClave.Text = "Generar \r\nClave\r\n";
            btnGenerarClave.UseVisualStyleBackColor = true;
            btnGenerarClave.Click += btnGenerarClave_Click;
            // 
            // Registro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 573);
            Controls.Add(btnGenerarClave);
            Controls.Add(chkEspecial);
            Controls.Add(chkAlfanumerica);
            Controls.Add(chkMayuscula);
            Controls.Add(chkLongitud);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(cmbProvincia);
            Controls.Add(label11);
            Controls.Add(txtLocalidad);
            Controls.Add(btnGenerar);
            Controls.Add(label10);
            Controls.Add(txtCalle);
            Controls.Add(txtNombre);
            Controls.Add(txtApellido);
            Controls.Add(txtDocumento);
            Controls.Add(txtTelefono);
            Controls.Add(label9);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cmbRoles);
            Controls.Add(btnVolver);
            Controls.Add(btnCompletarRegistro);
            Controls.Add(txtCont);
            Controls.Add(txtUsuario);
            Controls.Add(txtEmail);
            Controls.Add(label8);
            Controls.Add(lblCriterios);
            Controls.Add(label6);
            Controls.Add(label1);
            MinimumSize = new Size(816, 612);
            Name = "Registro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro";
            Load += Registro_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        #endregion

        private Label label1;
        private Label label6;
        private Label lblCriterios;
        private Label label8;
        private TextBox txtEmail;
        private TextBox txtUsuario;
        private TextBox txtCont;
        private Button btnCompletarRegistro;
        private Button btnVolver;
        private ComboBox cmbRoles;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label7;
        private Label label9;
        private TextBox txtTelefono;
        private TextBox txtDocumento;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private TextBox txtCalle;
        private Label label10;
        private Button btnGenerar;
        private Label label11;
        private TextBox txtLocalidad;
        private ComboBox cmbProvincia;
        private Label label12;
        private Label label13;
        private CheckBox chkLongitud;
        private CheckBox chkMayuscula;
        private CheckBox chkAlfanumerica;
        private CheckBox chkEspecial;
        private Button btnGenerarClave;
    }
}