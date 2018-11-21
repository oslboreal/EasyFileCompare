namespace Sac.AplicacionesAux.ComparadorTextos
{
    partial class FormPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.buttonCompare = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SelectorArchivos = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.UiUpdater = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboOut = new System.Windows.Forms.ComboBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.buttonSalida = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBoxSwitch = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboB = new System.Windows.Forms.ComboBox();
            this.comboA = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.buttonFileTwo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonFileOne = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSwitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCompare
            // 
            this.buttonCompare.Location = new System.Drawing.Point(383, 7);
            this.buttonCompare.Name = "buttonCompare";
            this.buttonCompare.Size = new System.Drawing.Size(75, 23);
            this.buttonCompare.TabIndex = 10;
            this.buttonCompare.Text = "Comparar";
            this.buttonCompare.UseVisualStyleBackColor = true;
            this.buttonCompare.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.DisplayMember = "A-B";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "A-B",
            "AND",
            "XOR"});
            this.comboBox1.Location = new System.Drawing.Point(136, 7);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(74, 21);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 9;
            this.comboBox1.Text = "A-B";
            this.comboBox1.ValueMember = "A-B";
            // 
            // SelectorArchivos
            // 
            this.SelectorArchivos.FileName = "SelectorArchivos";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.linkLabel2);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.buttonCompare);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Location = new System.Drawing.Point(10, 173);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 38);
            this.panel1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Método de comparacion";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(210, 11);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(19, 13);
            this.linkLabel2.TabIndex = 12;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "[?]";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.DisabledLinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Enabled = false;
            this.linkLabel1.Location = new System.Drawing.Point(8, 11);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(0, 13);
            this.linkLabel1.TabIndex = 11;
            // 
            // UiUpdater
            // 
            this.UiUpdater.Enabled = true;
            this.UiUpdater.Tick += new System.EventHandler(this.UiUpdater_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboOut);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.buttonSalida);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Location = new System.Drawing.Point(-1, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 51);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ruta de salida";
            // 
            // comboOut
            // 
            this.comboOut.Enabled = false;
            this.comboOut.FormattingEnabled = true;
            this.comboOut.Items.AddRange(new object[] {
            "utf-7",
            "utf-8",
            "us-ascii",
            "utf-32",
            "utf-32BE",
            "utf-16",
            "windows-1252"});
            this.comboOut.Location = new System.Drawing.Point(301, 19);
            this.comboOut.Name = "comboOut";
            this.comboOut.Size = new System.Drawing.Size(74, 21);
            this.comboOut.TabIndex = 7;
            this.comboOut.Text = "windows-1252";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(9, 19);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(23, 23);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // buttonSalida
            // 
            this.buttonSalida.Location = new System.Drawing.Point(381, 18);
            this.buttonSalida.Name = "buttonSalida";
            this.buttonSalida.Size = new System.Drawing.Size(75, 23);
            this.buttonSalida.TabIndex = 8;
            this.buttonSalida.Text = ". . .";
            this.buttonSalida.UseVisualStyleBackColor = true;
            this.buttonSalida.Click += new System.EventHandler(this.buttonSalida_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(38, 20);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(257, 20);
            this.textBox3.TabIndex = 6;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.pictureBoxSwitch);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboB);
            this.groupBox2.Controls.Add(this.comboA);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.buttonFileTwo);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.buttonFileOne);
            this.groupBox2.Location = new System.Drawing.Point(-1, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(464, 97);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ficheros a comparar";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 2);
            this.label2.TabIndex = 11;
            // 
            // pictureBoxSwitch
            // 
            this.pictureBoxSwitch.Image = global::Sac.AplicacionesAux.ComparadorTextos.Properties.Resources.switchA;
            this.pictureBoxSwitch.Location = new System.Drawing.Point(154, 38);
            this.pictureBoxSwitch.Name = "pictureBoxSwitch";
            this.pictureBoxSwitch.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxSwitch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSwitch.TabIndex = 9;
            this.pictureBoxSwitch.TabStop = false;
            this.pictureBoxSwitch.DoubleClick += new System.EventHandler(this.pictureBoxSwitch_DoubleClick);
            this.pictureBoxSwitch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxSwitch_MouseClick);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(183, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 2);
            this.label1.TabIndex = 10;
            // 
            // comboB
            // 
            this.comboB.Enabled = false;
            this.comboB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboB.FormattingEnabled = true;
            this.comboB.Items.AddRange(new object[] {
            "utf-7",
            "utf-8",
            "us-ascii",
            "utf-32",
            "utf-32BE",
            "utf-16",
            "windows-1252"});
            this.comboB.Location = new System.Drawing.Point(300, 62);
            this.comboB.Name = "comboB";
            this.comboB.Size = new System.Drawing.Size(74, 21);
            this.comboB.TabIndex = 4;
            this.comboB.Text = "Undefined";
            // 
            // comboA
            // 
            this.comboA.Enabled = false;
            this.comboA.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboA.FormattingEnabled = true;
            this.comboA.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboA.Items.AddRange(new object[] {
            "utf-7",
            "utf-8",
            "us-ascii",
            "utf-32",
            "utf-32BE",
            "utf-16",
            "windows-1252"});
            this.comboA.Location = new System.Drawing.Point(300, 17);
            this.comboA.Name = "comboA";
            this.comboA.Size = new System.Drawing.Size(74, 21);
            this.comboA.TabIndex = 1;
            this.comboA.Text = "Undefined";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(8, 61);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(23, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // buttonFileTwo
            // 
            this.buttonFileTwo.Location = new System.Drawing.Point(380, 61);
            this.buttonFileTwo.Name = "buttonFileTwo";
            this.buttonFileTwo.Size = new System.Drawing.Size(75, 23);
            this.buttonFileTwo.TabIndex = 5;
            this.buttonFileTwo.Text = "Abrir B";
            this.buttonFileTwo.UseVisualStyleBackColor = true;
            this.buttonFileTwo.Click += new System.EventHandler(this.buttonFileTwo_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(37, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(257, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(37, 62);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(257, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // buttonFileOne
            // 
            this.buttonFileOne.Location = new System.Drawing.Point(380, 16);
            this.buttonFileOne.Name = "buttonFileOne";
            this.buttonFileOne.Size = new System.Drawing.Size(75, 23);
            this.buttonFileOne.TabIndex = 2;
            this.buttonFileOne.Text = "Abrir A";
            this.buttonFileOne.UseVisualStyleBackColor = true;
            this.buttonFileOne.Click += new System.EventHandler(this.buttonFileOne_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Location = new System.Drawing.Point(10, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(462, 167);
            this.panel2.TabIndex = 10;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 215);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(499, 256);
            this.MinimumSize = new System.Drawing.Size(498, 254);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comparador de Registros";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSwitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCompare;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.OpenFileDialog SelectorArchivos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Timer UiUpdater;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboOut;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button buttonSalida;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBoxSwitch;
        private System.Windows.Forms.ComboBox comboB;
        private System.Windows.Forms.ComboBox comboA;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button buttonFileTwo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonFileOne;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

