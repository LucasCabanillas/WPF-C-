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
            // Crear una lista de los TextBox que quieres validar
            System.Windows.Controls.TextBox[] textBoxes = { txtProductos, txtPrecio };
            // Bandera para verificar si hay errores

            foreach (var textBox in textBoxes)
            {
                // Verificar si el TextBox está vacío
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    // Acceder al borde dentro del Template
                    var borde = (Border)textBox.Template.FindName("bordeTextBox", textBox);
                    if (borde != null)
                    {
                        borde.BorderBrush = Brushes.Red; // Cambiar el borde a rojo
                        borde.BorderThickness = new Thickness(1);
                    }
                }
                else
                {
                    // Restaurar el borde si no está vacío
                    var borde = (Border)textBox.Template.FindName("bordeTextBox", textBox);
                    if (borde != null)
                    {
                        borde.BorderBrush = Brushes.Black; // Restaurar el borde
                        borde.BorderThickness = new Thickness(0.5);
                    }
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

                    var query = @"UPDATE productosyprecios SET  producto = @producto, precio = @precio WHERE producto = @producto";
                    using (MySqlCommand cmd = new MySqlCommand(query, conexionBD))
                    {
                        cmd.Parameters.AddWithValue("@producto", botonRegistrar.Preductos);
                        cmd.Parameters.AddWithValue("@precio", botonRegistrar.Precio);

                        cmd.ExecuteNonQuery();
                        // Mostrar un mensaje de éxito
                        System.Windows.MessageBox.Show("Datos registrados exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }

            }
            catch (Exception ex)
            {
                {
                    System.Windows.MessageBox.Show($"Error al guardar los datos. ex {ex}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
        }
    }
}
