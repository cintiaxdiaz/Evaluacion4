using System.Configuration;
using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace ProyRestMatrizArray
{
    public partial class FormPerfiles : Form {
        public FormPerfiles() {
            InitializeComponent();
        }
        //conexión a bdd

        //CONECTANDO A BD USANDO LA CONFIGURACION EN EL ARCHIVO App.config
       // SqlConnection objeto_conect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\basesLeones\BDDPROG2CINTIADIAZ.mdf;Integrated Security=True;Connect Timeout=30");
        SqlConnection objeto_conect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\joseluisduran\source\repos\Evaluacion4\EVALUA3CINTIADIAZ\ProyRestMatrizArray\BDDPROG2CINTIADIAZ.mdf;Integrated Security=True;Connect Timeout=30");
        //SqlConnection objeto_conect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cinti\Desktop\Eva4_Programación\EVALUA3CINTIADIAZ\ProyRestMatrizArray\BDDPROG2CINTIADIAZ.mdf;Integrated Security=True");
        //SqlConnection objeto_conect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pablosotosaavedra\source\repos\Evaluacion4\EVALUA3CINTIADIAZ\ProyRestMatrizArray\BDDPROG2CINTIADIAZ.mdf;Integrated Security=True");

        private void Button1_Click(object sender, EventArgs e) {
            Visible = false;
        }
       //valida si esta registrado en la bbdd
        private void Button4_Click(object sender, EventArgs e) {
            objeto_conect.Open();
            DataTable tabla_transito = new DataTable();
            SqlDataAdapter sentencia1 = new SqlDataAdapter("select * from PERFILESCINTIADIAZ where rut ='" + textBox2.Text + "'", objeto_conect);
            tabla_transito.Clear();
            sentencia1.Fill(tabla_transito);
            objeto_conect.Close();

            int total = tabla_transito.Rows.Count;
            if (total >= 1) {
                MessageBox.Show("Usuario ya registrado");
                return;
            }
			//agrega el nuevo usuario en la bbdd
            if (rutValido(textBox2.Text)) {
                objeto_conect.Open();
                DataTable tabla_perfiles = new DataTable();
                string clav = textBox3.Text.Substring(0, 1) + textBox4.Text.Substring(0, 1) + textBox5.Text.Substring(0, 1) + textBox2.Text;
                string sqlinsertar = "insert into PERFILESCINTIADIAZ (rut,nombre,ApPat,ApMat,clave,Nivel) values  ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + clav + "'," + comboBox1.SelectedItem + ")";
                SqlDataAdapter sentencia = new SqlDataAdapter(sqlinsertar, objeto_conect);
                tabla_perfiles.Clear();
                sentencia.Fill(tabla_perfiles);
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                comboBox1.Text = null;
				//muestra la actualizacion en el datagrid
                DataTable tabla_PERFILES = new DataTable();
                sentencia = new SqlDataAdapter("select * from PERFILESCINTIADIAZ", objeto_conect);
                tabla_PERFILES.Clear();
                sentencia.Fill(tabla_PERFILES);
                dataGridView1.DataSource = tabla_PERFILES;
                objeto_conect.Close();
                MessageBox.Show("RUT válido, datos agregados exitosamente");
            } else {
                MessageBox.Show("RUT inválido");
            }
        }
		//valida el digito verificador del rut
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


		private void Button10_Click(object sender, EventArgs e)
		{//muestra en los textbox y elimina segun la clave de la bbdd
			objeto_conect.Open();
			DataTable tabla_transito = new DataTable();
			string clave = textBox1.Text;
			SqlDataAdapter sentencia = new SqlDataAdapter
			("select * from PERFILESCINTIADIAZ where clave='" + clave + "'", objeto_conect);
			sentencia.Fill(tabla_transito);

			int total = tabla_transito.Rows.Count;
			if (total < 1)
			{
				MessageBox.Show("La Clave Ingresada NO EXISTE!!!");
				objeto_conect.Close();
			}
			else
			{
				for (int i = 0; i < total; i++)
				{
					textBox2.Text = tabla_transito.Rows[i]["rut"].ToString();
					textBox3.Text = tabla_transito.Rows[i]["nombre"].ToString();
					textBox4.Text = tabla_transito.Rows[i]["ApPat"].ToString();
					textBox5.Text = tabla_transito.Rows[i]["ApMat"].ToString();
					comboBox1.Text = tabla_transito.Rows[i]["Nivel"].ToString();
				}

				MessageBox.Show("Datos encontrados, mostrados en Texbox y eliminados!!!");
				SqlDataAdapter sentencia2 = new SqlDataAdapter
				("delete from PERFILESCINTIADIAZ where clave='" + clave + "'", objeto_conect);
				tabla_transito.Clear();
				sentencia2.Fill(tabla_transito);

                //actualiza datagridview
                DataTable tabla_PERFILES = new DataTable();
                sentencia = new SqlDataAdapter("select * from PERFILESCINTIADIAZ", objeto_conect);
                tabla_PERFILES.Clear();
                sentencia.Fill(tabla_PERFILES);
                dataGridView1.DataSource = tabla_PERFILES;
                objeto_conect.Close();
			}
		}

		private void button2_Click_2(object sender, EventArgs e)
		{
			//Búsqueda por apellido paterno con un textbox
			objeto_conect.Open();
			DataTable tabla_PERFILES = new DataTable();
			SqlDataAdapter sentencia = new SqlDataAdapter("select * from PERFILESCINTIADIAZ where ApPat like '%" + textBox6.Text + "%'", objeto_conect);
			tabla_PERFILES.Clear();
			sentencia.Fill(tabla_PERFILES);
			dataGridView1.DataSource = tabla_PERFILES;
			objeto_conect.Close();
		}
		
        private void Form4_Load(object sender, EventArgs e) {
			//muestra al cargar el formulario
            objeto_conect.Open();
            DataTable tabla_PERFILES = new DataTable();
            SqlDataAdapter sentencia = new SqlDataAdapter("select * from PERFILESCINTIADIAZ", objeto_conect);
            tabla_PERFILES.Clear();
            sentencia.Fill(tabla_PERFILES);
            dataGridView1.DataSource = tabla_PERFILES;
            objeto_conect.Close();
            //codigos para que el combo box solo utilice valores cargados de la lista 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button5_Click_1(object sender, EventArgs e)
		{//muestra datos en los textbox por clave ingresada 
			{
                objeto_conect.Open();
                DataTable tabla_transito = new DataTable();

                string rut = textBox1.Text;
                SqlDataAdapter sentencia = new SqlDataAdapter
                ("select * from PERFILESCINTIADIAZ where clave='" + rut + "'", objeto_conect);

                tabla_transito.Clear();
                sentencia.Fill(tabla_transito);

                int total = tabla_transito.Rows.Count;
                if (total < 1)
                {
                    MessageBox.Show("La Clave Ingresada NO EXISTE!!!");
                    objeto_conect.Close();
                }
                else
                {
                    for (int i = 0; i < total; i++)
                    {
                        textBox2.Text = tabla_transito.Rows[i]["rut"].ToString();
                        textBox3.Text = tabla_transito.Rows[i]["nombre"].ToString();
                        textBox4.Text = tabla_transito.Rows[i]["ApPat"].ToString();
                        textBox5.Text = tabla_transito.Rows[i]["ApMat"].ToString();
                        comboBox1.Text = tabla_transito.Rows[i]["Nivel"].ToString();
                    }
                    MessageBox.Show("Datos encontrados y mostrados en Texbox!!!");
                    objeto_conect.Close();
                }
            }
        }

		private void button3_Click(object sender, EventArgs e)
		{
			//Búsqueda por apellido paterno con un textbox clave
			objeto_conect.Open();
			DataTable tabla_PERFILES = new DataTable();
			SqlDataAdapter sentencia = new SqlDataAdapter("select * from PERFILESCINTIADIAZ where clave like '" + textBox1.Text + "'", objeto_conect);
			tabla_PERFILES.Clear();
			sentencia.Fill(tabla_PERFILES);
			dataGridView1.DataSource = tabla_PERFILES;
			objeto_conect.Close();
		}

        private void button6_Click(object sender, EventArgs e) {
            //Actualizacion (modifica valores) de datos a partir de los textbox
            objeto_conect.Open();
            DataTable tabla_PERFILES = new DataTable();
            string clav = textBox3.Text.Substring(0, 1) + textBox4.Text.Substring(0, 1) + textBox5.Text.Substring(0, 1) + textBox2.Text;
            SqlDataAdapter sentencia = new SqlDataAdapter("update PERFILESCINTIADIAZ set nombre ='" + textBox3.Text + "', ApPat ='" + textBox4.Text + "', ApMat ='" + textBox5.Text + "', clave ='" + clav + "', Nivel ='" + comboBox1.Text + "' where rut='" + textBox2.Text + "'; select * from PERFILESCINTIADIAZ;", objeto_conect);
            tabla_PERFILES.Clear();
            sentencia.Fill(tabla_PERFILES);
            dataGridView1.DataSource = tabla_PERFILES;
            objeto_conect.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = null;
        }
    }
}
    