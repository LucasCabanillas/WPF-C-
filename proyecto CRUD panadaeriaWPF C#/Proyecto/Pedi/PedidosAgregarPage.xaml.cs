using MySql.Data.MySqlClient;
using Proyecto.Clases;
using Proyecto.Viws;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
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

namespace Proyecto.Pedi
{
    public partial class PedidosAgregarPage : Page
    {
        private Conexion conexion = new Conexion();
        private string nombreEmpleado;

        public PedidosAgregarPage(string nombreUsuario)
        {
            InitializeComponent();
            nombreEmpleado = nombreUsuario; // Asignar el nombre del empleado a la variable
            CargarCantidad();
            CargarPeso();
            CargarProductosEnComboBox(productos);
        }

        private void CargarProductosEnComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            List<string> productos = ObtenerProductosDesdeBD();
            foreach (string producto in productos)
            {
                comboBox.Items.Add(producto);
            }
        }

        private List<string> ObtenerProductosDesdeBD()
        {
            List<string> productos = new List<string>();

            try
            {
                using (MySqlConnection conn = conexion.conexion())
                {
                    conn.Open();
                    // Modificamos la consulta para obtener solo productos cuyo 'activo' en la tabla 'stock' sea 1
                    string query = @"
            SELECT p.producto 
            FROM productosyprecios p
            JOIN stock s ON p.idproductosyprecios = s.idproductosyprecios
            WHERE s.activo = 1";  // Solo productos con 'activo = 1' en la tabla stock

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        productos.Add(reader.GetString("producto"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }

            return productos;
        }




        private void CargarCantidad()
        {
            for (int i = 1; i <= 100; i++)
            {
                cantidad.Items.Add(i); // Agrega los números al ComboBox
            }
        }
        private void CargarPeso()
        {
            for (double i = 0; i <= 100; i += 0.5)
            {
                peso.Items.Add(i); // Agrega los números al ComboBox
            }
        }

        

        private void CargarCantidadEnComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            for (int i = 1; i <= 100; i++)
            {
                comboBox.Items.Add(i);
            }
        }

        private void CargarPesoEnComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            for (double i = 0; i <= 100; i += 0.5)
            {
                comboBox.Items.Add(i);
            }
        }


        private void txtProvincia_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }



        private decimal ObtenerPrecioProducto(string nombreProducto)
        {
            decimal precio = 0;

            using (MySqlConnection conn = conexion.conexion())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT precio FROM productosyprecios WHERE producto = @producto LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@producto", nombreProducto);
                        var resultado = cmd.ExecuteScalar();

                        if (resultado != null)
                        {
                            precio = Convert.ToDecimal(resultado);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener el precio: " + ex.Message);
                }
            }

