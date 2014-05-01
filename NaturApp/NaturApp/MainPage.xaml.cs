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
using NaturApp.Clientes;
using System.Collections.ObjectModel;
using NaturApp.Pagos;
using NaturApp.Pedidos;

namespace NaturApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        SQLiteConnection db;
        IEnumerable<tablaClientes> clientes;
        ObservableCollection<Cliente> arrClientes;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            db = new SQLiteConnection("naturapp.db");
            db.CreateTable<tablaClientes>();
            db.CreateTable<tablaPedidos>();
            db.CreateTable<tablaPagos>();

            // Establecer el contexto de datos del control ListBox control en los datos de ejemplo
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        // Cargar datos para los elementos ViewModel
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            var count = (from x in db.Table<tablaClientes>() select x.idCliente).Count();
            if (count > 0)
            {
                clientes = db.Query<tablaClientes>("SELECT idCliente, nombres, apellidos, direccion, telefono, correo, sexo, fechaNacimiento, estadoCivil from tablaClientes");

                arrClientes = new ObservableCollection<Cliente>();

                int i = 0;
                foreach (var cliente in clientes)
                {
                    arrClientes.Add(new Cliente(cliente.idCliente.ToString(), cliente.nombres, cliente.apellidos, cliente.direccion, cliente.telefono, cliente.correo, cliente.sexo, cliente.fechaNacimiento, cliente.estadoCivil));
                    if (i > 3)
                        break;
                    i++;
                }

                listClientes.ItemsSource = arrClientes;

                listClientes.Visibility = Visibility.Visible;
                txtNoClientesRecientes.Visibility = Visibility.Collapsed;
            }
            else
            {
                listClientes.Visibility = Visibility.Collapsed;
                txtNoClientesRecientes.Visibility = Visibility.Visible;
            }

            base.OnNavigatedTo(e);
        }

        private void crear_Click(object sender, EventArgs e)
        {
            int indice = PanoramaNatura.SelectedIndex;

            switch (indice)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    NavigationService.Navigate(new Uri("/Clientes/crearCliente.xaml", UriKind.Relative));
                    break;
                case 3:
                    NavigationService.Navigate(new Uri("/Pagos/consultaClientePago.xaml", UriKind.Relative));
                    break;
            }
        }

        private void consultar_Click(object sender, EventArgs e)
        {
            int indice = PanoramaNatura.SelectedIndex;

            switch (indice)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    NavigationService.Navigate(new Uri("/Clientes/consultarCliente.xaml", UriKind.Relative));
                    break;
                case 3:
                    break;
            }
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            int indice = PanoramaNatura.SelectedIndex;

            switch (indice)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    NavigationService.Navigate(new Uri("/Clientes/eliminarCliente.xaml", UriKind.Relative));
                    break;
                case 3:
                    break;
            }
        }

        private void actualizar_Click(object sender, EventArgs e)
        {
            int indice = PanoramaNatura.SelectedIndex;

            switch (indice)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    NavigationService.Navigate(new Uri("/Clientes/consultaActualizarCliente.xaml", UriKind.Relative));
                    break;
                case 3:
                    break;
            }
        }
    }
}