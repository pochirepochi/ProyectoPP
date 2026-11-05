namespace Proyecto_PP
{
    partial class FormPrimerIngreso
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
            txtRespuesta1 = new TextBox();
            txtRespuesta2 = new TextBox();
            txtRespuesta3 = new TextBox();
            txtRespuesta4 = new TextBox();
            txtRespuesta5 = new TextBox();
            label1 = new Label();
            btnGuardar = new Button();
            lblPregunta1 = new Label();
            lblPregunta2 = new Label();
            lblPregunta4 = new Label();
            lblPregunta3 = new Label();
            lblPregunta5 = new Label();
            SuspendLayout();
            // 
            // txtRespuesta1
            // 
            txtRespuesta1.Location = new Point(12, 186);
            txtRespuesta1.Name = "txtRespuesta1";
            txtRespuesta1.Size = new Size(121, 23);
            txtRespuesta1.TabIndex = 0;
            // 
            // txtRespuesta2
            // 
            txtRespuesta2.Location = new Point(313, 186);
            txtRespuesta2.Name = "txtRespuesta2";
            txtRespuesta2.Size = new Size(121, 23);
            txtRespuesta2.TabIndex = 1;
            // 
            // txtRespuesta3
            // 
            txtRespuesta3.Location = new Point(566, 186);
            txtRespuesta3.Name = "txtRespuesta3";
            txtRespuesta3.Size = new Size(121, 23);
            txtRespuesta3.TabIndex = 2;
            // 
            // txtRespuesta4
            // 
            txtRespuesta4.Location = new Point(155, 295);
            txtRespuesta4.Name = "txtRespuesta4";
            txtRespuesta4.Size = new Size(121, 23);
            txtRespuesta4.TabIndex = 3;
            // 
            // txtRespuesta5
            // 
            txtRespuesta5.Location = new Point(483, 295);
            txtRespuesta5.Name = "txtRespuesta5";
            txtRespuesta5.Size = new Size(121, 23);
            txtRespuesta5.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(298, 36);
            label1.Name = "label1";
            label1.Size = new Size(136, 15);
            label1.TabIndex = 10;
            label1.Text = "PREGUNTAS SEGURIDAD";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(313, 349);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(121, 23);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click_1;
            // 
            // lblPregunta1
            // 
            lblPregunta1.AutoSize = true;
            lblPregunta1.Location = new Point(12, 168);
            lblPregunta1.Name = "lblPregunta1";
            lblPregunta1.Size = new Size(38, 15);
            lblPregunta1.TabIndex = 12;
            lblPregunta1.Text = "label2";
            // 
            // lblPregunta2
            // 
            lblPregunta2.AutoSize = true;
            lblPregunta2.Location = new Point(313, 168);
            lblPregunta2.Name = "lblPregunta2";
            lblPregunta2.Size = new Size(38, 15);
            lblPregunta2.TabIndex = 13;
            lblPregunta2.Text = "label2";
            // 
            // lblPregunta4
            // 
            lblPregunta4.AutoSize = true;
            lblPregunta4.Location = new Point(155, 277);
            lblPregunta4.Name = "lblPregunta4";
            lblPregunta4.Size = new Size(38, 15);
            lblPregunta4.TabIndex = 14;
            lblPregunta4.Text = "label2";
            // 
            // lblPregunta3
            // 
            lblPregunta3.AutoSize = true;
            lblPregunta3.Location = new Point(566, 168);
            lblPregunta3.Name = "lblPregunta3";
            lblPregunta3.Size = new Size(38, 15);
            lblPregunta3.TabIndex = 15;
            lblPregunta3.Text = "label2";
            // 
            // lblPregunta5
            // 
            lblPregunta5.AutoSize = true;
            lblPregunta5.Location = new Point(483, 277);
            lblPregunta5.Name = "lblPregunta5";
            lblPregunta5.Size = new Size(38, 15);
            lblPregunta5.TabIndex = 16;
            lblPregunta5.Text = "label2";
            // 
            // FormPrimerIngreso
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblPregunta5);
            Controls.Add(lblPregunta3);
            Controls.Add(lblPregunta4);
            Controls.Add(lblPregunta2);
            Controls.Add(lblPregunta1);
            Controls.Add(btnGuardar);
            Controls.Add(label1);
            Controls.Add(txtRespuesta5);
            Controls.Add(txtRespuesta4);
            Controls.Add(txtRespuesta3);
            Controls.Add(txtRespuesta2);
            Controls.Add(txtRespuesta1);
            MinimumSize = new Size(816, 489);
            Name = "FormPrimerIngreso";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Preguntas_Seg";
            Load += FormPrimerIngreso_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtRespuesta1;
        private TextBox txtRespuesta2;
        private TextBox txtRespuesta3;
        private TextBox txtRespuesta4;
        private TextBox txtRespuesta5;
        private Label label1;
        private Button btnGuardar;
        private Label lblPregunta1;
        private Label lblPregunta2;
        private Label lblPregunta4;
        private Label lblPregunta3;
        private Label lblPregunta5;
    }
}