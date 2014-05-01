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

namespace NaturApp.Pagos
{
    public class tablaPagos
    {
        [PrimaryKey, AutoIncrement]
        public int idPago { get; set; }
        public int idCliente { get; set; }
        public int idPedido { get; set; }
        public double cantidadPago { get; set; }
        public DateTime fechaPago { get; set; }

    }
}
