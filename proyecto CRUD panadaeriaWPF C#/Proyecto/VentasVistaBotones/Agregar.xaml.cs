using MySql.Data.MySqlClient;
using Proyecto.Clases;
using Proyecto.Viws;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using static Org.BouncyCastle.Asn1.Cmp.Challenge;
using static Proyecto.Viws.ProductosYprecios;

namespace Proyecto.VentasVistaBotones
{
    /// <summary>
    /// Lógica de interacción para Agregar.xaml
    /// </summary>
    public partial class Agregar : Page
    {
        private List<ProductosYPrecios> listaProductos;

        private int cantidadAuxiliar = 0; // Variable auxiliar para almacenar la cantidad seleccionada
        public Agregar()
        {
            InitializeComponent();
            CargarProductoss();
            CargarCantidad();
            CargarPeso();
            // Llamar a la función para cargar todos los ComboBox existentes
            //CargarComboBoxes();

        }

        Conexion conexion = new Conexion();

        private decimal totalCalculo = 0; // Variable para almacenar el total de CalculoTotal
        private void CalcularTotal()
        {
            int cantidadAuxiliar = 0;

            if (productos.SelectedItem is ProductosYPrecios productoSeleccionado &&
                cantidad.SelectedItem != null &&
                int.TryParse(cantidad.SelectedItem.ToString(), out cantidadAuxiliar) &&
                cantidadAuxiliar > 0)
            {
                decimal precio = productoSeleccionado.Precio;
                totalCalculo = precio * cantidadAuxiliar;
            }
            else
            {
                totalCalculo = 0;
            }
            ActualizarTotalGeneral(); // Llamar a la función para actualizar lblTotal
        }

        private decimal totalComboBox = 0; // Variable para almacenar el total de ComboBox
        private void CalcularTotalComboBox()
        {
            decimal totalSumaComboBoxes = 0; // Reiniciamos la suma

            foreach (var child in contenedorComboBoxes.Children)
            {
                if (child is Grid grid)
                {
                    ComboBox cantidadComboBox = null;
                    ComboBox productoComboBox = null;

                    // Buscar los ComboBox dentro del Grid
                    foreach (var element in grid.Children)
                    {
                        if (element is ComboBox comboBox)
                        {
                            if (comboBox.Name == "cantidad")
                                cantidadComboBox = comboBox;
                            else if (comboBox.Name == "productos")
                                productoComboBox = comboBox;
                        }
                    }

                    // Verificamos que los ComboBox no sean nulos y tengan valores seleccionados
                    if (productoComboBox?.SelectedItem is ProductosYPrecios productoSeleccionado &&
                        cantidadComboBox?.SelectedItem is int cantidadSeleccionada && cantidadSeleccionada > 0)
                    {
                        decimal precio = productoSeleccionado.Precio;
                        totalSumaComboBoxes += precio * cantidadSeleccionada;
                    }
                }
            }

            totalComboBox = totalSumaComboBoxes; // Actualizamos el total de ComboBoxes
            ActualizarTotalGeneral(); // Refrescamos el total general
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalcularTotalComboBox();
        }

        private void ActualizarTotalGeneral()
        {
            decimal totalGeneral = totalCalculo + totalComboBox;
            lblTotal.Content = $"Total: ${totalGeneral:F2}"; // Mostrar el total en el Label
        }

        private void CargarProductoss()
        {
            listaProductos = ProductosYPrecios.ObtenerProductos();
            productos.ItemsSource = listaProductos;
            productos.DisplayMemberPath = "Producto"; // Mostrar solo el nombre
            productos.SelectedValuePath = "Precio";  // Guardar el precio como valor
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

        private void CargarProductosEnComboBox(ComboBox comboBox)
        {
            listaProductos = ProductosYPrecios.ObtenerProductos();
            comboBox.ItemsSource = listaProductos;
            comboBox.DisplayMemberPath = "Producto"; // Mostrar solo el nombre
            comboBox.SelectedValuePath = "Precio";  // Guardar el precio como valor
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
        private void ValidarSoloNumerosYComa(object sender, TextCompositionEventArgs e)
        {
            // Expresión regular para validar solo números y la coma
            Regex regex = new Regex(@"^[0-9,.]+$");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void txtProvincia_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            ValidarSoloNumerosYComa(sender, e);
        }

        private void txtProvincia_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Ventas());
        }

