﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace NaturApp.Clientes
{
    public class cEstadoCivil
    {
        public string Nombre { get; set; }

        public string Valor { get; set;  }

        public cEstadoCivil(string nombre, string valor)
        {
            this.Nombre = nombre;
            this.Valor = valor;
        }
    }
}
