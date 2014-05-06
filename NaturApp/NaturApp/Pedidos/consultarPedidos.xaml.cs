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

namespace NaturApp.Pedidos
{
    public partial class consultarPedidos : PhoneApplicationPage
    {
        SQLiteConnection db;
        IEnumerable<tablaPedidos> pedidos;
        ObservableCollection<PedidoConsulta> arrPedidos;

        string idCliente;

        public consultarPedidos()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            db = new SQLiteConnection("naturapp.db");

            if (NavigationContext.QueryString.ContainsKey("idCliente"))
                idCliente = NavigationContext.QueryString["idCliente"].ToString();

            int id = Convert.ToInt32(idCliente.ToString());

            var count = (from x in db.Table<tablaPedidos>() where x.idCliente == id select x.idCliente).Count();
            if (count > 0)
            {
                pedidos = db.Query<tablaPedidos>("SELECT * from tablaPedidos where idCliente like " + idCliente);

                arrPedidos = new ObservableCollection<PedidoConsulta>();
                foreach (var pedido in pedidos)
                {
                    arrPedidos.Add(new PedidoConsulta(pedido.producto,pedido.fechaPedido.ToShortDateString(),pedido.totalPedido.ToString()));
                }

                listPedidos.ItemsSource = arrPedidos;
            }
            else
            {
                MessageBox.Show("No hay pedidos generados para este cliente");
            }


            base.OnNavigatedTo(e);
        }

        private void listPedidos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}