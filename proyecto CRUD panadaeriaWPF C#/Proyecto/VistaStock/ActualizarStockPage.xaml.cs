using MySql.Data.MySqlClient;
using Proyecto.Clases;
using Proyecto.Viws;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Proyecto.VistaStock
{
    /// <summary>
    /// Lógica de interacción para ActualizarStockPage.xaml
    /// </summary>
    public partial class ActualizarStockPage : Page
    {
        // Variables para los valores del producto a actualizar
        private int idProducto;
        private string nombreProducto;
        private int cantidadProducto;
        private decimal precioProducto;

        public ActualizarStockPage(string producto, int cantidad, decimal precio)
        {
            InitializeComponent();

            // Guardamos los valores originales
            nombreProducto = producto;
            cantidadProducto = cantidad;
            precioProducto = precio;

            // Cargamos los valores en los TextBox
            txtNombreProducto.Text = nombreProducto;
            txtCantidad.Text = cantidadProducto.ToString();
            txtPrecio.Text = precioProducto.ToString("F2");

            // Obtener el id del producto
            ObtenerIdProducto();
        }

        private void ObtenerIdProducto()
        {
            try
            {
                using (MySqlConnection conexionBD = new Conexion().conexion())
                {
                    conexionBD.Open();
                    var query = "SELECT idproductosyprecios FROM productosyprecios WHERE producto = @producto";
                    MySqlCommand cmd = new MySqlCommand(query, conexionBD);
                    cmd.Parameters.AddWithValue("@producto", nombreProducto);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        idProducto = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el ID del producto: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ActualizarStock_Click(object sender, RoutedEventArgs e)
        {
            // Validar los campos
            if (!int.TryParse(txtCantidad.Text, out int nuevaCantidad) || nuevaCantidad <= 0)
            {
                MessageBox.Show("Cantidad inválida.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal nuevoPrecio) || nuevoPrecio <= 0)
            {
                MessageBox.Show("Precio inválido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string nuevoNombreProducto = txtNombreProducto.Text.Trim();
            if (string.IsNullOrWhiteSpace(nuevoNombreProducto))
            {
                MessageBox.Show("El nombre del producto no puede estar vacío.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                using (MySqlConnection conexionBD = new Conexion().conexion())
                {
                    conexionBD.Open();

                    // Actualizar el nombre y precio en productosyprecios
                    string queryUpdateProductos = "UPDATE productosyprecios SET producto = @nuevoNombre, precio = @nuevoPrecio WHERE idproductosyprecios = @idProducto";
                    MySqlCommand cmdUpdateProductos = new MySqlCommand(queryUpdateProductos, conexionBD);
                    cmdUpdateProductos.Parameters.AddWithValue("@nuevoNombre", nuevoNombreProducto);
                    cmdUpdateProductos.Parameters.AddWithValue("@nuevoPrecio", nuevoPrecio);
                    cmdUpdateProductos.Parameters.AddWithValue("@idProducto", idProducto);

                    // Actualizar cantidad y precio en stock
                    string queryUpdateStock = "UPDATE stock SET cantidad = @nuevaCantidad, precio = @nuevoPrecio WHERE idproductosyprecios = @idProducto";
                    MySqlCommand cmdUpdateStock = new MySqlCommand(queryUpdateStock, conexionBD);
                    cmdUpdateStock.Parameters.AddWithValue("@nuevaCantidad", nuevaCantidad);
                    cmdUpdateStock.Parameters.AddWithValue("@nuevoPrecio", nuevoPrecio);
                    cmdUpdateStock.Parameters.AddWithValue("@idProducto", idProducto);

                    // Ejecutar ambas actualizaciones
                    int filasAfectadasProductos = cmdUpdateProductos.ExecuteNonQuery();
                    int filasAfectadasStock = cmdUpdateStock.ExecuteNonQuery();

                    if (filasAfectadasProductos > 0 || filasAfectadasStock > 0)
                    {
                        MessageBox.Show("Stock y producto actualizados exitosamente.");
                        this.NavigationService.Navigate(new StockPage());
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el stock ni el producto.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar stock y producto: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new StockPage());
        }
    }
}
