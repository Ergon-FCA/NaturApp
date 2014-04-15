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
using Microsoft.Phone.Tasks;

namespace NaturApp.Clientes
{
    public partial class detalleCliente : PhoneApplicationPage
    {
        string idCliente;
        tablaClientes cliente;
        SQLiteConnection db;

        public detalleCliente()
        {
            InitializeComponent();
            db = new SQLiteConnection("naturapp.db");
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("idCliente"))
                idCliente = NavigationContext.QueryString["idCliente"];

            cliente = db.Query<tablaClientes>("SELECT idCliente, nombres, apellidos, direccion, telefono, correo, sexo, fechaNacimiento, estadoCivil from tablaClientes where idCliente like " + "'" + idCliente + "'").FirstOrDefault();

            txtNombre.Text = cliente.nombres + " " + cliente.apellidos;
            txtDireccion.Text = cliente.direccion;
            txtTelefono.Text = cliente.telefono;
            txtCorreo.Text = cliente.correo;
            if (cliente.sexo.ToString().Equals("F"))
                txtSexo.Text = "Femenino";
            else
                txtSexo.Text = "Masculino";

            txtCivil.Text = cliente.estadoCivil;
            txtFecha.Text = cliente.fechaNacimiento;

            base.OnNavigatedTo(e);
        }

        private void btnLLamar_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (cliente.telefono == null || cliente.telefono.Equals(""))
                MessageBox.Show("No tienes número registrado para este cliente");
            else
            {
                PhoneCallTask pct = new PhoneCallTask();
                pct.DisplayName = cliente.nombres +" " + cliente.apellidos;
                pct.PhoneNumber = cliente.telefono;
                pct.Show();
            }
        }

        private void btnCorreo_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (cliente.correo == null || cliente.correo.Equals(""))
                MessageBox.Show("No tienes correo electrónico registrado para este cliente");
            else
            {
                EmailComposeTask email = new EmailComposeTask();
                email.To = cliente.correo;
                email.Subject = "Consultor Natura";
                email.Show();
            }
        }
    }
}