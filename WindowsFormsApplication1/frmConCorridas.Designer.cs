namespace WindowsFormsApplication1
{
    partial class frmConCorridas
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
            this.label9 = new System.Windows.Forms.Label();
            this.txtCantidaddecorridas = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMu = new System.Windows.Forms.TextBox();
            this.txtLamda = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtParametroDespla = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Cantidad de corridas:";
            // 
            // txtCantidaddecorridas
            // 
            this.txtCantidaddecorridas.Location = new System.Drawing.Point(134, 28);
            this.txtCantidaddecorridas.Name = "txtCantidaddecorridas";
            this.txtCantidaddecorridas.Size = new System.Drawing.Size(100, 20);
            this.txtCantidaddecorridas.TabIndex = 24;
            this.txtCantidaddecorridas.Text = "1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(451, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "Generar MM1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(238, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Mu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Lamda";
            // 
            // txtMu
            // 
            this.txtMu.Location = new System.Drawing.Point(286, 99);
            this.txtMu.Name = "txtMu";
            this.txtMu.Size = new System.Drawing.Size(100, 20);
            this.txtMu.TabIndex = 32;
            this.txtMu.Text = "0,5";
            // 
            // txtLamda
            // 
            this.txtLamda.Location = new System.Drawing.Point(286, 73);
            this.txtLamda.Name = "txtLamda";
            this.txtLamda.Size = new System.Drawing.Size(100, 20);
            this.txtLamda.TabIndex = 31;
            this.txtLamda.Text = "0,5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Cantidad de Clientes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Tiempo Simulacion";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(132, 97);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 28;
            this.textBox2.Text = "100";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(134, 74);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 27;
            this.textBox1.Text = "1000";
            // 
            // txtParametroDespla
            // 
            this.txtParametroDespla.Location = new System.Drawing.Point(432, 24);
            this.txtParametroDespla.Name = "txtParametroDespla";
            this.txtParametroDespla.Size = new System.Drawing.Size(100, 20);
            this.txtParametroDespla.TabIndex = 35;
            this.txtParametroDespla.Text = "2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(277, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Parametro de desplazamiento:";
            // 
            // frmConCorridas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 410);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtParametroDespla);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMu);
            this.Controls.Add(this.txtLamda);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCantidaddecorridas);
            this.Name = "frmConCorridas";
            this.Text = "frmConCorridas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCantidaddecorridas;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMu;
        private System.Windows.Forms.TextBox txtLamda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtParametroDespla;
        private System.Windows.Forms.Label label5;
    }
}