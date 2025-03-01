using MySql.Data.MySqlClient;
using Proyecto.Clases;
using Proyecto.Viws;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Proyecto.VistaStock
{
    /// <summary>
    /// Lógica de interacción para AgregarProductoStockPage.xaml
    /// </summary>
    public partial class AgregarProductoStockPage : Page
    {
        public AgregarProductoStockPage()
        {
            InitializeComponent();
        }

        private void GuardarProducto_Click(object sender, RoutedEventArgs e)
        {
            string nombreProducto = txtNombreProducto.Text.Trim();
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("Ingrese un precio válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            // Validar que el nombre del producto no esté vacío
            if (string.IsNullOrEmpty(nombreProducto))
            {
                MessageBox.Show("Ingrese el nombre del producto.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                using (MySqlConnection conexionBD = new Conexion().conexion())
                {
                    conexionBD.Open();

                    // Verificar si el producto ya existe en productosyprecios
                    var queryCheck = "SELECT idproductosyprecios FROM productosyprecios WHERE producto = @producto";
                    MySqlCommand cmdCheck = new MySqlCommand(queryCheck, conexionBD);
                    cmdCheck.Parameters.AddWithValue("@producto", nombreProducto);
                    object productId = cmdCheck.ExecuteScalar();

                    int productoId;
                    if (productId == null) // Producto no existe, lo agregamos a productosyprecios
                    {
                        var queryInsertProduct = "INSERT INTO productosyprecios (producto, precio) VALUES (@producto, @precio)";
                        MySqlCommand cmdInsertProduct = new MySqlCommand(queryInsertProduct, conexionBD);
                        cmdInsertProduct.Parameters.AddWithValue("@producto", nombreProducto);
                        cmdInsertProduct.Parameters.AddWithValue("@precio", precio);
                        cmdInsertProduct.ExecuteNonQuery();

                        // Obtener el ID del producto recién insertado
                        productoId = (int)cmdInsertProduct.LastInsertedId;
                    }
                    else
                    {
                        productoId = Convert.ToInt32(productId);
                    }

                    // Insertar el producto en la tabla stock
                    var queryInsertStock = "INSERT INTO stock (idproductosyprecios, cantidad, precio) VALUES (@idproductosyprecios, @cantidad, @precio)";
                    MySqlCommand cmdInsertStock = new MySqlCommand(queryInsertStock, conexionBD);
                    cmdInsertStock.Parameters.AddWithValue("@idproductosyprecios", productoId);
                    cmdInsertStock.Parameters.AddWithValue("@cantidad", cantidad);
                    cmdInsertStock.Parameters.AddWithValue("@precio", precio);
                    cmdInsertStock.ExecuteNonQuery();

                    MessageBox.Show("Producto agregado exitosamente al stock.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    // Limpiar los campos
                    txtNombreProducto.Clear();
                    txtPrecio.Clear();
                    txtCantidad.Clear();
                    this.NavigationService.Navigate(new StockPage());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar producto al stock: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new StockPage());
        }
    }
}