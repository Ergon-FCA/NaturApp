using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace NaturApp.Clientes
{
    public class Cliente
    {
        public string id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string sexo { get; set; }
        public string fechaNacimiento { get; set; }
        public string estadoCivil { get; set; }

        public Cliente(string id, string nombres, string apellidos, string direccion, string telefono, string correo, string sexo, string fechaNacimiento, string estado)
        {
            this.id = id;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.direccion = direccion;
            this.telefono = telefono;
            this.correo = correo;
            this.sexo = sexo;
            this.fechaNacimiento = fechaNacimiento;
            this.estadoCivil = estado;
        }
    }
}
