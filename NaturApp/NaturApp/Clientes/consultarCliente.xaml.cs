using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using SQLite;

namespace NaturApp.Clientes
{
    public partial class consultarCliente : PhoneApplicationPage
    {
        SQLiteConnection db;
        IEnumerable<tablaClientes> clientes;

        public consultarCliente()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            db = new SQLiteConnection("naturapp.db");

            var count = (from x in db.Table<tablaClientes>() select x.idCliente).Count();
            if (count > 0)
            {
                clientes = db.Query<tablaClientes>("SELECT nombres, apellidos, direccion, telefono, correo, sexo, fechaNacimiento, estadoCivil from tablaClientes");
                listClientes.ItemsSource = clientes;
            }
            base.OnNavigatedTo(e);
        }
    }
}