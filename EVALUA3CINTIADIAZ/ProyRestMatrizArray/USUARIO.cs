using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyRestMatrizArray
{
    public class USUARIO {
        public string rut;
        public int nivel;
        public DateTime inicioSesion;
        public DateTime finSesion;

        public USUARIO(string Rut, int Nivel) {
            rut = Rut;
            nivel = Nivel;
            inicioSesion = DateTime.Now;

        }
        public USUARIO(string Rut) {
            rut = Rut;
            inicioSesion = DateTime.Now;
        }
        public void CERRARSESION(){

            finSesion = DateTime.Now;


            }
        public bool is_admin() {

            return nivel == 1;

        }
    }
}