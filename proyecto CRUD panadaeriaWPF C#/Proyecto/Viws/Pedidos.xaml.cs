using MySql.Data.MySqlClient;
using Proyecto.CDU;
using Proyecto.Clases;
using Proyecto.Pedi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using MySql.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using static Proyecto.MainWindow;

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
            CargarDatos();
        }


        public class PedidosModel
        {
            public int IdPedido { get; set; }

            public int IdPedidos { get; set; }
            public DateTime FechaRealizoPedido { get; set; }
            public decimal Total { get; set; }
            public string EmpleadoQueLoGestiono { get; set; }
            public DateTime FechaDePlazo { get; set; }
            public int Telefono { get; set; }
            public bool PedidoConEnvio { get; set; }
            public string Domicilio { get; set; }
            public string Localidad { get; set; }
            public string Provincia { get; set; }
        }

        public class DetallePedidoModel
        {
            public int IdDetalle { get; set; }
            public int IdPedidos { get; set; }
            public string Producto { get; set; }
            public int Cantidad { get; set; }
            public decimal Peso { get; set; }
            public decimal PrecioUnitario { get; set; }
            public decimal Subtotal { get; set; }
        }



        private void btnCargarr_Click(object sender, RoutedEventArgs e)
        {
            // Obtener el nombre del usuario actual (esto lo puedes obtener de donde corresponda en tu aplicación)
            string nombreUsuario = Sesion.Rango; // Si tienes el nombre guardado en la clase Sesion, úsalo

            // Crear una nueva instancia pasando el nombre de usuario
            Pedi.PedidosAgregarPage pedidosAgregarPage = new Pedi.PedidosAgregarPage(nombreUsuario);
            framePedidos.Content = pedidosAgregarPage;
        }

        private void CargarDatos()
        {
            Conexion conexion = new Conexion();
            try
            {   
                using (MySqlConnection conexionBD = conexion.conexion())
                {
                    conexionBD.Open();
                    string query = "SELECT idpedidos, fechaRealizoPedido, total, empleadoQueLoGestiono, fechaDePlazo, telefono, pedidoConEnvio, domicilio, localidad, provincia FROM pedidos"; // Consulta para obtener los datos
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexionBD);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable); // Llena el DataTable con los datos

                    datagridusuarios.ItemsSource = dataTable.DefaultView; // Asigna el DataTable al DataGrid
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }
       
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {

            if (datagridusuarios.SelectedItem != null)
            {

                // Obtén la fila seleccionada como DataRowView
                DataRowView filaSeleccionada = (DataRowView)datagridusuarios.SelectedItem;

                // Convertir DataRowView en un objeto PedidosModel
                PedidosModel pedido = new PedidosModel
                {
                    IdPedidos = Convert.ToInt32(filaSeleccionada["idpedidos"]),
                    FechaRealizoPedido = Convert.ToDateTime(filaSeleccionada["fechaRealizoPedido"]),
                    Total = Convert.ToDecimal(filaSeleccionada["total"]),
                    EmpleadoQueLoGestiono = filaSeleccionada["empleadoQueLoGestiono"].ToString(),
                    FechaDePlazo = Convert.ToDateTime(filaSeleccionada["fechaDePlazo"]),
                    Telefono = Convert.ToInt32(filaSeleccionada["telefono"]),
                    PedidoConEnvio = Convert.ToBoolean(filaSeleccionada["pedidoConEnvio"]),
                    Domicilio = filaSeleccionada["domicilio"].ToString(),
                    Localidad = filaSeleccionada["localidad"].ToString(),
                    Provincia = filaSeleccionada["provincia"].ToString(),
                };

                // Obtener los productos del pedido desde la BD
                List<DetallePedidoModel> detallesPedido = ObtenerDetallesPedido(pedido.IdPedidos);

                // Crear una instancia de ModificarPedidosPage pasando el pedido y los detalles
                ModificarPedidosPage modificarPedidos = new ModificarPedidosPage(pedido.IdPedidos, detallesPedido);

                // Mostrar la ventana de modificación
                framePedidos.Content = modificarPedidos;
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un pedido para modificar.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private List<DetallePedidoModel> ObtenerDetallesPedido(int idPedido)
        {
            Conexion conexion = new Conexion();
            List<DetallePedidoModel> detalles = new List<DetallePedidoModel>();

            using (MySqlConnection conexionBD = conexion.conexion())
            {
                string query = "SELECT id_detalle, idpedidos, producto, cantidad, peso, precio_unitario, subtotal FROM detalle_pedidos WHERE idpedidos = @idPedido";

                using (MySqlCommand cmd = new MySqlCommand(query, conexionBD))
                {
                    cmd.Parameters.AddWithValue("@idPedido", idPedido);
                    conexionBD.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            detalles.Add(new DetallePedidoModel
                            {
                                IdDetalle = reader.GetInt32("id_detalle"),
                                IdPedidos = reader.GetInt32("idpedidos"),
                                Producto = reader.GetString("producto"),
                                Cantidad = reader.GetInt32("cantidad"),
                                Peso = reader.GetDecimal("peso"),
                                PrecioUnitario = reader.GetDecimal("precio_unitario"),
                            });
                        }
                    }
                }
            }

            return detalles;
        }



        private void framePedidos_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (datagridusuarios.SelectedItem != null)
            {
                // Obtén la fila seleccionada como DataRowView
                DataRowView filaSeleccionada = (DataRowView)datagridusuarios.SelectedItem;

                // Obtén el ID del pedido seleccionado
                int idPedido = Convert.ToInt32(filaSeleccionada["idpedidos"]);

                // Preguntar al usuario si realmente quiere eliminar el pedido
                MessageBoxResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este pedido?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (resultado == MessageBoxResult.Yes)
                {
                    Conexion conexion = new Conexion();
                    try
                    {
                        using (MySqlConnection conexionBD = conexion.conexion())
                        {
                            conexionBD.Open();

                            // Comenzar la transacción para eliminar el pedido y sus detalles
                            MySqlTransaction transaction = conexionBD.BeginTransaction();

                            try
                            {
                                // Eliminar los detalles del pedido primero
                                string queryDetalles = "DELETE FROM detalle_pedidos WHERE idpedidos = @idPedido";
                                MySqlCommand cmdDetalles = new MySqlCommand(queryDetalles, conexionBD);
                                cmdDetalles.Parameters.AddWithValue("@idPedido", idPedido);
                                cmdDetalles.ExecuteNonQuery();

                                // Eliminar el pedido de la tabla principal
                                string queryPedido = "DELETE FROM pedidos WHERE idpedidos = @idPedido";
                                MySqlCommand cmdPedido = new MySqlCommand(queryPedido, conexionBD);
                                cmdPedido.Parameters.AddWithValue("@idPedido", idPedido);
                                cmdPedido.ExecuteNonQuery();

                                // Confirmar la transacción
                                transaction.Commit();

                                // Recargar los datos del DataGrid
                                CargarDatos();

                                MessageBox.Show("Pedido eliminado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            catch (Exception ex)
                            {
                                // Si ocurre un error, deshacer la transacción
                                transaction.Rollback();
                                MessageBox.Show("Error al eliminar el pedido: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un pedido para eliminar.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}
