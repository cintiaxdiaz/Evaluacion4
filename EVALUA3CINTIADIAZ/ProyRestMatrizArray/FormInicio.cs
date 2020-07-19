using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyRestMatrizArray
{
    public partial class FormInicio : Form
    {
        public FormInicio() {
            InitializeComponent();
            this.MaximizeBox = false;
            this.ClientSize = new Size(730, 306);
        }
		
        private void btnIrAIngreso_Click(object sender, EventArgs e) {
            Form F1 = new Form1();
            F1.Show();
            this.Hide();
        }

	}
}
