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
using NaturApp.Clientes;
using NaturApp.Pedidos;

namespace NaturApp.Pagos
{
    public partial class consultaClientePago : PhoneApplicationPage
    {
        SQLiteConnection db;
        IEnumerable<tablaClientes> clientes;
        IEnumerable<tablaPedidos> pedidos;
        ObservableCollection<Cliente> arrClientes;

        public consultaClientePago()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            db = new SQLiteConnection("naturapp.db");

            var count = (from x in db.Table<tablaClientes>() select x.idCliente).Count();
            if (count > 0)
            {
                clientes = db.Query<tablaClientes>("SELECT * FROM tablaClientes WHERE idCliente IN (SELECT idCliente FROM tablaPedidos");

                if (clientes == null)
                {
                    MessageBox.Show("No hay pedidos agregados");
                }
                else
                {
                    arrClientes = new ObservableCollection<Cliente>();
                    foreach (var cliente in clientes)
                    {
                        arrClientes.Add(new Cliente(cliente.idCliente.ToString(), cliente.nombres, cliente.apellidos, cliente.direccion, cliente.telefono, cliente.correo, cliente.sexo, cliente.fechaNacimiento, cliente.estadoCivil));
                    }

                    listClientes.ItemsSource = arrClientes;
                }
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

            NavigationService.Navigate(new Uri("/Pagos/consultaPedidoPagos.xaml?idCliente="+ cliente.id.ToString(), UriKind.Relative));
        }
    }
}