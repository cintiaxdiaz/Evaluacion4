using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyRestMatrizArray
{
    //EVENTO
    public class CLASEEVALUA2CintiaDiaz
    {
        private string rut;
        private DateTime inicioSesion;
        private DateTime finSesion;
        private string Accion;
        private DateTime AccionF;

        public CLASEEVALUA2CintiaDiaz(USUARIO user, string Acciones) {
            rut = user.rut;
            inicioSesion = user.inicioSesion;
            Accion = Acciones;
            AccionF = DateTime.Now;

        }
        public string Rut {
            set { rut = value; }
            get { return rut; }
        }
        public DateTime Iniciosesion {
            set { inicioSesion = value; }
            get { return inicioSesion; }
        }
        public DateTime fin {
            set { finSesion = value; }
            get { return finSesion; }
        }
        public string accion {
            set { Accion = value; }
            get { return Accion; }
        }
        public DateTime accionf {
            set { AccionF = value; }
            get { return AccionF; }
        }
    }
}
