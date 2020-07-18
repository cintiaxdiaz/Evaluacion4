using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyRestMatrizArray
{
    public partial class FormPedidos : Form
    {
        //Un arreglo de las comidas
        Mesa mesa;
        FormMesas form2;
        USUARIO usuaform3;
        List <CLASEEVALUA2CintiaDiaz> LISTAEVALUA2;
        string coordenadas;
        string[] comidas = new string[15] 
        {
            "Espagueti a la boloñesa", "Espagueti a la cherry", "Espagueti con salsa blanca",
            "Lasaña", "Hamburguesa de la casa", "Hot dog CIJOSE", "Papas fritas", "Agua", "Coca-cola",
            "Fanta", "Limonada frapp","Cerveza", "Pisco", "Mojito", "Cuba libre"
        };
        public FormPedidos() {
            InitializeComponent();
        }
        private void AgregarEvento(string descripEvento) {
            CLASEEVALUA2CintiaDiaz evento = new CLASEEVALUA2CintiaDiaz(usuaform3, descripEvento);
            LISTAEVALUA2.Add(evento);
        }
        public FormPedidos(Mesa table, FormMesas form_2, USUARIO USUA3, List<CLASEEVALUA2CintiaDiaz> listformtres, string coordenadas1) {
            LISTAEVALUA2 = listformtres;
            usuaform3 = USUA3;
            coordenadas = coordenadas1;
            mesa = table;
            form2 = form_2;
            InitializeComponent();

            //Agrega los pedidos a la mesa
            for (int i = 0; i < comidas.Length; i++) {
                if (mesa.pedidos[i] == 0) {
                    continue;
                }
                Orden.Items.Add(mesa.pedidos[i] + "  " + comidas[i]);
            }
        }
        private void Button8_Click(object sender, EventArgs e) {
            Orden.Items.Clear();

            //Sirve para insertar la cantidad de comidas en una orden
            NumericUpDown[] cantidadComidas = new NumericUpDown[15]
            {
                numericUpDown1, numericUpDown2, numericUpDown3,
                numericUpDown4, numericUpDown5, numericUpDown6,
                numericUpDown7, numericUpDown8, numericUpDown9,
                numericUpDown10, numericUpDown11, numericUpDown12,
                numericUpDown13,numericUpDown14, numericUpDown15
            };
            string eventostring = "Se agregó ";
            for (int i = 0; i < comidas.Length; i++) {
                decimal total1 = mesa.pedidos[i] + (int)cantidadComidas[i].Value;
                if (total1 == 0) {
                    continue;
                }
                //MAGIA
                mesa.pedidos[i] = (int) total1;
                mesa.Ocupar();
                Orden.Items.Add(total1 + "  " + comidas[i]);
                eventostring = eventostring + cantidadComidas[i].Value + "  " + comidas[i] + " ";
                cantidadComidas[i].Value = 0;
            }
            eventostring = eventostring + "En la mesa " + coordenadas;
            AgregarEvento(eventostring);
            MessageBox.Show("Recepcionado en Cocina");
        }
        private void Button7_Click(object sender, EventArgs e) {
            form2.ActualizarDisponible();
            string eventostring = "Se actualizó la mesa " + coordenadas;
            AgregarEvento(eventostring);   
            Visible = false;
        }
        
        private void Button2_Click(object sender, EventArgs e) {
            string eventostring = "Se eliminó ";
            if (MessageBox.Show("Estas Seguro?", "ELIMINAR", MessageBoxButtons.YesNo,
              MessageBoxIcon.Question) == DialogResult.No) {
                return;
            }
            Orden.Items.Clear();
            NumericUpDown[] cantidadComidas = new NumericUpDown[15]
            {
                numericUpDown1, numericUpDown2, numericUpDown3,
                numericUpDown4, numericUpDown5, numericUpDown6,
                numericUpDown7, numericUpDown8, numericUpDown9,
                numericUpDown10, numericUpDown11, numericUpDown12,
                numericUpDown13,numericUpDown14, numericUpDown15
            };

                // Elimina algún producto de la orden      
            for (int i = 0; i < comidas.Length; i++) {
                decimal total = mesa.pedidos[i] - cantidadComidas[i].Value;
                if (total < 0) {
                    MessageBox.Show("Producto no fue solicitado");
                    return;
                }
                mesa.pedidos[i] = (int)total;
                eventostring = eventostring + cantidadComidas[i].Value + "  " + comidas[i] + " ";
                if (total == 0) {
                    continue;
                }
                Orden.Items.Add(total + "  " + comidas[i]);
                cantidadComidas[i].Value = 0;
            }
            eventostring = eventostring + "En la mesa " + coordenadas;
            AgregarEvento(eventostring);
        }
        
    }
  }


