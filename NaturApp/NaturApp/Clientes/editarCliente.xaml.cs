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
using System.Collections.ObjectModel;

namespace NaturApp.Clientes
{
    public partial class editarCliente : PhoneApplicationPage
    {
        ObservableCollection<cEstadoCivil> source;
        SQLiteConnection db;
        tablaClientes cliente;

        string idCliente;

        public editarCliente()
        {
            InitializeComponent();

            source = new ObservableCollection<cEstadoCivil>();

            source = new ObservableCollection<cEstadoCivil>();
            source.Add(new cEstadoCivil("Seleccione", "0"));
            source.Add(new cEstadoCivil("Solter@", "1"));
            source.Add(new cEstadoCivil("Casad@", "2"));
            source.Add(new cEstadoCivil("Divorciad@", "3"));
            source.Add(new cEstadoCivil("Viud@", "4"));
            source.Add(new cEstadoCivil("Unión Libre", "5"));

            listPicker.ItemsSource = source;

            db = new SQLiteConnection("naturapp.db");
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("idCliente"))
                idCliente = NavigationContext.QueryString["idCliente"];

            cliente = db.Query<tablaClientes>("SELECT idCliente, nombres, apellidos, direccion, telefono, correo, sexo, fechaNacimiento, estadoCivil from tablaClientes where idCliente like " + "'" + idCliente + "'").FirstOrDefault();

            if (cliente.nombres != null)
                txtNombre.Text = cliente.nombres;
            if (cliente.apellidos != null)
                txtApellidos.Text = cliente.apellidos;
            if (cliente.direccion != null)
                txtDireccion.Text = cliente.direccion;
            if (cliente.telefono != null)
                txtTelefono.Text = cliente.telefono;
            if (cliente.correo != null)
                txtCorreo.Text = cliente.correo;

            if (cliente.sexo != null && cliente.sexo.Equals("F"))
                rdbFemenino.IsChecked = true;

            if (cliente.sexo != null && cliente.sexo.Equals("M"))
                rdbMasculino.IsChecked = true;

            int i = 0;
            foreach (var clienteSource in source)
            {
                if (clienteSource.Nombre.Equals(cliente.estadoCivil))
                {
                    listPicker.SelectedIndex = i;
                    break;
                }
                i++;
            }

            if (cliente.fechaNacimiento != null)
            {
                int dia = Convert.ToInt32(cliente.fechaNacimiento.Substring(0, 2));
                int mes = Convert.ToInt32(cliente.fechaNacimiento.Substring(2, 2));
                int anio = Convert.ToInt32(cliente.fechaNacimiento.Substring(4, 4));

                DateTime miFecha = new DateTime(anio, mes, dia);

                datePicker.Value = miFecha;

            }

            base.OnNavigatedTo(e);
        }

        private void guardar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}