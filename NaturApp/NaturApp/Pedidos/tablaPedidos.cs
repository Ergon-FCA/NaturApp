using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SQLite;

namespace NaturApp.Pedidos
{
    public class tablaPedidos
    {
        [PrimaryKey, AutoIncrement]
        public int idPedido { get; set; }
        public int idCliente { get; set; }
        public int idProducto { get; set; }
        public string producto { get; set; }
        public double precio { get; set; }
        public int cantidad { get; set; }
        public DateTime fechaPedido { get; set; }
        public double totalPedido { get; set; }
    }
}
