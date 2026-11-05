namespace Proyecto_PP
{
    partial class Form1
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
            btnInicio = new Button();
            lblOlvidar = new Label();
            txtUsuario = new TextBox();
            txtCont = new TextBox();
            label2 = new Label();
            label3 = new Label();
            ckbMostrar = new CheckBox();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // btnInicio
            // 
            btnInicio.Location = new Point(490, 324);
            btnInicio.Name = "btnInicio";
            btnInicio.Size = new Size(139, 23);
            btnInicio.TabIndex = 3;
            btnInicio.Text = "Inicio de Sesion";
            btnInicio.UseVisualStyleBackColor = true;
            btnInicio.Click += button1_Click;
            // 
            // lblOlvidar
            // 
            lblOlvidar.AutoSize = true;
            lblOlvidar.Cursor = Cursors.Hand;
            lblOlvidar.Location = new Point(546, 271);
            lblOlvidar.Name = "lblOlvidar";
            lblOlvidar.Size = new Size(139, 15);
            lblOlvidar.TabIndex = 4;
            lblOlvidar.Text = "Olvidaste la contrasena??";
            lblOlvidar.Click += lblOlvidar_Click;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(424, 189);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(261, 23);
            txtUsuario.TabIndex = 0;
            // 
            // txtCont
            // 
            txtCont.Location = new Point(424, 245);
            txtCont.Name = "txtCont";
            txtCont.Size = new Size(261, 23);
            txtCont.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(424, 227);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 5;
            label2.Text = "Contrasena:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(424, 171);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 6;
            label3.Text = "Usuario:";
            // 
            // ckbMostrar
            // 
            ckbMostrar.AutoSize = true;
            ckbMostrar.Location = new Point(691, 249);
            ckbMostrar.Name = "ckbMostrar";
            ckbMostrar.Size = new Size(130, 19);
            ckbMostrar.TabIndex = 2;
            ckbMostrar.Text = "Mostrar Contrasena";
            ckbMostrar.UseVisualStyleBackColor = true;
            ckbMostrar.CheckedChanged += ckbMostrar_CheckedChanged;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(1107, 12);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 8;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1194, 493);
            Controls.Add(btnSalir);
            Controls.Add(ckbMostrar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtCont);
            Controls.Add(txtUsuario);
            Controls.Add(lblOlvidar);
            Controls.Add(btnInicio);
            MinimumSize = new Size(1210, 532);
            Name = "Form1";
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnInicio;
        private Label lblOlvidar;
        private TextBox txtUsuario;
        private TextBox txtCont;
        private Label label2;
        private Label label3;
        private CheckBox ckbMostrar;
        private Button btnSalir;
    }
}
