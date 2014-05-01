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
using NaturApp.Pedidos;
using System.Collections.ObjectModel;

namespace NaturApp.Pagos
{
    public partial class consultaPedidoPagos : PhoneApplicationPage
    {

        SQLiteConnection db;        
        IEnumerable<tablaPedidos> pedidos;
        ObservableCollection<Pedido> arrClientes;

        public consultaPedidoPagos()
        {
            InitializeComponent();
        }
    }
}