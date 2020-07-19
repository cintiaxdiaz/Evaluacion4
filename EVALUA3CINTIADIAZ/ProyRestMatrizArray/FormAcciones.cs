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
    public partial class FormAcciones : Form
    {
        public FormAcciones() {
            InitializeComponent();
        }
		SqlConnection objeto_conect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\joseluisduran\source\repos\Evaluacion4\EVALUA3CINTIADIAZ\ProyRestMatrizArray\BDDPROG2CINTIADIAZ.mdf;Integrated Security=True;Connect Timeout=30");
		//SqlConnection objeto_conect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cinti\Desktop\Eva4_Programación\EVALUA3CINTIADIAZ\ProyRestMatrizArray\BDDPROG2CINTIADIAZ.mdf;Integrated Security=True");


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

		private void FormAcciones_Load(object sender, EventArgs e)
		{
			//muestra al cargar el formulario
			objeto_conect.Open();
			DataTable tabla_PERFILES = new DataTable();
			SqlDataAdapter sentencia = new SqlDataAdapter("select * from ACCIONESCINTIADIAZ ", objeto_conect);
			tabla_PERFILES.Clear();
			sentencia.Fill(tabla_PERFILES);
			dataGridView1.DataSource = tabla_PERFILES;
			objeto_conect.Close();
		}
	}
}
