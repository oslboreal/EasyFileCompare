using System;
using System.IO;
using System.Windows.Forms;
using NS.Librerias.Winforms;
using System.Collections.Generic;
using System.Text;

namespace Sac.AplicacionesAux.ComparadorTextos
{
    public partial class Form1 : FormPrincipalBase
    {
        private bool estadoSwitch = true;

        private void Form1_Load(object sender, EventArgs e) { }

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Método manejador del evento Click empleado para comenzar a comparar los archivos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var rutaSalida = textBox3.Text;
            var rutaA = textBox1.Text;
            var rutaB = textBox2.Text;
            bool estado = false;

            // Obtengo las diferentes codificaciones para el tratamiento de los archivos.
            Encoding encPrimer = Encoding.GetEncoding(comboA.Text);
            Encoding encSegundo = Encoding.GetEncoding(comboB.Text);
            Encoding encSalida = Encoding.GetEncoding(comboOut.Text);

            EncodingComparacion configuracionComparacion = new EncodingComparacion(encPrimer, encSegundo, encSalida);

            // Tipo de operacion seleccionada.
            string selectedValue = comboBox1.Text;

            switch (selectedValue)
            {
                case "A-B":
                    buttonCompare.Enabled = false;
                    comboBox1.Enabled = false;
                    // Realizo la operación.
                    if (!string.IsNullOrEmpty(ComparadorHelper.DiferenciaEntre(rutaA, rutaB, rutaSalida, configuracionComparacion)))
                        estado = true;
                    break;
                case "XOR":
                    buttonCompare.Enabled = false;
                    comboBox1.Enabled = false;
                    // Realizo la operación.
                    estado = ComparadorHelper.XorEntre(rutaA, rutaB, rutaSalida, configuracionComparacion);
                    break;
                case "AND":
                    buttonCompare.Enabled = false;
                    comboBox1.Enabled = false;
                    // Realizo la operación.
                    estado = ComparadorHelper.AndEntre(rutaA, rutaB, rutaSalida, configuracionComparacion);
                    break;
                default:
                    break;
            }
            MessageBox.Show(estado.ToString());
        }

        /// <summary>
        /// Button One Click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFileOne_Click(object sender, EventArgs e)
        {
            if (SelectorArchivos.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = SelectorArchivos.FileName;
            }
        }

        /// <summary>
        /// Button Two Click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFileTwo_Click(object sender, EventArgs e)
        {
            if (SelectorArchivos.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = SelectorArchivos.FileName;
            }
        }

        private void UiUpdater_Tick(object sender, EventArgs e)
        {
            bool selectedState = DocumentsSelected();
            buttonCompare.Enabled = selectedState;
            comboBox1.Enabled = selectedState;

            // TextBox 1.
            if (!File.Exists(textBox1.Text))
            {
                if (textBox1.Text == "")
                    pictureBox1.Image = Properties.Resources.add;
                else
                    pictureBox1.Image = Properties.Resources.close;
            }
            else
            {
                pictureBox1.Image = Properties.Resources.check;
            }

            // TextBox 2.
            if (!File.Exists(textBox2.Text))
            {
                if (textBox2.Text == "")
                    pictureBox2.Image = Properties.Resources.add;
                else
                    pictureBox2.Image = Properties.Resources.close;
            }
            else
            {
                pictureBox2.Image = Properties.Resources.check;
            }

            // TextBox 3.
            if (!Directory.Exists(textBox3.Text))
            {
                if (textBox3.Text == "")
                    pictureBox3.Image = Properties.Resources.add;
                else
                    pictureBox3.Image = Properties.Resources.close;
            }
            else
            {
                pictureBox3.Image = Properties.Resources.check;
            }
        }

        /// <summary>
        /// Método encargado de informar si los documentos fueron seleccionados.
        /// </summary>
        /// <returns></returns>
        private bool DocumentsSelected()
        {
            bool retorno = false;
            if (textBox1.Text != string.Empty && !string.IsNullOrWhiteSpace(textBox1.Text) && textBox2.Text != string.Empty && !string.IsNullOrWhiteSpace(textBox2.Text))
                retorno = true;
            return retorno;
        }

        /// <summary>
        /// Método encargado de vaciar los campos.
        /// </summary>
        private void EmptyFields()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void buttonSalida_Click(object sender, EventArgs e)
        {

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    textBox3.Text = fbd.SelectedPath;
                }
            }
        }

        /// <summary>
        /// Check encoding primer campo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (File.Exists(textBox1.Text))
                {
                    comboA.Enabled = true;
                    var encoding = ArchivoHelper.obtenerEncoding(textBox1.Text);
                    comboA.Text = encoding.BodyName;
                }
            }
            else
            {
                comboA.Enabled = false;
            }
        }

        /// <summary>
        /// Check encoding segundo campo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (File.Exists(textBox2.Text))
                {
                    comboB.Enabled = true;
                    var encoding = ArchivoHelper.obtenerEncoding(textBox2.Text);
                    comboB.Text = encoding.BodyName;
                }
            }
            else
            {
                comboB.Enabled = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                if (Directory.Exists(textBox3.Text))
                {
                    comboOut.Enabled = true;
                }
            }
            else
            {
                comboOut.Enabled = false;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Dispose();
        }

        private void pictureBoxSwitch_Click(object sender, EventArgs e)
        {
            if(estadoSwitch)
            {
                estadoSwitch = false;
                pictureBoxSwitch.Image = Properties.Resources.switchA;
            }
            else
            {
                estadoSwitch = true;
                pictureBoxSwitch.Image = Properties.Resources.switchB;
            }

            IntercambiarCampos();

            this.textBox1_TextChanged(this, e);
            this.textBox2_TextChanged(this, e);

        }

        private void IntercambiarCampos()
        {
            string aux = textBox1.Text;
            textBox1.Text = textBox2.Text;
            textBox2.Text = aux;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Help nuevo = new Help();
            nuevo.Show();
        }
    }
}
