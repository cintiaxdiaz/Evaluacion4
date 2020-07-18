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

namespace ProyRestMatrizArray
{
    public partial class Form2 : Form
    {   //Declaración de la matriz
        Mesa[,] mesas;
        USUARIO usuario;
        List<CLASEEVALUA2CintiaDiaz> LISTAEVALUA2;
        public Form2(USUARIO usuaform2) {
            LISTAEVALUA2 = new List<CLASEEVALUA2CintiaDiaz>();
            usuario = usuaform2;

            // Inicialización de la matriz
            mesas = new Mesa[3, 5]
                {
                { new Mesa(), new Mesa(), new Mesa(), new Mesa(), new Mesa()},
                { new Mesa(), new Mesa(), new Mesa(), new Mesa(), new Mesa() },
                { new Mesa(), new Mesa(), new Mesa(), new Mesa(), new Mesa() }
                };

            InitializeComponent();
        }
        private void AgregarEvento(string coordenadas) {
            string descripEvento = "seleccionar mesa " + coordenadas;
            CLASEEVALUA2CintiaDiaz evento = new CLASEEVALUA2CintiaDiaz(usuario, descripEvento);
            LISTAEVALUA2.Add(evento);
        }
        private void btnMesa1_Click(object sender, EventArgs e) {

            //Se asignan la mesa al formulario tres
            AgregarEvento("[0;0]");
            Mesa mesita = mesas[0, 0];
            Form formulario = new Form3(mesita, this, usuario, LISTAEVALUA2, "[0;0]");
            formulario.Show();
        }
        private void Horayfecha_Tick(object sender, EventArgs e) {
            hora.Text = DateTime.Now.ToString("HH:mm:ss");
            fecha.Text = DateTime.Now.ToLongDateString();
        }
        private void BtnMesa2_Click(object sender, EventArgs e) {
            AgregarEvento("[0;1]");
            Mesa mesita = mesas[0, 1];
            Form formulario = new Form3(mesita, this, usuario, LISTAEVALUA2, "[0;1]");
            formulario.Show();
        }
        private void Button1_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Desea salir de las mesas?", "Salir", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes) {
                usuario.CERRARSESION();
                StreamWriter archivolista = new StreamWriter(@"C:\TXTS\VIGIACINTIADIAZ.txt", true);

