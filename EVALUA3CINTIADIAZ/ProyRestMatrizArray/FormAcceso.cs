﻿using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace ProyRestMatrizArray
{
	public partial class Form1 : Form
	{
        SqlConnection objeto_conect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cinti\Desktop\Eva4_Programación\EVALUA3CINTIADIAZ\ProyRestMatrizArray\BDDPROG2CINTIADIAZ.mdf;Integrated Security=True");

        public Form1()
		{// mantiene tamaño del form acceso
			InitializeComponent();
            this.MaximizeBox = false;
            this.ClientSize = new Size(730, 306);
        }
		private void buttonIngresar_Click(object sender, EventArgs e)
		{//valida que el ingreso realizado por rut y clave se encuentren en la bbdd
			objeto_conect.Open();
			DataTable tabla_transito = new DataTable();
			string clave = textBoxClave.Text;
			SqlDataAdapter sentencia = new SqlDataAdapter("select * from PERFILESCINTIADIAZ where clave='" + clave + "' and rut ='" + textBoxRut.Text + "'", objeto_conect);
			tabla_transito.Clear();
			sentencia.Fill(tabla_transito);
			int total = tabla_transito.Rows.Count;
			if (total < 1)
			{
                objeto_conect.Close();
                MessageBox.Show("Clave o usuario inválido");
                return;
			}
            //valida al ingreso si es usuario o administrador
            string rut_tabla = tabla_transito.Rows[0]["rut"].ToString();
            int nivel_tabla = Int32.Parse(tabla_transito.Rows[0]["Nivel"].ToString());
            USUARIO usua = new USUARIO(rut_tabla, nivel_tabla, clave);
		    Form formulario = new FormMesas(usua);
		    formulario.Show();
		    Visible = false;
		    MessageBox.Show("BIENVENIDO, QUE TENGAS UN EXCELENTE DÍA!");
			objeto_conect.Close();
		}

		private void Horayfecha_Tick(object sender, EventArgs e)
		{
			// Indica la hora y la fecha en tiempo real
			hora.Text = DateTime.Now.ToString("HH:mm:ss");
			fecha.Text = DateTime.Now.ToLongDateString();
		}
		private bool rutValido(string rut)
		{//valida el digito verificador sea correcto 

			Regex rgx = new Regex(@"^\d{1,8}-(?:\d|k|K)$");
			if (!rgx.IsMatch(rut))
			{
				MessageBox.Show("Rut con formato inválido");
				return false;
			}
			int RUT_NUM_CHARS = 10;
			rut = rut.Replace(".", "");
			if ((rut.Length < 3) | rut[rut.Length - 2] != '-')
			{
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
			if (digito == 11)
			{
				digito = 0;
			}
			int digitoVer;
			if ((rut[9] == 'k') | (rut[9] == 'K'))
			{
				digitoVer = 10;
			}
			else
			{
				digitoVer = Int32.Parse(rut[9].ToString());
			}
			return digito == digitoVer;
  		}

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		//cierra programa apesar de que el fromulario inicio sigue activo
		{
			Application.Exit();
        }
    }
}
		
    
	

