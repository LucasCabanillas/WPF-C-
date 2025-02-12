﻿using Proyecto.Pedi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto.Viws
{
    /// <summary>
    /// Lógica de interacción para Pedidos.xaml
    /// </summary>
    public partial class Pedidos : Page
    {
        public Pedidos()
        {
            InitializeComponent();
        }

        private void btnCargarr_Click(object sender, RoutedEventArgs e)
        {
            Pedi.PedidosAgregarPage pedidosAgregarPage = new Pedi.PedidosAgregarPage();
            framePedidos.Content = pedidosAgregarPage;
        }
    }
}
