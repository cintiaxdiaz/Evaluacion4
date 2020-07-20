using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace ProyRestMatrizArray
{
    public partial class FormAcciones : Form
    {
        USUARIO usuario;

        public FormAcciones() {
            InitializeComponent();
        }
		SqlConnection objeto_conect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cinti\Desktop\Eva4_Programación\EVALUA3CINTIADIAZ\ProyRestMatrizArray\BDDPROG2CINTIADIAZ.mdf;Integrated Security=True");

        public FormAcciones(USUARIO usuaform6) {
            InitializeComponent();
            usuario = usuaform6;
        }

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
            string query = "select * from ACCIONESCINTIADIAZ";
            if (!usuario.is_admin()) {
                query += " where clave = '" + usuario.clave + "'";
            }

            //muestra al cargar el formulario
            objeto_conect.Open();
			DataTable tabla_PERFILES = new DataTable();
			SqlDataAdapter sentencia = new SqlDataAdapter(query, objeto_conect);
			tabla_PERFILES.Clear();
			sentencia.Fill(tabla_PERFILES);
			dataGridView1.DataSource = tabla_PERFILES;
			objeto_conect.Close();
		}

        private void Button2_Click(object sender, EventArgs e) {
            string fecha_desde = dateTimePicker1.Value.ToString("yyyy-MM-dd") + "T00:00:00";
            string query = "select * from ACCIONESCINTIADIAZ where AccionF >= '" + fecha_desde + "'";
            if (checkBox1.Checked) {
                string fecha_hasta = dateTimePicker2.Value.ToString("yyyy-MM-dd") + "T23:59:59";
                query += " and AccionF <= '" + fecha_hasta +"'";
            }
            if (!usuario.is_admin()) {
                query += " and clave = '" + usuario.clave + "'";
            }

            // MOSTRAR
            objeto_conect.Open();
            DataTable tabla_PERFILES = new DataTable();
            SqlDataAdapter sentencia = new SqlDataAdapter(query, objeto_conect);
            
            tabla_PERFILES.Clear();
            sentencia.Fill(tabla_PERFILES);
            dataGridView1.DataSource = tabla_PERFILES;
            objeto_conect.Close();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e) {
            dateTimePicker2.Enabled = !dateTimePicker2.Enabled;

        }
    }
}
