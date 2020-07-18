using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace ProyRestMatrizArray
{
    public partial class Form6 : Form
    {
        public Form6() {
            InitializeComponent();
        }
        SqlConnection objeto_conect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cinti\Desktop\Eva4_Programación\EVALUA3CINTIADIAZ\ProyRestMatrizArray\BDDPROG2CINTIADIAZ.mdf;Integrated Security=True");


        private void Button4_Click(object sender, EventArgs e) {
            Visible = false;

        }

        private void Button8_Click(object sender, EventArgs e) {
            if (!File.Exists(@"C:\TXTS\VIGIACINTIADIAZ.txt")) {
                MessageBox.Show("No existe");
                return;
            }

            StreamReader leer = new StreamReader(@"C:\TXTS\VIGIACINTIADIAZ.txt");
            string mostrar = leer.ReadLine();
            while (mostrar != null) {
                objeto_conect.Open();
                DataTable tabla_acciones = new DataTable();
                string[] palabras = mostrar.Split(',');
                string sqlinsertar = "insert into ACCIONESCINTIADIAZ (clave, InicioSesion, FinSesion, Accion, AccionF) values  ('" + palabras[0] + "','" + palabras[1] + "','" + palabras[2] + "','" + palabras[3].Substring(0, Math.Min(50, palabras[3].Length)) + "','" + palabras[4] + "')";
                SqlDataAdapter sentencia = new SqlDataAdapter(sqlinsertar, objeto_conect);
                tabla_acciones.Clear();
                sentencia.Fill(tabla_acciones);
                mostrar = leer.ReadLine();
                objeto_conect.Close();

            }
            leer.Close();
            MessageBox.Show("Traspaso exitoso");

        }

        private void Form6_Load(object sender, EventArgs e) {

        }
    }
}
