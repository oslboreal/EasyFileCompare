using System;
using System.IO;
using System.Windows.Forms;
using System.Text;

namespace Sac.AplicacionesAux.ComparadorTextos
{
    public partial class FormPrincipal : Form
    {
        private bool estadoSwitch = true;
        private bool estadoA = false;
        private bool estadoB = false;
        private bool estadoC = false;

        private void Form1_Load(object sender, EventArgs e) { }

        public FormPrincipal()
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
            try
            {
                var rutaSalida = textBox3.Text;
                var rutaA = textBox1.Text;
                var rutaB = textBox2.Text;

                // Obtengo las diferentes codificaciones para el tratamiento de los archivos.
                Encoding encPrimer = Encoding.GetEncoding(comboA.Text);
                Encoding encSegundo = Encoding.GetEncoding(comboB.Text);
                Encoding encSalida = Encoding.GetEncoding(comboOut.Text);

                var procesoComparacion = new ProcesoComparador(encPrimer, encSegundo, encSalida);

                // Tipo de operacion seleccionada.
                string selectedValue = comboBox1.Text;

                switch (selectedValue)
                {
                    case "A-B":
                        buttonCompare.Enabled = false;
                        comboBox1.Enabled = false;
                        // Realizo la operación.
                        procesoComparacion.RealizarOperacion(rutaA, rutaB, rutaSalida, TipoComparacion.Diferencia);
                        break;
                    case "XOR":
                        buttonCompare.Enabled = false;
                        comboBox1.Enabled = false;
                        // Realizo la operación.
                        procesoComparacion.RealizarOperacion(rutaA, rutaB, rutaSalida, TipoComparacion.XOR);
                        break;
                    case "AND":
                        buttonCompare.Enabled = false;
                        comboBox1.Enabled = false;
                        // Realizo la operación.
                        procesoComparacion.RealizarOperacion(rutaA, rutaB, rutaSalida, TipoComparacion.AND);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                // LOG
                throw;
            }
        }

        /// <summary>
        /// Actualizador de la interfaz de Usuario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UiUpdater_Tick(object sender, EventArgs e)
        {
            bool selectedState = DocumentsSelected();
            buttonCompare.Enabled = selectedState;
            comboBox1.Enabled = selectedState;

            // TextBox 1.
            estadoA = SetPictureBox(pictureBox1, textBox1, true);

            // TextBox 2.
            estadoB = SetPictureBox(pictureBox2, textBox2, true);

            // TextBox 3.
            if (textBox3.Text == "")
            {
                estadoC = false;
                pictureBox3.Image = Properties.Resources.add;
            }
            else
            {
                estadoC = true;
                pictureBox3.Image = Properties.Resources.checkx32;
            }

        }

        /// <summary>
        /// Método encargado de informar si los documentos fueron seleccionados.
        /// </summary>
        /// <returns></returns>
        private bool DocumentsSelected()
        {
            bool retorno = false;
            if (estadoA && estadoB && estadoC)
                retorno = true;
            return retorno;
        }

        /// <summary>
        /// Método encargado de altenar el valor de los textbox.
        /// </summary>
        private void IntercambiarCampos()
        {
            string aux = textBox1.Text;
            textBox1.Text = textBox2.Text;
            textBox2.Text = aux;
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

        private void buttonSalida_Click(object sender, EventArgs e)
        {

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    textBox3.Text = fbd.SelectedPath;
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
                    var encoding = ArchivoHelper.ObtenerEncoding(textBox1.Text);
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
                    var encoding = ArchivoHelper.ObtenerEncoding(textBox2.Text);
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
                    comboOut.Enabled = true;
            }
            else
            {
                comboOut.Enabled = false;
            }
        }

        /// <summary>
        /// Método empleado para facilitar el cierre del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Dispose();
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Help nuevo = new Help();
            nuevo.Show();
        }

        private void pictureBoxSwitch_MouseClick(object sender, MouseEventArgs e)
        {
            if (estadoSwitch)
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

        private void pictureBoxSwitch_DoubleClick(object sender, EventArgs e)
        {
            if (estadoSwitch)
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

        /// <summary>
        /// Método encargado de asignar el icono correspondiente a la textbox en función de la ruta.
        /// </summary>
        /// <param name="picture"></param>
        /// <param name="tbox"></param>
        private bool SetPictureBox(PictureBox picture, TextBox tbox, bool esArchivo)
        {
            if (esArchivo) // Es archivo.
            {
                if (!File.Exists(tbox.Text))
                {
                    if (tbox.Text == "")
                        picture.Image = Properties.Resources.add;
                    else
                        picture.Image = Properties.Resources.close;

                    return false;
                }
                else
                {
                    picture.Image = Properties.Resources.check;
                    return true;
                }
            }
            else // Es directorio.
            {
                if (!Directory.Exists(tbox.Text))
                {
                    if (tbox.Text == "")
                        picture.Image = Properties.Resources.add;
                    else
                        picture.Image = Properties.Resources.close;

                    return false;
                }
                else
                {
                    pictureBox3.Image = Properties.Resources.check;
                    return true;
                }
            }

        }
    }
}