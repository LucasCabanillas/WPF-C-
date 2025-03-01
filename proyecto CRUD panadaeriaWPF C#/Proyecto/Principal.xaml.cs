using Proyecto.Viws;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Proyecto
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        private DispatcherTimer fechaYhora;
        private bool bars = false;

        public Principal()
        {
            InitializeComponent();
            fechaYhora = new DispatcherTimer(); // Inicialización del campo
            InicializarTimer();
        }

        private void InicializarTimer()
        {
            fechaYhora = new DispatcherTimer();
            fechaYhora.Interval = TimeSpan.FromSeconds(1); // El Timer se dispara cada segundo
            fechaYhora.Tick += fechaYhora_Tick;
            fechaYhora.Start(); // Iniciar el Timer
        }

        private void fechaYhora_Tick(object? sender, EventArgs e)
        {
            labelHora.Content = DateTime.Now.ToLongTimeString(); // Actualizar la hora
            labelFecha.Content = DateTime.Now.ToLongDateString(); // Actualizar la fecha
        }
        private void IconImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Controls.TextBlock[] textBlocks = { txtVentas, txtPedidos, txtStock, txtEstadistica, txtPersonal, txtPrecios };
            bars = !bars;
            if (bars)
            {
                barraDeNavegacion.Width = new GridLength(50);
                iconBars.Margin = new Thickness(20, 0, 0, 0); // Sin margen
                logo.Visibility = Visibility.Collapsed;
                usuarioOperando.Visibility = Visibility.Collapsed;
                // Iterar sobre cada TextBlock y ocultarlo
                foreach (var textBlock in textBlocks)
                {
                    textBlock.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                barraDeNavegacion.Width = new GridLength(170); // Modifica anchor
                iconBars.Margin = new Thickness(35, 0, 0, 0); // Sin margen
                logo.Visibility = Visibility.Visible;
                usuarioOperando.Visibility = Visibility.Visible;
                foreach (var textBlock in textBlocks)
                {
                    textBlock.Visibility = Visibility.Visible;
                }
            }
        }

        private void btnVentas_Checked(object sender, RoutedEventArgs e)
        {
            Ventas ventas = new Ventas();
            miFrame.Content = ventas;
        }

        private void btnMaximizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }

        private void btnPersonal_Checked(object sender, RoutedEventArgs e)
        {
            // Crear una instancia del control de usuario
            Usuarios vistaPersonal = new Usuarios();

            // Buscar el Frame definido en tu XAML y cargar el UserControl
            Frame miFrame = (Frame)this.FindName("miFrame");
            if (miFrame != null)
            {
                miFrame.Content = vistaPersonal;
            }

        }

        private void miFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void btnPrecio_Checked(object sender, RoutedEventArgs e)
        {
            Viws.ProductosYprecios productosYprecios = new ProductosYprecios();
            miFrame.Content = productosYprecios;
        }

        private void btnPedidos_Checked(object sender, RoutedEventArgs e)
        {

            Viws.Pedidos pedidos = new Viws.Pedidos();
            miFrame.Content = pedidos;
        }

        private void btnPdf_Checked(object sender, RoutedEventArgs e)
        {
            Viws.GenerarPdfPedidosPage generarPdfPedidosPage = new Viws.GenerarPdfPedidosPage();
            miFrame.Content = generarPdfPedidosPage;
        }

        private void btnStock_Checked(object sender, RoutedEventArgs e)
        {
            Viws.StockPage stockPage = new StockPage();
            miFrame.Content = stockPage;
        }
    }
}