        // Listas globales para almacenar los ComboBox de productos y los TextBox de cantidades
        private List<TextBox> listaCantidades = new List<TextBox>();

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
            nuevaCantidad.SelectionChanged += ComboBox_SelectionChanged;

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
                RestarTotalFila(nuevoGrid); // Restamos el total de esta fila antes de eliminarla
                contenedorComboBoxes.Children.Remove(nuevoGrid); // Eliminamos la fila
                CalcularTotalComboBox(); // Recalculamos el total después de eliminar
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
        }

        private void RestarTotalFila(Grid fila)
        {
            ComboBox cantidadComboBox = null;
            ComboBox productoComboBox = null;

            // Buscar los ComboBox dentro del Grid
            foreach (var element in fila.Children)
            {
                if (element is ComboBox comboBox)
                {
                    if (comboBox.Name == "cantidad")
                        cantidadComboBox = comboBox;
                    else if (comboBox.Name == "productos")
                        productoComboBox = comboBox;
                }
            }

            // Verificar si ambos ComboBox tienen valores seleccionados
            if (productoComboBox?.SelectedItem is ProductosYPrecios productoSeleccionado &&
                cantidadComboBox?.SelectedItem is int cantidadSeleccionada && cantidadSeleccionada > 0)
            {
                decimal precio = productoSeleccionado.Precio;
                decimal totalFila = precio * cantidadSeleccionada;

                totalComboBox -= totalFila; // Restamos este total del total general
                ActualizarTotalGeneral(); // Actualizamos la etiqueta lblTotal
            }
        }
        private void GuardarVenta()
        {
            // Crear las consultas SQL
            string consultaVentas = "INSERT INTO ventas (fechadecompra, total, peso) VALUES (@fechadecompra, @total, @peso)";
            string consultaDetalleVentas = "INSERT INTO detalle_ventas (idventa, producto, cantidad, precio_unitario, subtotal, peso) " +
                                          "VALUES (@idventa, @producto, @cantidad, @precio_unitario, @subtotal, @peso)";
            string consultaActualizarStock = "UPDATE stock " +
                                             "SET cantidad = cantidad - @cantidad " +
                                             "WHERE idproductosyprecios = (SELECT idproductosyprecios FROM productosyprecios WHERE producto = @producto)";
            string consultaObtenerStock = "SELECT cantidad FROM stock WHERE idproductosyprecios = (SELECT idproductosyprecios FROM productosyprecios WHERE producto = @producto)";

            // Listas para almacenar productos y cantidades
            List<string> productosSeleccionados = new List<string>();
            List<int> cantidadesSeleccionadas = new List<int>();
            List<double> pesosSeleccionados = new List<double>();
            List<decimal> subtotales = new List<decimal>();

            // Recoger datos del ComboBox estático
            if (productos.SelectedItem is ProductosYPrecios productoSeleccionadoEstatico &&
                cantidad.SelectedItem is int cantidadSeleccionadaEstatica && cantidadSeleccionadaEstatica > 0)
            {
                productosSeleccionados.Add(productoSeleccionadoEstatico.Producto);
                cantidadesSeleccionadas.Add(cantidadSeleccionadaEstatica);
                pesosSeleccionados.Add(0);
                subtotales.Add(productoSeleccionadoEstatico.Precio * cantidadSeleccionadaEstatica);
            }

            // Recoger datos de los ComboBox dinámicos
            foreach (var child in contenedorComboBoxes.Children)
            {
                if (child is Grid grid)
                {
                    ComboBox productoComboBox = null;
                    ComboBox cantidadComboBox = null;
                    ComboBox pesoComboBox = null;

                    foreach (var element in grid.Children)
                    {
                        if (element is ComboBox comboBox)
                        {
                            if (comboBox.Name == "productos")
                                productoComboBox = comboBox;
                            else if (comboBox.Name == "cantidad")
                                cantidadComboBox = comboBox;
                            else if (comboBox.Name == "peso")
                                pesoComboBox = comboBox;
                        }
                    }

                    if (productoComboBox?.SelectedItem is ProductosYPrecios productoSeleccionado &&
                        cantidadComboBox?.SelectedItem is int cantidadSeleccionada &&
                        pesoComboBox?.SelectedItem is double pesoSeleccionado)
                    {
                        productosSeleccionados.Add(productoSeleccionado.Producto);
                        cantidadesSeleccionadas.Add(cantidadSeleccionada);
                        pesosSeleccionados.Add(pesoSeleccionado);
                        subtotales.Add(productoSeleccionado.Precio * cantidadSeleccionada);
                    }
                }
            }

            // Validar si hay suficiente stock antes de continuar
            using (MySqlConnection conexionBD = conexion.conexion())
            {
                conexionBD.Open();
                for (int i = 0; i < productosSeleccionados.Count; i++)
                {
                    MySqlCommand cmdObtenerStock = new MySqlCommand(consultaObtenerStock, conexionBD);
                    cmdObtenerStock.Parameters.AddWithValue("@producto", productosSeleccionados[i]);

                    object stockResult = cmdObtenerStock.ExecuteScalar();
                    int stockDisponible = stockResult != null ? Convert.ToInt32(stockResult) : 0;

                    if (cantidadesSeleccionadas[i] > stockDisponible)
                    {
                        MessageBox.Show($"No hay suficiente stock para {productosSeleccionados[i]}. Stock disponible: {stockDisponible} unidades.", "Stock insuficiente", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return; // Detiene la ejecución si no hay suficiente stock
                    }
                }
            }

            // Calcular total de la venta y peso total
            decimal totalVenta = subtotales.Sum();
            double pesoTotal = pesosSeleccionados.Sum();

            // Insertar en la tabla 'ventas'
            int idventa;
            using (MySqlConnection conexionBD = conexion.conexion())
            {
                conexionBD.Open();
                MySqlCommand cmdVentas = new MySqlCommand(consultaVentas, conexionBD);
                cmdVentas.Parameters.AddWithValue("@fechadecompra", DateTime.Now);
                cmdVentas.Parameters.AddWithValue("@total", totalVenta);
                cmdVentas.Parameters.AddWithValue("@peso", pesoTotal);

                cmdVentas.ExecuteNonQuery();
                idventa = (int)cmdVentas.LastInsertedId;
            }

            // Insertar detalles de la venta y actualizar el stock
            using (MySqlConnection conexionBD = conexion.conexion())
            {
                conexionBD.Open();
                foreach (var producto in productosSeleccionados)
                {
                    MySqlCommand cmdDetalle = new MySqlCommand(consultaDetalleVentas, conexionBD);
                    int index = productosSeleccionados.IndexOf(producto);

                    cmdDetalle.Parameters.AddWithValue("@idventa", idventa);
                    cmdDetalle.Parameters.AddWithValue("@producto", producto);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", cantidadesSeleccionadas[index]);
                    cmdDetalle.Parameters.AddWithValue("@precio_unitario", listaProductos.FirstOrDefault(p => p.Producto == producto)?.Precio);
                    cmdDetalle.Parameters.AddWithValue("@subtotal", subtotales[index]);
                    cmdDetalle.Parameters.AddWithValue("@peso", pesosSeleccionados[index]);

                    cmdDetalle.ExecuteNonQuery();

                    // Actualizar la cantidad en stock
                    MySqlCommand cmdActualizarStock = new MySqlCommand(consultaActualizarStock, conexionBD);
                    cmdActualizarStock.Parameters.AddWithValue("@cantidad", cantidadesSeleccionadas[index]);
                    cmdActualizarStock.Parameters.AddWithValue("@producto", producto);

                    cmdActualizarStock.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Compra cargada exitosamente.");
            this.NavigationService.Navigate(new Ventas());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Verificar que todos los ComboBox tengan un valor seleccionado
            if (productos.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un producto.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (cantidad.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione una cantidad.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (peso.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un peso.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            GuardarVenta();
        }
        private void cantidad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalcularTotal();
        }


        private void productos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalcularTotal();
        }

    }
}