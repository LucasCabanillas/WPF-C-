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
using MySql.Data.MySqlClient;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using Proyecto.CDU;
using Proyecto.Clases;

namespace Proyecto.Viws
{
    /// <summary>
    /// Lógica de interacción para Usuarios.xaml
    /// </summary>
    public partial class Usuarios : UserControl
    {
        public Usuarios()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void txtBuscarPorDni_LostFocus(object sender, RoutedEventArgs e)
        {
            txtBuscarPorDni.Text = txtBuscarPorDni.Text.Trim();
        }

        private void txtBuscarPorDni_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBuscarPorDni.Text))
            {
                var borde = (Border)txtBuscarPorDni.Template.FindName("bordeTextBox", txtBuscarPorDni);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Black;
                    borde.BorderThickness = new Thickness(0.5);
                }

            }
        }

        private void txtBuscarPorDni_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validaciones.ValidarDigitos(sender, e);
            if (txtBuscarPorDni.Text.Length > 7)
            {
                e.Handled = true;
            }
        }

        private void txtBuscarPorDni_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
        private void btnBuscarPorDNI_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscarPorDni.Text) || txtBuscarPorDni.Text.Length < 8)
            {
                var borde = (Border)txtBuscarPorDni.Template.FindName("bordeTextBox", txtBuscarPorDni);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Red;
                    borde.BorderThickness = new Thickness(1);
                }
            }


            try
            {
                // Creamos una instancia de la clase Conexion
                Conexion conexion = new Conexion();
                // Creamos una instancia de la clase Conxion
                BotonRegistrar botonRegistrar = new BotonRegistrar();

                botonRegistrar.Dni = int.Parse(txtBuscarPorDni.Text);

                using (MySqlConnection conexionBD = conexion.conexion() )
                {
                    conexionBD.Open();
                    var queryCheckDni = "SELECT * FROM register_login WHERE dni = @dni";
                    using (MySqlCommand cmdBuscar = new MySqlCommand(queryCheckDni, conexionBD))
                    {
                        cmdBuscar.Parameters.AddWithValue("@dni", botonRegistrar.Dni);
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmdBuscar))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            // Verificamos si se encontraron resultados
                            if (dataTable.Rows.Count > 0)
                            {
                                // Mostrar datos en el DataGrid
                                datagridusuarios.ItemsSource = dataTable.DefaultView;
                            }
                            else
                            {
                                System.Windows.MessageBox.Show("Usuario no encontrado.", "Error al encontrar al usuario.", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                    }
                }
            }
            catch{ System.Windows.MessageBox.Show("Por favor, ingrese el DNI para encontrar al usuario.", "Error", MessageBoxButton.OK, MessageBoxImage.Information); }
        }

        private void DataGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {

        }
        private void CargarDatos()
        {
            Conexion conexion = new Conexion();
            try
            {
                using (MySqlConnection conexionBD = conexion.conexion())
                {
                    conexionBD.Open();
                    string query = "SELECT dni, nombre, apellido, fechaDeNacimiento, telefono, email, domicilio, localidad,provincia, contraseña, fechaDeContratacion, tipoDeContrato, rango FROM register_login ORDER BY dni ASC"; // Consulta para obtener los datos
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

        private void btnAgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
            RegisterPage registerPage = new RegisterPage();
            frameRegistrarUsuario.Content = registerPage;
        }

        private void datagridusuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btnModificarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (datagridusuarios.SelectedItem != null)
            {
                // Obtén la fila seleccionada como DataRowView
                DataRowView filaSeleccionada = (DataRowView)datagridusuarios.SelectedItem;
                // Crear una instancia de ModificarPersonal pasando la fila seleccionada
                ModificarPersonal modificarPersonal = new ModificarPersonal(filaSeleccionada);

                // Mostrar la ventana de modificación
                frameRegistrarUsuario.Content = modificarPersonal; 
            }   
            else
            {
                MessageBox.Show("Por favor, seleccione un usuario para modificar.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void frameRegistrarUsuario_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}