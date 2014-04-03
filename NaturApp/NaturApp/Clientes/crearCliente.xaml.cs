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
using System.Collections.ObjectModel;

namespace NaturApp.Clientes
{
    public partial class crearCliente : PhoneApplicationPage
    {
        ObservableCollection<cEstadoCivil> source;
        SQLiteConnection db;

        public crearCliente()
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

        }
    }
}