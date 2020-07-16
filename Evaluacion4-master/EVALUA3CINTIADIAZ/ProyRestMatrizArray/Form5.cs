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
    public partial class Form5 : Form
    {
        public Form5() {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e) {
            Form F1 = new Form1();
            F1.Show();
            this.Hide();
        }
    }
}
