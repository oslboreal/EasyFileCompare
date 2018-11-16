using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sac.AplicacionesAux.ComparadorTextos
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
            textoMinus.Show();
            textoXor.Hide();
            textoAnd.Hide();
        }

        private void Help_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedValue = comboBox1.Text;

            switch (selectedValue)
            {
                case "A-B":
                    imagenExplicacion.Image = Properties.Resources.Minus;
                    textoMinus.Show();
                    textoXor.Hide();
                    textoAnd.Hide();
                    break;
                case "XOR":
                    imagenExplicacion.Image = Properties.Resources.XOR;
                    textoXor.Show();
                    textoMinus.Hide();
                    textoAnd.Hide();
                    break;
                case "AND":
                    imagenExplicacion.Image = Properties.Resources.Intersect;
                    textoAnd.Show();
                    textoMinus.Hide();
                    textoXor.Hide();
                    break;
                default:
                    break;
            }
        }

        private void Help_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Dispose();
        }
    }
}
