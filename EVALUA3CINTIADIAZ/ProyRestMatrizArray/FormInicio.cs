using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyRestMatrizArray
{
    public partial class FormInicio : Form
    {
        public FormInicio() {
            InitializeComponent();
            this.MaximizeBox = false;
        }
		

        private void btnIrAIngreso_Click(object sender, EventArgs e) {
            Form F1 = new Form1();
            F1.Show();
            this.Hide();
        }

	}
}
