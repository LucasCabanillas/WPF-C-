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
using static Proyecto.Viws.ProductosYprecios;

namespace Proyecto.Pedi
{
    public partial class PedidosAgregarPage : Page
    {
        private List<ProductosYPrecios> listaProductos;
        private List<Tuple<ComboBox, ComboBox, ComboBox, Button, Grid>> listaComboBoxes = new List<Tuple<ComboBox, ComboBox, ComboBox, Button, Grid>>();
        private Conexion conexion = new Conexion();

        public PedidosAgregarPage()
        {
            InitializeComponent();
            CargarProductoss();
            CargarCantidad();
            CargarPeso();
            // Llamar a la función para cargar todos los ComboBox existentes
            //CargarComboBoxes();

        }
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
            this.NavigationService.Navigate(new Pedidos());
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
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Verificar que los ComboBox fijos no estén vacíos
            if (productos.SelectedItem == null || peso.SelectedItem == null || cantidad.SelectedItem == null)
            {
                System.Windows.MessageBox.Show("Por favor, complete todos los campos.", "Error de carga", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                Conexion conexion = new Conexion();

                // Variables para almacenar la información a guardar
                string productosConcatenados = string.Empty;
                int cantidadTotal = 0;
                double pesoTotal = 0;
                decimal totalVenta = 0;

                // 1️⃣ **Procesar los valores de los ComboBox FIJOS (producto, cantidad, peso)**
                if (productos.SelectedItem is ProductosYPrecios productoFijo &&
                    cantidad.SelectedItem is int cantidadFija && cantidadFija > 0 &&
                    peso.SelectedItem is double pesoFijo)
                {
                    productosConcatenados += $"{productoFijo.Producto}({cantidadFija}) + ";
                    cantidadTotal += cantidadFija;
                    pesoTotal += pesoFijo;
                    totalVenta += productoFijo.Precio * cantidadFija; // Se suma al total
                }

                // 2️⃣ **Procesar los valores de los ComboBox DINÁMICOS dentro del contenedor**
                foreach (var child in contenedorComboBoxes.Children)
                {
                    if (child is Grid grid)
                    {
                        ComboBox cantidadComboBox = null;
                        ComboBox productoComboBox = null;
                        ComboBox pesoComboBox = null;

                        // Buscar los ComboBox dentro del Grid
                        foreach (var element in grid.Children)
                        {
                            if (element is ComboBox comboBox)
                            {
                                if (comboBox.Name == "cantidad")
                                    cantidadComboBox = comboBox;
                                else if (comboBox.Name == "productos")
                                    productoComboBox = comboBox;
                                else if (comboBox.Name == "peso")
                                    pesoComboBox = comboBox;
                            }
                        }

                        // Verificar que los ComboBox no sean nulos y tengan valores seleccionados
                        if (productoComboBox?.SelectedItem is ProductosYPrecios productoSeleccionado &&
                            cantidadComboBox?.SelectedItem is int cantidadSeleccionada && cantidadSeleccionada > 0 &&
                            pesoComboBox?.SelectedItem is double pesoSeleccionado)
                        {
                            productosConcatenados += $"{productoSeleccionado.Producto}({cantidadSeleccionada}) + ";
                            cantidadTotal += cantidadSeleccionada;
                            pesoTotal += pesoSeleccionado;
                            totalVenta += productoSeleccionado.Precio * cantidadSeleccionada; // Se suma al total
                        }
                    }
                }

                // Eliminar el último " + " de la cadena
                if (productosConcatenados.EndsWith(" + "))
                {
                    productosConcatenados = productosConcatenados.Substring(0, productosConcatenados.Length - 3);
                }

                // 3️⃣ **Guardar en la base de datos**
                using (MySqlConnection conexionBD = conexion.conexion())
                {
                    conexionBD.Open();
                    var query = @"INSERT INTO ventas (producto, cantidad, peso, precio) VALUES (@productos, @cantidad, @peso, @total)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conexionBD))
                    {
                        cmd.Parameters.AddWithValue("@productos", productosConcatenados);
                        cmd.Parameters.AddWithValue("@cantidad", cantidadTotal);
                        cmd.Parameters.AddWithValue("@peso", pesoTotal);
                        cmd.Parameters.AddWithValue("@total", totalVenta);

                        cmd.ExecuteNonQuery(); // Ejecutar la consulta

                        System.Windows.MessageBox.Show("Datos registrados exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Error al guardar los datos. Detalles: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            this.NavigationService.Navigate(new Ventas());
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