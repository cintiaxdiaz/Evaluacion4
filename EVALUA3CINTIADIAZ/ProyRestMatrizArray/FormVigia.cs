using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace ProyRestMatrizArray
{
    public partial class FormVigia : Form
    {
        public FormVigia() {
            InitializeComponent();
        }
		//SqlConnection objeto_conect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cinti\Desktop\Eva4_Programación\EVALUA3CINTIADIAZ\ProyRestMatrizArray\BDDPROG2CINTIADIAZ.mdf;Integrated Security=True");
		SqlConnection objeto_conect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\joseluisduran\source\repos\Evaluacion4\EVALUA3CINTIADIAZ\ProyRestMatrizArray\BDDPROG2CINTIADIAZ.mdf;Integrated Security=True;Connect Timeout=30");
		//
		private void Button3_Click(object sender, EventArgs e) {
            if (!File.Exists(@"C:\TXTS\VIGIACINTIADIAZ.txt")) {
                MessageBox.Show("No existe");
            }
            StreamReader leer = new StreamReader(@"C:\TXTS\VIGIACINTIADIAZ.txt");
            label1.Text = "";
            string buscar = leer.ReadLine();
            while (buscar != null) {
                string[] busca = buscar.Split(',');
                if (busca[0].Contains(textBox1.Text)) {
                    label1.Text = label1.Text + buscar + "\n";
                }
                buscar = leer.ReadLine();
            }
            leer.Close();
    }//muestra todo lo del txt vigia en el data grid
        private void Button2_Click(object sender, EventArgs e) {
            if (!File.Exists(@"C:\TXTS\VIGIACINTIADIAZ.txt")) {
                MessageBox.Show("No existe");
                return;
            }
            StreamReader leer = new StreamReader(@"C:\TXTS\VIGIACINTIADIAZ.txt");
            label1.Text = "";
            string mostrar = leer.ReadLine();
            while (mostrar != null) {
                label1.Text = label1.Text + mostrar + "\n";
                mostrar = leer.ReadLine();
            }
            leer.Close();
        }

        private void Button9_Click(object sender, EventArgs e) {
            if (!File.Exists(@"C:\TXTS\VIGIACINTIADIAZ.txt")) {
                MessageBox.Show("No existe");
                return;
            }

            StreamReader leer = new StreamReader(@"C:\TXTS\VIGIACINTIADIAZ.txt");
            label1.Text = "";
            string mostrar = leer.ReadLine();
            objeto_conect.Open();
            while (mostrar != null) {
                string[] palabras = mostrar.Split(',');
                mostrar = leer.ReadLine();
                if (palabras[0].Contains(textBox8.Text)) {
                    continue;
                }
                DataTable tabla_acciones = new DataTable();
                string sqlinsertar = "insert into ACCIONESCINTIADIAZ (clave, InicioSesion, FinSesion, Accion, AccionF) values  ('" + palabras[0] + "','" + palabras[1] + "','" + palabras[2] + "','" + palabras[3].Substring(0, Math.Min(50, palabras[3].Length)) + "','" + palabras[4] + "')";
                SqlDataAdapter sentencia = new SqlDataAdapter(sqlinsertar, objeto_conect);
                tabla_acciones.Clear();
                sentencia.Fill(tabla_acciones);
            }
            leer.Close();
            MessageBox.Show("Búsqueda de traspaso exitosa");
            objeto_conect.Close();
        }

        private void Button8_Click(object sender, EventArgs e) {
            if (!File.Exists(@"C:\TXTS\VIGIACINTIADIAZ.txt")) {
                MessageBox.Show("No existe");
                return;
            }
            
            StreamReader leer = new StreamReader(@"C:\TXTS\VIGIACINTIADIAZ.txt");
            label1.Text = "";
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

        private void Button4_Click(object sender, EventArgs e) {
            Visible = false;
        }
    }
}
