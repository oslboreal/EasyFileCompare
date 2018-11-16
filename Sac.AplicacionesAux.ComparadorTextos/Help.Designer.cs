namespace Sac.AplicacionesAux.ComparadorTextos
{
    partial class Help
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textoAnd = new System.Windows.Forms.Label();
            this.textoXor = new System.Windows.Forms.Label();
            this.textoMinus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.imagenExplicacion = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagenExplicacion)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.imagenExplicacion);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 225);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textoAnd);
            this.panel2.Controls.Add(this.textoXor);
            this.panel2.Controls.Add(this.textoMinus);
            this.panel2.Location = new System.Drawing.Point(3, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(425, 34);
            this.panel2.TabIndex = 6;
            // 
            // textoAnd
            // 
            this.textoAnd.AutoSize = true;
            this.textoAnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textoAnd.Location = new System.Drawing.Point(39, 6);
            this.textoAnd.Name = "textoAnd";
            this.textoAnd.Size = new System.Drawing.Size(350, 20);
            this.textoAnd.TabIndex = 8;
            this.textoAnd.Text = "Todos los elementos que esten en A y B a la vez";
            // 
            // textoXor
            // 
            this.textoXor.AutoSize = true;
            this.textoXor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textoXor.Location = new System.Drawing.Point(10, 6);
            this.textoXor.Name = "textoXor";
            this.textoXor.Size = new System.Drawing.Size(405, 20);
            this.textoXor.TabIndex = 7;
            this.textoXor.Text = "Todos los elementos que esten en solo en A o solo en B";
            // 
            // textoMinus
            // 
            this.textoMinus.AutoSize = true;
            this.textoMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textoMinus.Location = new System.Drawing.Point(49, 6);
            this.textoMinus.Name = "textoMinus";
            this.textoMinus.Size = new System.Drawing.Size(326, 20);
            this.textoMinus.TabIndex = 6;
            this.textoMinus.Text = "Todos los elementos de A que no esten en B";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Seleccione el mecanismo:";
            // 
            // imagenExplicacion
            // 
            this.imagenExplicacion.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.imagenExplicacion.ErrorImage = ((System.Drawing.Image)(resources.GetObject("imagenExplicacion.ErrorImage")));
            this.imagenExplicacion.Image = global::Sac.AplicacionesAux.ComparadorTextos.Properties.Resources.Minus;
            this.imagenExplicacion.InitialImage = ((System.Drawing.Image)(resources.GetObject("imagenExplicacion.InitialImage")));
            this.imagenExplicacion.Location = new System.Drawing.Point(119, 90);
            this.imagenExplicacion.Name = "imagenExplicacion";
            this.imagenExplicacion.Size = new System.Drawing.Size(191, 121);
            this.imagenExplicacion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imagenExplicacion.TabIndex = 1;
            this.imagenExplicacion.TabStop = false;
            this.imagenExplicacion.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "A-B",
            "AND",
            "XOR"});
            this.comboBox1.Location = new System.Drawing.Point(224, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Text = "A-B";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(457, 251);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(473, 290);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(473, 290);
            this.Name = "Help";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mecanismos de Comparación.";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Help_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Help_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagenExplicacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox imagenExplicacion;
        private System.Windows.Forms.Label textoAnd;
        private System.Windows.Forms.Label textoXor;
        private System.Windows.Forms.Label textoMinus;
    }
}