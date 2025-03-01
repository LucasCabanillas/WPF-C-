using MySql.Data.MySqlClient;
using Proyecto.Viws;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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

namespace Proyecto.PreciosyVentas
{
    /// <summary>
    /// Lógica de interacción para ProductoYPrecioModificarPage.xaml
    /// </summary>
    public partial class ProductoYPrecioModificarPage : Page
    {
        public ProductoYPrecioModificarPage(DataRowView product)
        {
            InitializeComponent();
            txtProductos.Text = product["producto"].ToString();
            txtPrecio.Text = product["precio"].ToString();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ProductosYprecios());
        }


        private void txtProductos_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {

        }

        private void txtProductos_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Validar si el campo se esta llenando y si es asi desaparece los bordes rojos por negros
            if (!string.IsNullOrWhiteSpace(txtProductos.Text))
            {
                var borde = (Border)txtProductos.Template.FindName("bordeTextBox", txtProductos);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Black; // Borde negro
                    borde.BorderThickness = new Thickness(0.5);
                }
            }
        }

        private void txtProductos_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Clases.Validaciones.ValidarCaracteres(sender, e);
        }

        private void txtProductos_LostFocus(object sender, RoutedEventArgs e)
        {
            // Borro el comienzo y final con espacios
            txtProductos.Text = txtProductos.Text.Trim();

            string texto = txtProductos.Text;

            // Obtener el TextInfo de la cultura actual(Obtiene el objeto TextInfo para la cultura actual del sistema.)
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            // Convierte el texto en minusculas
            string textoEnMinusculas = textInfo.ToLower(texto);

            // Convierte la primera letra de cada texto en mayuscula
            string textoEnMayusculas = textInfo.ToTitleCase(textoEnMinusculas);

            txtProductos.Text = textoEnMayusculas;

        }

        private void txtPrecio_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Validar si quiere ingresar un espacio no lo deje
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void txtPrecio_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Validar si el campo se esta llenando y si es asi desaparece los bordes rojos por negros
            if (!string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                var borde = (Border)txtPrecio.Template.FindName("bordeTextBox", txtPrecio);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Black; // Borde negro
                    borde.BorderThickness = new Thickness(0.5);
                }
            }
        }

        private void txtPrecio_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Clases.Validaciones.ValidarDigitos(sender, e);
        }
        private void btnCargar_Click(object sender, RoutedEventArgs e)
        {
            // Validar si los campos están vacíos
            System.Windows.Controls.TextBox[] textBoxes = { txtProductos, txtPrecio };

            foreach (var textBox in textBoxes)
            {
                var borde = (Border)textBox.Template.FindName("bordeTextBox", textBox);
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    if (borde != null)
                    {
                        borde.BorderBrush = Brushes.Red;
                        borde.BorderThickness = new Thickness(1);
                    }
                    return; // Salir si algún campo está vacío
                }
                else if (borde != null)
                {
                    borde.BorderBrush = Brushes.Black;
                    borde.BorderThickness = new Thickness(0.5);
                }
            }

            try
            {
                Clases.Conexion conexion = new Clases.Conexion();
                Clases.BotonRegistrar botonRegistrar = new Clases.BotonRegistrar();

                botonRegistrar.Preductos = txtProductos.Text;
                botonRegistrar.Precio = decimal.Parse(txtPrecio.Text);

                using (MySqlConnection conexionBD = conexion.conexion())
                {
                    conexionBD.Open();

                    // Obtener el ID del producto antes de actualizar
                    string getIdQuery = "SELECT idproductosyprecios FROM productosyprecios WHERE producto = @producto";
                    int idProducto = 0;

                    using (MySqlCommand cmdGetId = new MySqlCommand(getIdQuery, conexionBD))
                    {
                        cmdGetId.Parameters.AddWithValue("@producto", botonRegistrar.Preductos);
                        var result = cmdGetId.ExecuteScalar();
                        if (result != null)
                        {
                            idProducto = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("El producto no existe.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }

                    // Actualizar productosyprecios
                    string updateProductosQuery = @"UPDATE productosyprecios SET producto = @producto, precio = @precio WHERE idproductosyprecios = @idProducto";
                    using (MySqlCommand cmdProductos = new MySqlCommand(updateProductosQuery, conexionBD))
                    {
                        cmdProductos.Parameters.AddWithValue("@idProducto", idProducto);
                        cmdProductos.Parameters.AddWithValue("@producto", botonRegistrar.Preductos);
                        cmdProductos.Parameters.AddWithValue("@precio", botonRegistrar.Precio);
                        cmdProductos.ExecuteNonQuery();
                    }

                    // Actualizar stock
                    string updateStockQuery = @"UPDATE stock SET precio = @precio WHERE idproductosyprecios = @idProducto";
                    using (MySqlCommand cmdStock = new MySqlCommand(updateStockQuery, conexionBD))
                    {
                        cmdStock.Parameters.AddWithValue("@idProducto", idProducto);
                        cmdStock.Parameters.AddWithValue("@precio", botonRegistrar.Precio);
                        cmdStock.ExecuteNonQuery();
                    }

                    MessageBox.Show("Precio actualizado en ambas tablas.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el precio: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
