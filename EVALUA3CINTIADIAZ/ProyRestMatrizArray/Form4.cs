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


namespace ProyRestMatrizArray
{
    public partial class Form4 : Form
    {
        public Form4() {
            InitializeComponent();
        }
        //conexión a bdd

        //CONECTANDO A BD USANDO LA CONFIGURACION EN EL ARCHIVO App.config
        SqlConnection objeto_conect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\baseLeones\BDDPROG2CINTIADIAZ.mdf;Integrated Security=True;Connect Timeout=30");
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
        private void Button1_Click(object sender, EventArgs e) { 
            Visible = false;
        }
        private void Form4_Load(object sender, EventArgs e) {
        }
        private void TextBox1_TextChanged(object sender, EventArgs e) {
        }
        private void Button3_Click(object sender, EventArgs e) {
            if (!File.Exists(@"C:\TXTS\VIGIACINTIADIAZ.txt")) {
                MessageBox.Show("No existe");
            }
            StreamReader leer = new StreamReader(@"C:\TXTS\VIGIACINTIADIAZ.txt");
            label1.Text = "";
            string buscar = leer.ReadLine();
            while (buscar != null) {
                string[] busca = buscar.Split(',');
                if (busca[0].Equals(textBox1.Text)) {
                    label1.Text = label1.Text + buscar + "\n";
                }
                buscar = leer.ReadLine();
            }
            leer.Close();
        }
        private void Label4_Click(object sender, EventArgs e) {
        }
        private void Label7_Click(object sender, EventArgs e) {
        }
        private void Button4_Click(object sender, EventArgs e) {
            //insertar datos en la bdd por textbox
            objeto_conect.Open();
            DataTable tabla_perfiles = new DataTable();
            string clav = textBox3.Text.Substring(0, 1) + textBox4.Text.Substring(0,1) + textBox5.Text.Substring(0,1) + textBox2.Text;
            string sqlinsertar = "insert into PERFILESCINTIADIAZ (rut,nombre,ApPat,ApMat,clave,Nivel) values  ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + clav + "'," + comboBox1.SelectedIndex + ")";
            MessageBox.Show(sqlinsertar);
            SqlDataAdapter sentencia = new SqlDataAdapter(sqlinsertar, objeto_conect);
            tabla_perfiles.Clear();
            sentencia.Fill(tabla_perfiles);
            objeto_conect.Close();
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
        private void Button6_Click(object sender, EventArgs e) {
            //Búsqueda por apellido paterno con un textbox
            objeto_conect.Open();
            DataTable tabla_PERFILES = new DataTable();
            string apellido = textBox6.Text;
            SqlDataAdapter sentencia = new SqlDataAdapter("select * from PERFILESCINTIADIAZ where ApPat='" + apellido +"'" ,  objeto_conect);
            tabla_PERFILES.Clear();
            sentencia.Fill(tabla_PERFILES);
            dataGridView1.DataSource = tabla_PERFILES;
            objeto_conect.Close(); 
        }
        private void Label7_Click_1(object sender, EventArgs e) {
        }
        private void Button7_Click(object sender, EventArgs e) {
            //elimina por campo clave
            objeto_conect.Open();
            DataTable tabla_PERFILES = new DataTable();
            string claves = textBox7.Text;
            SqlDataAdapter sentencia = new SqlDataAdapter("delete from PERFILESCINTIADIAZ where clave='" + claves + "'", objeto_conect);
            MessageBox.Show("Eliminado");
            tabla_PERFILES.Clear();
            sentencia.Fill(tabla_PERFILES);
            objeto_conect.Close();
        }

        private void Button8_Click(object sender, EventArgs e) {
            if (!File.Exists(@"C:\TXTS\VIGIACINTIADIAZ.txt")) {
                MessageBox.Show("No existe");
                return;

            }
            objeto_conect.Open();
            DataTable tabla_acciones = new DataTable();
            
            StreamReader leer = new StreamReader(@"C:\TXTS\VIGIACINTIADIAZ.txt");
            label1.Text = "";
            string mostrar = leer.ReadLine();
            while (mostrar != null) {
                string[] palabras = mostrar.Split(',');
                mostrar = leer.ReadLine();
                string sqlinsertar = "insert into ACCIONESCINTIADIAZ (clave, InicioSesion, FinSesion, Accion, AccionF) values  ('"  + palabras[0] + "','" + palabras[1] + "','" + palabras[2] + "','" + palabras[3].Substring(0, Math.Min(50,palabras[3].Length)) + "','" + palabras[4] + "')";
                SqlDataAdapter sentencia = new SqlDataAdapter(sqlinsertar, objeto_conect);
                tabla_acciones.Clear();
                sentencia.Fill(tabla_acciones);
            }
            leer.Close();
            MessageBox.Show("Traspaso exitoso");
            objeto_conect.Close();
        }

        private void Button9_Click(object sender, EventArgs e) {
            if (!File.Exists(@"C:\TXTS\VIGIACINTIADIAZ.txt")) {
                MessageBox.Show("No existe");
                return;
            }

            objeto_conect.Open();
            DataTable tabla_acciones = new DataTable();
            StreamReader leer = new StreamReader(@"C:\TXTS\VIGIACINTIADIAZ.txt");
            label1.Text = "";
            string mostrar = leer.ReadLine();
            while (mostrar != null) {
                string[] palabras = mostrar.Split(',');
                mostrar = leer.ReadLine();
                if (palabras[0] != textBox8.Text) {
                    continue; 
                }
                string sqlinsertar = "insert into ACCIONESCINTIADIAZ (clave, InicioSesion, FinSesion, Accion, AccionF) values  ('" + palabras[0] + "','" + palabras[1] + "','" + palabras[2] + "','" + palabras[3].Substring(0, Math.Min(50, palabras[3].Length)) + "','" + palabras[4] + "')";
                SqlDataAdapter sentencia = new SqlDataAdapter(sqlinsertar, objeto_conect);
                tabla_acciones.Clear();
                sentencia.Fill(tabla_acciones);
            }
            leer.Close();
            MessageBox.Show("busqueda de traspaso exitosa");
            objeto_conect.Close();

        }

        private void GroupBox2_Enter(object sender, EventArgs e) {

        }
    }
    }

