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

namespace NaturApp.Pedidos
{
    public class Pedido
    {
        public int idPedido { get; set; }
        public int idCliente { get; set; }
        public string producto { get; set; }
        public double precio { get; set; }
        public int cantidad { get; set; }
        public DateTime fechaPedido { get; set; }
        public double totalPedido { get; set; }

        public Pedido(int idPed, int idClie, string prod, double price, int cant, DateTime fecha, double total)
        {
            this.idPedido = idPed;
            this.idCliente = idClie;
            this.producto = prod;
            this.precio = price;
            this.cantidad = cant;
            this.fechaPedido = fecha;
            this.totalPedido = total;
        }
    }
}
