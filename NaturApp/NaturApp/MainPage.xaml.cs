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

namespace NaturApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        SQLiteConnection db;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            db = new SQLiteConnection("naturapp.db");
            db.CreateTable<tablaClientes>();

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
                    break;
            }
        }
    }
}