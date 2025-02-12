using MySql.Data.MySqlClient;
using Proyecto.CDU;
using Proyecto.Clases;
using Proyecto.VentasVistaBotones;
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
using static Proyecto.Viws.ProductosYprecios;

namespace Proyecto.Viws
{
    /// <summary>
    /// Lógica de interacción para Ventas.xaml
    /// </summary>
    public partial class Ventas : Page
    {
       

        public Ventas()
        {
            InitializeComponent();
            CargarDatos();
            
        }

        
        private void CargarDatos()
        {
            Conexion conexion = new Conexion();
            try
            {
                using (MySqlConnection conexionBD = conexion.conexion())
                {
                    conexionBD.Open();
                    string query = "SELECT idventas, producto, cantidad, peso, precio FROM ventas "; // Consulta para obtener los datos
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexionBD);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable); // Llena el DataTable con los datos

                    dataGridVentas.ItemsSource = dataTable.DefaultView; // Asigna el DataTable al DataGrid
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VentasVistaBotones.Agregar agregar = new VentasVistaBotones.Agregar();
            frameVentas.Content = agregar;

        }

        private void frameVentas_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void dataGridVentas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Conexion conexion = new Conexion();
            if (dataGridVentas.SelectedItem != null)
            {
                try
                {
                    // Obtener la fila seleccionada
                    DataRowView filaSeleccionada = (DataRowView)dataGridVentas.SelectedItem;
                    int id = Convert.ToInt32(filaSeleccionada["idventas"]); // Asegúrate de que "id" sea el nombre de la columna en tu tabla

                    // Confirmar la eliminación
                    MessageBoxResult resultado = MessageBox.Show(
                        $"¿Está seguro de que desea eliminar el registro con ID {id}?",
                        "Confirmar eliminación",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question
                    );

                    if (resultado == MessageBoxResult.Yes)
                    {
                        using (MySqlConnection conexionBD = conexion.conexion())
                        {
                            conexionBD.Open();

                            // Crear la consulta de eliminación
                            string query = "DELETE FROM ventas WHERE idventas = @id";

                            using (MySqlCommand comando = new MySqlCommand(query, conexionBD))
                            {
                                // Agregar el parámetro
                                comando.Parameters.AddWithValue("@id", id);

                                // Ejecutar la consulta
                                int filasAfectadas = comando.ExecuteNonQuery();

                                if (filasAfectadas > 0)
                                {
                                    MessageBox.Show("Registro eliminado exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

                                    // Recargar los datos del DataGrid
                                    CargarDatos();
                                }
                                else
                                {
                                    MessageBox.Show("No se encontró el registro a eliminar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al eliminar el registro: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un usuario para eliminar.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
