using MySql.Data.MySqlClient;
using Proyecto.Clases;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Proyecto.Viws
{
    /// <summary>
    /// Lógica de interacción para StockPage.xaml
    /// </summary>
    public partial class StockPage : Page
    {
        public StockPage()
        {
            InitializeComponent();
            CargarStock();
        }

        private void CargarStock()
        {
            try
            {
                Conexion conexion = new Conexion();
                using (MySqlConnection conexionBD = conexion.conexion())
                {
                    conexionBD.Open();
                    var query = "SELECT p.producto, s.cantidad, s.precio FROM stock s " +
                                "JOIN productosyprecios p ON s.idproductosyprecios = p.idproductosyprecios " +
                                "WHERE s.activo = 1"; // Solo mostrar productos activos

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexionBD);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridStock.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar stock: " + ex.Message);
            }
        }

        private void AgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            VistaStock.AgregarProductoStockPage agregarProductoStockPage = new VistaStock.AgregarProductoStockPage();
            frameStock.Content = agregarProductoStockPage;
        }

        private void ActualizarStock_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridStock.SelectedItem != null)
            {
                DataRowView filaSeleccionada = (DataRowView)dataGridStock.SelectedItem;
                string producto = Convert.ToString(filaSeleccionada["producto"]);
                int cantidad = Convert.ToInt32(filaSeleccionada["cantidad"]);
                decimal precio = Convert.ToDecimal(filaSeleccionada["precio"]);

                VistaStock.ActualizarStockPage actualizarStockPage = new VistaStock.ActualizarStockPage(producto, cantidad, precio);
                frameStock.Content = actualizarStockPage;
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un producto para actualizar.");
            }
        }

        private void EliminarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridStock.SelectedItem != null)
            {
                DataRowView filaSeleccionada = (DataRowView)dataGridStock.SelectedItem;
                string producto = Convert.ToString(filaSeleccionada["producto"]);

                MessageBoxResult resultado = MessageBox.Show(
                    "¿Está seguro de que desea eliminar este producto del stock?",
                    "Confirmar desactivación",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question
                );

                if (resultado == MessageBoxResult.Yes)
                {
                    try
                    {
                        using (MySqlConnection conexionBD = new Conexion().conexion())
                        {
                            conexionBD.Open();
                            var query = "UPDATE stock SET activo = 0 WHERE idproductosyprecios = (SELECT idproductosyprecios FROM productosyprecios WHERE producto = @producto)";

                            MySqlCommand cmd = new MySqlCommand(query, conexionBD);
                            cmd.Parameters.AddWithValue("@producto", producto);

                            int filasAfectadas = cmd.ExecuteNonQuery();

                            if (filasAfectadas > 0)
                            {
                                MessageBox.Show("Producto eliminado exitosamente.");
                                CargarStock();  // Actualizar el grid
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar producto: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un producto para eliminar.");
            }
        }

        private void RestaurarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridStock.SelectedItem != null)
            {
                DataRowView filaSeleccionada = (DataRowView)dataGridStock.SelectedItem;
                string producto = Convert.ToString(filaSeleccionada["producto"]);

                MessageBoxResult resultado = MessageBox.Show(
                    "¿Desea restaurar este producto?",
                    "Confirmar restauración",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question
                );

                if (resultado == MessageBoxResult.Yes)
                {
                    try
                    {
                        using (MySqlConnection conexionBD = new Conexion().conexion())
                        {
                            conexionBD.Open();
                            var query = "UPDATE stock SET activo = 1 WHERE idproductosyprecios = (SELECT idproductosyprecios FROM productosyprecios WHERE producto = @producto)";

                            MySqlCommand cmd = new MySqlCommand(query, conexionBD);
                            cmd.Parameters.AddWithValue("@producto", producto);

                            int filasAfectadas = cmd.ExecuteNonQuery();

                            if (filasAfectadas > 0)
                            {
                                MessageBox.Show("Producto restaurado exitosamente.");
                                CargarStock();  // Actualizar el grid
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al restaurar producto: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un producto para restaurar.");
            }
        }


    }
}
