using MySql.Data.MySqlClient;
using Proyecto.CDU;
using Proyecto.Clases;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica de interacción para ProductosYprecios.xaml
    /// </summary>
    public partial class ProductosYprecios : Page
    {
        public ProductosYprecios()
        {
            InitializeComponent();
            CargarDatos();

        }

        private void CargarDatos()
        {
            Clases.Conexion conexion = new Clases.Conexion();
            try
            {
                using (MySqlConnection conexionBD = conexion.conexion())
                {
                    conexionBD.Open();
                    var query = @"
                    SELECT p.producto, p.precio 
                    FROM productosyprecios p
                    JOIN stock s ON p.idproductosyprecios = s.idproductosyprecios
                    WHERE s.activo = 1;";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexionBD);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    datagriproductosyprecios.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        public class ProductosYPrecios
        {
            public string Producto { get; set; }
            public decimal Precio { get; set; }

            // Método para obtener productos desde la base de datos
            public static List<ProductosYPrecios> ObtenerProductos()
            {
                List<ProductosYPrecios> productos = new List<ProductosYPrecios>();

                try
                {
                    Clases.Conexion conexion = new Clases.Conexion();
                    using (MySqlConnection conexionBD = conexion.conexion())
                    {
                        conexionBD.Open();

                        // Consulta SQL que filtra los productos con cantidad mayor a 0
                        string query = @"
                SELECT p.producto, p.precio 
                FROM productosyprecios p
                JOIN stock s ON p.idproductosyprecios = s.idproductosyprecios
                WHERE s.activo = 1 AND s.cantidad > 0";  // Solo productos con cantidad > 0

                        using (MySqlCommand cmd = new MySqlCommand(query, conexionBD))
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                productos.Add(new ProductosYPrecios
                                {
                                    Producto = reader.GetString("producto"),
                                    Precio = reader.GetDecimal("precio")
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener productos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                return productos;
            }
        }

        

        private void btnAgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            PreciosyVentas.ProductoYPrecioPage productoYPrecioPage = new PreciosyVentas.ProductoYPrecioPage();
            frameRegistrarProducto.Content = productoYPrecioPage;
        }

        private void btnModificarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (datagriproductosyprecios.SelectedItem != null)
            {
                // Obtén la fila seleccionada como DataRowView
                DataRowView filaSeleccionada = (DataRowView)datagriproductosyprecios.SelectedItem;
                // Crear una instancia de ModificarPersonal pasando la fila seleccionada
                PreciosyVentas.ProductoYPrecioModificarPage productoYPrecioModificarPage = new PreciosyVentas.ProductoYPrecioModificarPage(filaSeleccionada);

                // Mostrar la ventana de modificación
                frameRegistrarProducto.Content = productoYPrecioModificarPage;
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un producto para modificar.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void frameRegistrarProducto_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void EliminarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (datagriproductosyprecios.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un producto para marcar como sin stock.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DataRowView filaSeleccionada = (DataRowView)datagriproductosyprecios.SelectedItem;
            string producto = Convert.ToString(filaSeleccionada["producto"]);

            MessageBoxResult resultado = MessageBox.Show(
                "¿Está seguro de que desea marcar este producto como sin stock?",
                "Confirmar",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            );

            if (resultado == MessageBoxResult.Yes)
            {
                using (MySqlConnection conexionBD = new Conexion().conexion())
                {
                    conexionBD.Open();

                    var query = "UPDATE stock SET disponible = 0 WHERE producto = @producto";

                    using (MySqlCommand cmd = new MySqlCommand(query, conexionBD))
                    {
                        cmd.Parameters.AddWithValue("@producto", producto);

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Producto marcado como sin stock.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                            CargarDatos();  // Actualizar lista
                        }
                    }
                }
            }
        }
    }
}
