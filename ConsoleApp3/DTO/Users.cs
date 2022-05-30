using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.DTO
{
    class Users
    {
        private string rut;
        private string nombre;
        private string ap_paterno;
        private string ap_materno;
        private string mail;
        private string usuario;
        private string clave;
        private int estado;

        public Users(string rut, string nombre, string ap_paterno, string ap_materno, string mail, string usuario, string clave, int estado)
        {
            this.rut = rut;
            this.nombre = nombre;
            this.ap_paterno = ap_paterno;
            this.ap_materno = ap_materno;
            this.mail = mail;
            this.usuario = usuario;
            this.clave = clave;
            this.estado = estado;
        }
        public Users()
        {
            
        }

        public string Rut { get => rut; set => rut = value; }
        public string Nombre { get => nombre; set => nombre = value;}
        public string Ap_paterno { get => ap_paterno; set => ap_paterno = value; }
        public string Ap_materno { get => ap_materno; set => ap_materno = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Clave { get => clave; set => clave = value; }
        public int Estado { get => estado; set => estado = value; }

        public override string ToString()
        {
            return this.rut + ";" + this.nombre + ";" + this.ap_paterno + ";" + this.ap_materno + ";" + this.mail + ";" + this.usuario + ";" + this.clave + ";" + this.estado;
        }
    }

}
