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
using System.Globalization;

namespace NaturApp.Pedidos
{
    public partial class crearPedidos : PhoneApplicationPage
    {
        SQLiteConnection db;
        int idProducto;
        string nombreProducto;
        double precio;
        int cantidad;
        double total;
        int idCliente;
        DateTime fecha;

        public crearPedidos()
        {
            InitializeComponent();
            db = new SQLiteConnection("naturapp.db");
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("idCliente"))
                idCliente = Convert.ToInt32(NavigationContext.QueryString["idCliente"].ToString());
            base.OnNavigatedTo(e);
        }

        private void guardar_Click(object sender, RoutedEventArgs e)
        {
            idProducto = Convert.ToInt32(txtCodigo.Text.ToString());
            nombreProducto = txtProducto.Text;
            precio = Convert.ToDouble(txtPrecio.Text.ToString());
            cantidad = Convert.ToInt32(txtCantidad.Text.ToString());
            total = Convert.ToDouble(txtTotal.Text.ToString());
            fecha = DateTime.Now;

            db.Insert(new tablaPedidos()
            {
                idProducto = idProducto,
                idCliente = idCliente,
                producto = nombreProducto,
                precio = precio,
                cantidad = cantidad,
                totalPedido = total,
                fechaPedido = fecha
            });

            MessageBoxResult resultado = MessageBox.Show("¿Deseas agregar otro pedido?", "Pedidos", MessageBoxButton.OKCancel);

            if (resultado == MessageBoxResult.OK)
            {
                txtCodigo.Text = "";
                txtProducto.Text = "";
                txtPrecio.Text = "";
                txtCantidad.Text = "";
                txtTotal.Text = "";
            }
            else
            {
                NavigationService.GoBack();
            }
        }

        private void txtCantidad_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!txtPrecio.Text.ToString().Equals("") && !txtCantidad.Text.ToString().Equals(""))
            {
                double precio = Convert.ToDouble(txtPrecio.Text.ToString(), CultureInfo.InvariantCulture);
                int cantidad = Convert.ToInt32(txtCantidad.Text.ToString());
                double total = precio * cantidad;
                txtTotal.Text = total.ToString();
            }
        }
    }
}