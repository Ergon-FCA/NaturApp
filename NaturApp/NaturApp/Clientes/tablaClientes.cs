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
using SQLite;

namespace NaturApp.Clientes
{
    public class tablaClientes
    {
        [PrimaryKey, AutoIncrement]
        public int idCliente { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string sexo { get; set; }
        public string fechaNacimiento { get; set; }
        public string estadoCivil { get; set; }
    }
}
