namespace Proyecto_PP
{
    partial class Form3
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
            txtUsuario = new TextBox();
            btnEnviar = new Button();
            btnBuscar = new Button();
            flowPreguntas = new FlowLayoutPanel();
            btnVolver = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(272, 172);
            label1.Name = "label1";
            label1.Size = new Size(163, 15);
            label1.TabIndex = 0;
            label1.Text = "Ingresar el Usuario registrado:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(272, 190);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(173, 23);
            txtUsuario.TabIndex = 0;
            // 
            // btnEnviar
            // 
            btnEnviar.AccessibleRole = AccessibleRole.None;
            btnEnviar.Location = new Point(370, 265);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(75, 23);
            btnEnviar.TabIndex = 2;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(272, 265);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 1;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // flowPreguntas
            // 
            flowPreguntas.Location = new Point(451, 127);
            flowPreguntas.Name = "flowPreguntas";
            flowPreguntas.Size = new Size(337, 311);
            flowPreguntas.TabIndex = 3;
            flowPreguntas.Paint += flowPreguntas_Paint;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(713, 12);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 5;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnVolver);
            Controls.Add(flowPreguntas);
            Controls.Add(btnBuscar);
            Controls.Add(btnEnviar);
            Controls.Add(txtUsuario);
            Controls.Add(label1);
            MinimumSize = new Size(816, 489);
            Name = "Form3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form3";
            Load += Form3_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtUsuario;
        private Button btnEnviar;
        private Button btnBuscar;
        private FlowLayoutPanel flowPreguntas;
        private Button btnVolver;
    }
}