            return precio;
        }



        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Pedidos());
        }

        private void btnMasAgregarCB_Click(object sender, RoutedEventArgs e)
        {
            // Crear un nuevo Grid para cada fila de elementos
            Grid nuevoGrid = new Grid
            {
                Margin = new Thickness(0, 5, 0, 0) // Espaciado entre filas
            };

            // Definir columnas para los elementos
            nuevoGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }); // Producto
            nuevoGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }); // Cantidad
            nuevoGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }); // Peso
            nuevoGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(30) }); // Botón eliminar

            // Crear las Labels para Producto, Cantidad y Peso
            Label labelProducto = new Label
            {
                Content = "Producto",
                Foreground = Brushes.White,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Margin = new Thickness(0, 0, 130, 30),
                Height = 25,
                Width = 90
            };

            Label labelCantidad = new Label
            {
                Content = "Cantidad",
                Foreground = Brushes.White,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Margin = new Thickness(0, 0, 110, 30),
                Height = 25,
                Width = 90
            };

            Label labelPeso = new Label
            {
                Content = "Peso",
                Foreground = Brushes.White,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Margin = new Thickness(0, 0, 85, 30),

                Height = 25,
                Width = 90
            };

            // Crear los ComboBox
            ComboBox nuevoProducto = new ComboBox { Width = 220, Height = 25, Margin = new Thickness(0, 18, 0, 0) };
            ComboBox nuevaCantidad = new ComboBox { Width = 220, Height = 25, Margin = new Thickness(20, 18, 0, 0) };
            ComboBox nuevoPeso = new ComboBox { Width = 220, Height = 25, Margin = new Thickness(0, 18, -45, 0) };

            // Asignar nombres a los ComboBox para poder identificarlos
            nuevoProducto.Name = "productos";
            nuevaCantidad.Name = "cantidad";
            nuevoPeso.Name = "peso";

            // Llamar a la función para cargar los ComboBox
            CargarProductosEnComboBox(nuevoProducto);
            CargarCantidadEnComboBox(nuevaCantidad);
            CargarPesoEnComboBox(nuevoPeso);

            // Agregar evento SelectionChanged
            //nuevaCantidad.SelectionChanged += ComboBox_SelectionChanged;

            // Botón para eliminar la fila
            Button btnBorrarMas = new Button
            {
                Content = "X",
                Width = 25,
                Height = 25,
                Margin = new Thickness(0, 20, 10, 0),
                HorizontalAlignment = HorizontalAlignment.Center
            };

            // Evento para eliminar la fila
            //btnBorrarMas.Click += (s, ev) => contenedorComboBoxes.Children.Remove(nuevoGrid);
            btnBorrarMas.Click += (s, ev) =>
            {
                contenedorComboBoxes.Children.Remove(nuevoGrid); // Eliminamos la fila
                //alcularTotalComboBox(); // Recalculamos el total después de eliminar
            };

            // Ubicar cada elemento en su columna
            Grid.SetColumn(labelProducto, 0);
            Grid.SetColumn(nuevoProducto, 0);
            Grid.SetColumn(labelCantidad, 1);
            Grid.SetColumn(nuevaCantidad, 1);
            Grid.SetColumn(labelPeso, 2);
            Grid.SetColumn(nuevoPeso, 2);
            Grid.SetColumn(btnBorrarMas, 3);

            // Agregar los elementos al Grid
            nuevoGrid.Children.Add(labelProducto);
            nuevoGrid.Children.Add(nuevoProducto);
            nuevoGrid.Children.Add(labelCantidad);
            nuevoGrid.Children.Add(nuevaCantidad);
            nuevoGrid.Children.Add(labelPeso);
            nuevoGrid.Children.Add(nuevoPeso);
            nuevoGrid.Children.Add(btnBorrarMas);

            // Agregar el nuevo Grid al contenedor principal
            contenedorComboBoxes.Children.Add(nuevoGrid);
            nuevoProducto.SelectionChanged += ComboBoxProducto_SelectionChanged;
            nuevaCantidad.SelectionChanged += ComboBoxCantidad_SelectionChanged;

        }

        private void chEnvio_Checked(object sender, RoutedEventArgs e)
        {
            if (chEnvio.IsChecked == true)
            {
                lblProvincia.Visibility = Visibility.Visible;
                txtProvincia.Visibility = Visibility.Visible;

                lblLocalidad.Visibility = Visibility.Visible;
                txtLocalidad.Visibility = Visibility.Visible;

                lblDomicilio.Visibility = Visibility.Visible;
                txtDomicilio.Visibility = Visibility.Visible;

            }
        }

        private void chEnvio_Unchecked(object sender, RoutedEventArgs e)
        {
            lblProvincia.Visibility = Visibility.Collapsed;
            txtProvincia.Visibility = Visibility.Collapsed;

            lblLocalidad.Visibility = Visibility.Collapsed;
            txtLocalidad.Visibility = Visibility.Collapsed;

            lblDomicilio.Visibility = Visibility.Collapsed;
            txtDomicilio.Visibility = Visibility.Collapsed;

        }

        private decimal precioProductoSeleccionado = 0;
        private void fechaDeEntrega_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = fechaDeEntrega.SelectedDate;
            DateTime today = DateTime.Today;

            if (selectedDate.HasValue && selectedDate.Value <= today)
            {
                fechaDeEntrega.SelectedDate = null; // Resetear el DatePicker
            }
        }
        private decimal totalGeneral = 0;

        private void CalcularTotal()
        {
            totalGeneral = 0;
            if (productos.SelectedItem != null && cantidad.SelectedItem != null)
            {
                string nombreProducto = productos.SelectedItem.ToString();
                int cantidadSeleccionada = Convert.ToInt32(cantidad.SelectedItem);
                totalGeneral += ObtenerPrecioProducto(nombreProducto) * cantidadSeleccionada;
            }

            foreach (Grid grid in contenedorComboBoxes.Children)
            {
                ComboBox productoCB = (ComboBox)grid.Children[1];
                ComboBox cantidadCB = (ComboBox)grid.Children[3];

                if (productoCB.SelectedItem != null && cantidadCB.SelectedItem != null)
                {
                    string nombreProducto = productoCB.SelectedItem.ToString();
                    int cantidadSeleccionada = Convert.ToInt32(cantidadCB.SelectedItem);
                    totalGeneral += ObtenerPrecioProducto(nombreProducto) * cantidadSeleccionada;
                }
            }
            lblTotal.Content = $"Total: ${totalGeneral}";
        }

        private void productos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalcularTotal();
        }

        private void cantidad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalcularTotal();
        }

        private void ComboBoxProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalcularTotal();
        }

        private void ComboBoxCantidad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalcularTotal();
        }

        
        private void GuardarPedido()
        {
            MainWindow mainWindow = new MainWindow();
            Principal principal = new Principal();
            using (MySqlConnection conn = conexion.conexion())
            {
                MySqlTransaction transaction = null;
                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    // Verificar si el cliente existe y agregar si no
                    string queryCliente = @"INSERT INTO cliente (telefono) VALUES (@telefono) ON DUPLICATE KEY UPDATE telefono = telefono";

                    MySqlCommand cmdCliente = new MySqlCommand(queryCliente, conn, transaction);
                    cmdCliente.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                    cmdCliente.ExecuteNonQuery();

                    // INSERTAR en la tabla pedidos
                    string queryPedido = @"INSERT INTO pedidos 
            (fechaRealizoPedido, total, empleadoQueLoGestiono, FechaDePlazo, pedidoConEnvio, domicilio, localidad, provincia, telefono) 
            VALUES (@fecha, @total, @empleado, @fechaPlazo, @envio, @domicilio, @localidad, @provincia, @telefono)";

                    MySqlCommand cmdPedido = new MySqlCommand(queryPedido, conn, transaction);
                    cmdPedido.Parameters.AddWithValue("@fecha", DateTime.Now);
                    cmdPedido.Parameters.AddWithValue("@total", totalGeneral);
                    cmdPedido.Parameters.AddWithValue("@empleado", "Josue Hermandez"); // Debes obtenerlo de la interfaz
                    cmdPedido.Parameters.AddWithValue("@fechaPlazo", fechaDeEntrega.SelectedDate);
                    cmdPedido.Parameters.AddWithValue("@envio", chEnvio.IsChecked ?? false);
                    cmdPedido.Parameters.AddWithValue("@domicilio", txtDomicilio.Text);
                    cmdPedido.Parameters.AddWithValue("@localidad", txtLocalidad.Text);
                    cmdPedido.Parameters.AddWithValue("@provincia", txtProvincia.Text);
                    cmdPedido.Parameters.AddWithValue("@telefono", txtTelefono.Text); // Asegúrate de que txtTelefono.Text tenga un valor válido

                    cmdPedido.ExecuteNonQuery();
                    long idPedidoGenerado = cmdPedido.LastInsertedId;

                    // INSERTAR en la tabla detalle_pedidos
                    string queryDetalle = @"INSERT INTO detalle_pedidos 
            (idpedidos, producto, cantidad, peso, precio_unitario, subtotal ) 
            VALUES (@idpedido, @producto, @cantidad, @peso, @precio, (@cantidad * @precio))";


                    foreach (Grid grid in contenedorComboBoxes.Children)
                    {
                        ComboBox productoCB = (ComboBox)grid.Children[1];
                        ComboBox cantidadCB = (ComboBox)grid.Children[3];
                        ComboBox pesoCB = (ComboBox)grid.Children[5];

                        if (productoCB.SelectedItem != null && cantidadCB.SelectedItem != null)
                        {
                            string producto = productoCB.SelectedItem.ToString();
                            int cantidad = Convert.ToInt32(cantidadCB.SelectedItem);
                            decimal peso = Convert.ToDecimal(pesoCB.SelectedItem);
                            decimal precio = ObtenerPrecioProducto(producto);

                            MySqlCommand cmdDetalle = new MySqlCommand(queryDetalle, conn, transaction);
                            cmdDetalle.Parameters.AddWithValue("@idpedido", idPedidoGenerado);
                            cmdDetalle.Parameters.AddWithValue("@producto", producto);
                            cmdDetalle.Parameters.AddWithValue("@cantidad", cantidad);
                            cmdDetalle.Parameters.AddWithValue("@peso", peso);
                            cmdDetalle.Parameters.AddWithValue("@precio", precio);
                            
                            cmdDetalle.ExecuteNonQuery();
                        }
                    }
                    if (productos.SelectedItem != null && cantidad.SelectedItem != null && peso.SelectedItem != null)
                    {
                        string productoEstatico = productos.SelectedItem.ToString();
                        int cantidadEstatica = Convert.ToInt32(cantidad.SelectedItem);
                        decimal pesoEstatico = Convert.ToDecimal(peso.SelectedItem);
                        decimal precioEstatico = ObtenerPrecioProducto(productoEstatico);


                        MySqlCommand cmdDetalleEstatico = new MySqlCommand(queryDetalle, conn, transaction);
                        cmdDetalleEstatico.Parameters.AddWithValue("@idpedido", idPedidoGenerado);
                        cmdDetalleEstatico.Parameters.AddWithValue("@producto", productoEstatico);
                        cmdDetalleEstatico.Parameters.AddWithValue("@cantidad", cantidadEstatica);
                        cmdDetalleEstatico.Parameters.AddWithValue("@peso", pesoEstatico);
                        cmdDetalleEstatico.Parameters.AddWithValue("@precio", precioEstatico);
                        cmdDetalleEstatico.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Pedido guardado correctamente.");
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }
                    MessageBox.Show("Error al guardar el pedido: " + ex.Message);
                }
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GuardarPedido();
        }

        private void txtTelefono_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validaciones.ValidarDigitos(sender, e);

            if (txtTelefono.Text.Length >= 10)
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                var borde = (Border)txtTelefono.Template.FindName("bordeTextBox", txtTelefono);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Black; // Borde Negro
                    borde.BorderThickness = new Thickness(0.5);
                }

            }
        }

        private void txtProvincia_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validaciones.ValidarCaracteres(sender, e);
        }

        private void txtProvincia_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtProvincia.Text))
            {
                var borde = (Border)txtProvincia.Template.FindName("bordeTextBox", txtProvincia);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Black; // Borde rojo
                    borde.BorderThickness = new Thickness(0.5);
                }
            }
        }

        private void txtProvincia_LostFocus(object sender, RoutedEventArgs e)
        {
            txtProvincia.Text = txtProvincia.Text.Trim();

            var texto = txtProvincia.Text;

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            // Convierte el texto en minusculas
            var textoEnMinusculas = textInfo.ToLower(texto);

            // Convierte la primera letra de cada texto en mayuscula
            var textoEnMayusculas = textInfo.ToTitleCase(textoEnMinusculas);

            // Asignar el texto modificado de vuelta al TextBox
            txtProvincia.Text = textoEnMayusculas;
        }

        private void txtLocalidad_LostFocus(object sender, RoutedEventArgs e)
        {
            txtLocalidad.Text = txtLocalidad.Text.Trim();

            // Acceder al texto del TextBox
            var texto = txtLocalidad.Text;

            // Obtener el TextInfo de la cultura actual (Obtiene el objeto TextInfo para la cultura actual del sistema.)
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            // Convierte el texto en minusculas
            var textoEnMinusculas = textInfo.ToLower(texto);

            // Convierte la primera letra de cada texto en mayuscula
            var textoEnMayusculas = textInfo.ToTitleCase(textoEnMinusculas);

            // Asignar el texto modificado de vuelta al TextBox
            txtLocalidad.Text = textoEnMayusculas;
        }


        private void txtLocalidad_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validaciones.ValidarAlphanumericos(sender, e);
        }

        private void txtLocalidad_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtLocalidad.Text))
            {
                var borde = (Border)txtLocalidad.Template.FindName("bordeTextBox", txtLocalidad);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Black; // Borde rojo
                    borde.BorderThickness = new Thickness(0.5);
                }
            }
        }

        private void txtDomicilio_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDomicilio.Text))
            {
                var borde = (Border)txtDomicilio.Template.FindName("bordeTextBox", txtDomicilio);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Black; // Borde rojo
                    borde.BorderThickness = new Thickness(0.5);
                }
            }
        }

        private void txtDomicilio_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validaciones.ValidarAlphanumericos(sender, e);
        }

        private void txtDomicilio_LostFocus(object sender, RoutedEventArgs e)
        {
            txtDomicilio.Text = txtDomicilio.Text.Trim();

            // Acceder al texto del TextBox
            string texto = txtDomicilio.Text;

            // Obtener el TextInfo de la cultura actual (Obtiene el objeto TextInfo para la cultura actual del sistema.)
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            // Convierte el texto en minusculas
            string textoEnMinusculas = textInfo.ToLower(texto);

            // Convierte la primera letra de cada texto en mayuscula
            string textoEnMayusculas = textInfo.ToTitleCase(textoEnMinusculas);

            // Asignar el texto modificado de vuelta al TextBox
            txtDomicilio.Text = textoEnMayusculas;
        }
    }
}
