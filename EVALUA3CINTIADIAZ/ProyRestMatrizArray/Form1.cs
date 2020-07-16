using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ProyRestMatrizArray
{
    public partial class Form1 : For
    {//PAblo
        public Form1()
        {
            InitializeComponent();
        }
        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            if (rutValido(textBoxPassUsuario.Text)) {
                USUARIO usua = new  USUARIO(textBoxPassUsuario.Text);
                Form formulario = new Form2(usua);
                formulario.Show();
                Visible = false;
                MessageBox.Show("BIENVENIDO, QUE TENGAS UN EXCELENTE DÍA!");
            } else {
                MessageBox.Show("Usuario o contraseña incorrecta"); 
            }
        }
        private void Horayfecha_Tick(object sender, EventArgs e) {
            // Indica la hora y la fecha en tiempo real
            hora.Text = DateTime.Now.ToString("HH:mm:ss");
            fecha.Text = DateTime.Now.ToLongDateString();
        }
        private bool rutValido(string rut) {

            Regex rgx = new Regex(@"^\d{1,8}-(?:\d|k|K)$");
            if (!rgx.IsMatch(rut)) {
                MessageBox.Show("Rut con formato inválido");
                return false;
            }
            int RUT_NUM_CHARS = 10;
            rut = rut.Replace(".", "");
            if ((rut.Length < 3) | rut[rut.Length - 2] != '-') {
                return false;
            }
            int cerosFaltantes = RUT_NUM_CHARS - rut.Length;
            rut = (new String('0', cerosFaltantes)) + rut;
            int[] nums = { 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] CONSTANTES = { 3, 2, 7, 6, 5, 4, 3, 2 };
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = CONSTANTES[i] * Int32.Parse(rut[i].ToString());
            }
            double suma = nums[0] + nums[1] + nums[2] + nums[3] + nums[4] + nums[5] + nums[6] + nums[7];
            double divisiondecimal = suma / 11;
            double divisionentero = (int)divisiondecimal;
            double valordecimal = divisiondecimal - divisionentero;
            double resta11 = 11 - (11 * (valordecimal));
            resta11 = Math.Round(resta11);
            int digito = (int)resta11;
            if (digito == 11) {
                digito = 0;
            }
            int digitoVer;
            if ((rut[9] == 'k') | (rut[9] == 'K')) {
                digitoVer = 10;
            } else {
                digitoVer = Int32.Parse(rut[9].ToString());
            }
            return digito == digitoVer;
        }
        private void TextBoxUsuario_TextChanged(object sender, EventArgs e) {
        }
        private void Label6_Click(object sender, EventArgs e) {
        }
        private void Hora_Click(object sender, EventArgs e) {
        }
        private void Form1_Load(object sender, EventArgs e) {

        }
    }
}
