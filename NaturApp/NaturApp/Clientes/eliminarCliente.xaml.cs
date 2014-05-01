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
    public partial class eliminarCliente : PhoneApplicationPage
    {

        SQLiteConnection db;
        IEnumerable<tablaClientes> clientes;
        ObservableCollection<Cliente> arrClientes;
        tablaClientes clienteEliminar;

        public eliminarCliente()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            db = new SQLiteConnection("naturapp.db");

            var count = (from x in db.Table<tablaClientes>() select x.idCliente).Count();
            if (count > 0)
            {
                clientes = db.Query<tablaClientes>("SELECT idCliente, nombres, apellidos, direccion, telefono, correo, sexo, fechaNacimiento, estadoCivil from tablaClientes");

                arrClientes = new ObservableCollection<Cliente>();
                foreach (var cliente in clientes)
                {
                    arrClientes.Add(new Cliente(cliente.idCliente.ToString(), cliente.nombres, cliente.apellidos, cliente.direccion, cliente.telefono, cliente.correo, cliente.sexo, cliente.fechaNacimiento, cliente.estadoCivil));
                }

                listClientes.ItemsSource = arrClientes;
            }
            else
            {
                MessageBox.Show("No hay clientes agregados");
            }

            base.OnNavigatedTo(e);
        }

        private void listClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cliente = listClientes.SelectedItem as Cliente;

            MessageBoxResult resultado = MessageBox.Show("Seguro que deseas eliminar al cliente " + cliente.nombres + " " + cliente.apellidos + " ?", "Confirmación", MessageBoxButton.OKCancel);
            if (resultado == MessageBoxResult.OK)
            {
                clienteEliminar = db.Query<tablaClientes>("SELECT idCliente, nombres, apellidos, direccion, telefono, correo, sexo, fechaNacimiento, estadoCivil FROM tablaClientes WHERE idCliente LIKE " + cliente.id).FirstOrDefault();
                if (clienteEliminar != null)
                {
                    db.RunInTransaction(() =>
                    {
                        db.Delete(clienteEliminar);
                    });
                }

                MessageBoxResult m = MessageBox.Show("Cliente eliminado satisfactoriamente","Confirmación",MessageBoxButton.OK);

                if (m == MessageBoxResult.OK)
                {
                    NavigationService.GoBack();
                }
            }
        }
    }
}