                foreach (CLASEEVALUA2CintiaDiaz Evento in LISTAEVALUA2) {
                    Evento.fin = usuario.finSesion;
                    archivolista.WriteLine(Evento.Rut + "," + Evento.Iniciosesion + "," + Evento.fin +
                                            "," + Evento.accion + "," + Evento.accionf);
                }
                archivolista.Close();
                Form1 formulario1 = new Form1();
                formulario1.Show();
                formulario1.Visible = true;
                Visible = false;
            }
        }
        private void btnMesa3_Click(object sender, EventArgs e) {
            AgregarEvento("[0;2]");
            Mesa mesita = mesas[0, 2];
            Form formulario = new Form3(mesita, this, usuario, LISTAEVALUA2, "[0;2]");
            formulario.Show();
        }
        private void btnMesa4_Click(object sender, EventArgs e) {
            AgregarEvento("[0;3]");
            Mesa mesita = mesas[0, 3];
            Form formulario = new Form3(mesita, this, usuario, LISTAEVALUA2, "[0;3]");
            formulario.Show();
        }
        private void btnMesa5_Click(object sender, EventArgs e) {
            AgregarEvento("[0;4]");
            Mesa mesita = mesas[0, 4];
            Form formulario = new Form3(mesita, this, usuario, LISTAEVALUA2, "[0;4]");
            formulario.Show();
        }
        private void btnMesa6_Click(object sender, EventArgs e) {
            AgregarEvento("[1;0]");
            Mesa mesita = mesas[1, 0];
            Form formulario = new Form3(mesita, this, usuario, LISTAEVALUA2, "[1;0]");
            formulario.Show();
        }
        private void btnMesa7_Click(object sender, EventArgs e) {
            AgregarEvento("[1;1]");
            Mesa mesita = mesas[1, 1];
            Form formulario = new Form3(mesita, this, usuario, LISTAEVALUA2, "[1;1]");
            formulario.Show();
        }
        private void btnMesa8_Click(object sender, EventArgs e) {
            AgregarEvento("[1;2]");
            Mesa mesita = mesas[1, 2];
            Form formulario = new Form3(mesita, this, usuario, LISTAEVALUA2, "[1;2]");
            formulario.Show();
        }
        private void btnMesa9_Click(object sender, EventArgs e) {
            AgregarEvento("[1;3]");
            Mesa mesita = mesas[1, 3];
            Form formulario = new Form3(mesita, this, usuario, LISTAEVALUA2, "[1;3]");
            formulario.Show();
        }
        private void btnMesa10_Click(object sender, EventArgs e) {
            AgregarEvento("[1;4]");
            Mesa mesita = mesas[1, 4];
            Form formulario = new Form3(mesita, this, usuario, LISTAEVALUA2, "[1;4]");
            formulario.Show();
        }
        private void btnMesa11_Click(object sender, EventArgs e) {
            AgregarEvento("[2;0]");
            Mesa mesita = mesas[2, 0];
            Form formulario = new Form3(mesita, this, usuario, LISTAEVALUA2, "[2;0]");
            formulario.Show();
        }
        private void btnMesa12_Click(object sender, EventArgs e) {
            AgregarEvento("[2;1]");
            Mesa mesita = mesas[2, 1];
            Form formulario = new Form3(mesita, this, usuario, LISTAEVALUA2, "[2;1]");
            formulario.Show();
        }
        private void btnMesa13_Click(object sender, EventArgs e) {
            AgregarEvento("[2;2]");
            Mesa mesita = mesas[2, 2];
            Form formulario = new Form3(mesita, this, usuario, LISTAEVALUA2, "[2;2]");
            formulario.Show();
        }
        private void btnMesa14_Click(object sender, EventArgs e) {
            AgregarEvento("[2;3]");
            Mesa mesita = mesas[2, 3];
            Form formulario = new Form3(mesita, this, usuario, LISTAEVALUA2, "[2;3]");
            formulario.Show();
        }
        private void btnMesa15_Click(object sender, EventArgs e) {
            AgregarEvento("[2;4]");
            Mesa mesita = mesas[2, 4];
            Form formulario = new Form3(mesita, this, usuario, LISTAEVALUA2, "[2;4]");
            formulario.Show();
        }
        public void ActualizarDisponible() {
            //Actualiza el estado de las mesas (ocupado/disponible)
            Label[,] labels = new Label[3, 5]
            {
                { labelmesa1, labelmesa2, labelmesa3, labelmesa4, labelmesa5},
                { labelmesa6, labelmesa7, labelmesa8, labelmesa9, labelmesa10 },
                { labelmesa11, labelmesa12, labelmesa13, labelmesa14, labelmesa15}
            };
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 5; j++) {
                    if (mesas[i, j].ocupada) {
                        labels[i, j].ForeColor = Color.Red;
                    } else {
                        labels[i, j].ForeColor = ColorTranslator.FromHtml("#C0ffC0");
                    }
                }
            }
        }
        private void Form2_Load(object sender, EventArgs e) {
            if (!usuario.is_admin()) {

                pERFILESToolStripMenuItem.Enabled = false;
				MessageBox.Show("No posee los privilegios necesarios, para ingresar a Perfiles");
			}
			else
			{
				MessageBox.Show("Eres Administrador");
			}

        }
        
        private void Button4_Click(object sender, EventArgs e) {
           // Form formulario = new Form4();
            //formulario.Show();
        }

        private void PERFILESToolStripMenuItem_Click(object sender, EventArgs e) {
            Form formulario = new FormPerfiles();
            formulario.Show();
        }

        private void ACCIONESToolStripMenuItem_Click(object sender, EventArgs e) {
            Form formulario = new Form6();
            formulario.Show();
        }

        private void CERRARToolStripMenuItem_Click(object sender, EventArgs e) {
            Form formulario = new Form5();
            formulario.Show();
        }
		
    }
}

