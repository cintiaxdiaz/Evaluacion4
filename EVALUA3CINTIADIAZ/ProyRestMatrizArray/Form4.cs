using System.Configuration;
using System.Collections.Specialized;
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
    public partial class Form4 : Form {
        public Form4() {
            InitializeComponent();
        }
		//conexión a bdd

		//CONECTANDO A BD USANDO LA CONFIGURACION EN EL ARCHIVO App.config
		SqlConnection objeto_conect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\joseluisduran\source\repos\Evaluacion4\EVALUA3CINTIADIAZ\ProyRestMatrizArray\BDDPROG2CINTIADIAZ.mdf;Integrated Security=True;Connect Timeout=30");
		// SqlConnection objeto_conect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\baseLeones\BDDPROG2CINTIADIAZ.mdf;Integrated Security=True;Connect Timeout=30");
		private void Button2_Click(object sender, EventArgs e) {
         
        }
        private void Button1_Click(object sender, EventArgs e) {
            Visible = false;
        }
       
        private void Button4_Click(object sender, EventArgs e) {
            if (rutValido(textBox2.Text)) {
                objeto_conect.Open();
                DataTable tabla_perfiles = new DataTable();
                string clav = textBox3.Text.Substring(0, 1) + textBox4.Text.Substring(0, 1) + textBox5.Text.Substring(0, 1) + textBox2.Text;
                string sqlinsertar = "insert into PERFILESCINTIADIAZ (rut,nombre,ApPat,ApMat,clave,Nivel) values  ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + clav + "'," + comboBox1.SelectedIndex + ")";
			
				MessageBox.Show(sqlinsertar);
                SqlDataAdapter sentencia = new SqlDataAdapter(sqlinsertar, objeto_conect);
                tabla_perfiles.Clear();
                sentencia.Fill(tabla_perfiles);
                objeto_conect.Close();
                MessageBox.Show("Rut Valido, datos agregados exitosamente");
            } else {
                MessageBox.Show("Rut Invalido");
            }
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
            for (int i = 0; i < nums.Length; i++) {
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
        private void Button5_Click(object sender, EventArgs e) {
            //Muestra lo que está en la base de datos en el datagridview
            objeto_conect.Open();
            DataTable tabla_PERFILES = new DataTable();
            SqlDataAdapter sentencia = new SqlDataAdapter("select * from PERFILESCINTIADIAZ", objeto_conect);
            tabla_PERFILES.Clear();
            sentencia.Fill(tabla_PERFILES);
            dataGridView1.DataSource = tabla_PERFILES;
            objeto_conect.Close();
        }


        private void Button10_Click(object sender, EventArgs e) {
           //elimina por campo clave
          objeto_conect.Open();
          DataTable tabla_PERFILES = new DataTable();
          string claves = textBox1.Text;
          SqlDataAdapter sentencia = new SqlDataAdapter("delete from PERFILESCINTIADIAZ where clave='" + claves + "'", objeto_conect);
          MessageBox.Show("Eliminado");
          tabla_PERFILES.Clear();
          sentencia.Fill(tabla_PERFILES);
		  objeto_conect.Close();
        }

		private void button2_Click_1(object sender, EventArgs e)
		{
			objeto_conect.Open();
			DataTable tabla_PERFILES = new DataTable();
			SqlDataAdapter sentencia = new SqlDataAdapter("select * from PERFILESCINTIADIAZ where clave like '%" + textBox1.Text + "%'", objeto_conect);
			tabla_PERFILES.Clear();
			sentencia.Fill(tabla_PERFILES);
			dataGridView1.DataSource = tabla_PERFILES;
			objeto_conect.Close();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			objeto_conect.Open();
			DataTable tabla_PERFILES = new DataTable();
			SqlDataAdapter sentencia = new SqlDataAdapter("select * from PERFILESCINTIADIAZ where clave like '%" + textBox1.Text + "%'", objeto_conect);
			tabla_PERFILES.Clear();
			sentencia.Fill(tabla_PERFILES);
			dataGridView1.DataSource = tabla_PERFILES;
			objeto_conect.Close();
		}

		private void button2_Click_2(object sender, EventArgs e)
		{
			//Búsqueda por apellido paterno con un textbox
			objeto_conect.Open();
			DataTable tabla_PERFILES = new DataTable();
			SqlDataAdapter sentencia = new SqlDataAdapter("select * from PERFILESCINTIADIAZ where ApPat like '%" + textBox4.Text + "%'", objeto_conect);
			tabla_PERFILES.Clear();
			sentencia.Fill(tabla_PERFILES);
			dataGridView1.DataSource = tabla_PERFILES;
			objeto_conect.Close();
		}
	}
}
    