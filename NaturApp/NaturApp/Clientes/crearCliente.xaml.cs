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
using System.IO.IsolatedStorage;
using SQLite;
using System.Globalization;


namespace NaturApp.Clientes
{
    public partial class crearCliente : PhoneApplicationPage
    {
        ObservableCollection<cEstadoCivil> source;
        SQLiteConnection db;
        string nombre;
        string apellidos;
        string direccion;
        string telefono;
        string correo;
        string sexo;
        string estadoCivil;
        string fechaNacimiento;

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

            db = new SQLiteConnection("naturapp.db");

        }

        private void guardar_Click(object sender, RoutedEventArgs e)
        {
            nombre = txtNombre.Text;
            apellidos = txtApellidos.Text;
            direccion = txtDireccion.Text;
            telefono = txtTelefono.Text;
            correo = txtCorreo.Text;

            DateTime date = (DateTime)datePicker.Value;
            fechaNacimiento = date.ToString("ddMMyyyy", CultureInfo.InvariantCulture);

            if (rdbFemenino.IsChecked == false && rdbMasculino.IsChecked == false)
            {
                MessageBox.Show("Debes seleccionar el sexo del cliente");
                return;
            }

            if (rdbFemenino.IsChecked == true)
                sexo = "F";
            else
                if (rdbMasculino.IsChecked == true)
                    sexo = "M";
                else
                    sexo = "NA";

            cEstadoCivil estado = listPicker.SelectedItem as cEstadoCivil;
            if (estado.Nombre.ToString().Equals("Seleccione"))
            {
                MessageBox.Show("Es necesario que eligas un estado civil");
                return;
            }
            else
            {
                estadoCivil = estado.Nombre.ToString();
            }
            
            db.Insert(new tablaClientes()
            {
                nombres = this.nombre,
                apellidos = this.apellidos,
                direccion = this.direccion,
                telefono = this.telefono,
                correo = this.correo,
                sexo = this.sexo,
                estadoCivil = this.estadoCivil,
                fechaNacimiento = this.fechaNacimiento
            });

            MessageBox.Show("Cliente creado satisfactoriamente");
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            listPicker.SelectedIndex = 0;
        }
    }
}