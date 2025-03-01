using System.Net.Http.Headers;
using System.Printing.IndexedProperties;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FontAwesome;
using FontAwesome.Sharp;
using MySql.Data.MySqlClient;
using Proyecto.Clases;
using Proyecto.Pedi;
using Proyecto.Viws;

namespace Proyecto
{

    public partial class MainWindow : Window
    {
        private bool iconOjoContraseña = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void txtContrsaña_TextChanged(object sender, TextChangedEventArgs e)
        {



        }

        private void EyeIcon_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            iconOjoContraseña = !iconOjoContraseña; // Alternar estado
            if (iconOjoContraseña)
            {
                // Cambiar el ícono a "Eye"
                ojoContraseña.Icon = FontAwesome.Sharp.IconChar.Eye;
                // Mostrar contraseña en el TextBox
                txtContraseñaVisible.Text = txtContraseña.Password;
                txtContraseñaVisible.Visibility = Visibility.Visible;
                txtContraseña.Visibility = Visibility.Collapsed;
                txtContraseñaVisible.IsReadOnly = false;

            }
            else
            {
                txtContraseña.Visibility = Visibility.Visible;
                txtContraseñaVisible.Visibility = Visibility.Collapsed;
                txtContraseñaVisible.IsReadOnly = true;
                ojoContraseña.Icon = FontAwesome.Sharp.IconChar.EyeSlash;
            }
        }
        private void TogglePasswordVisibility_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        }


        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {

        }
        public static class Sesion
        {
            public static string Rango { get; set; }
        }
        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            string dni = txtDNI.Text;
            string contraseña = txtContraseña.Password;

            // Validar si las credenciales son correctas
            if (ValidarLogin(dni, contraseña))
            {
                
                // Obtener el rango y el nombre del usuario
                string rango = ObtenerRango(dni);
                string nombreUsuario = ObtenerNombreUsuario(dni);

                

                // Realizamos alguna acción según el rango
                if (rango == "Empleado")
                {
                    Principal principal = new Principal(); // Pasar el DNI al constructor
                    principal.Show();

                    // Asignar el nombre al TextBlock de la vista
                    principal.nombreDelPersonal.Text = nombreUsuario;
                    // Si el rango es "Empleado", navegar a PedidosAgregarPage y pasar el nombreUsuario
                    PedidosAgregarPage pedidosPage = new PedidosAgregarPage(nombreUsuario);

                    principal.btnStock.Visibility = Visibility.Collapsed;
                    principal.btnPersonal.Visibility = Visibility.Collapsed;
                    principal.btnPrecios.Visibility = Visibility.Collapsed;
                    principal.btnPdf.Visibility = Visibility.Collapsed;
                    principal.btnStock.Visibility = Visibility.Collapsed;
                }
                else { if (rango == "Gerente"){
                        Principal principal = new Principal(); // Pasar el DNI al constructor
                        principal.Show();
                        // Si el rango es "Empleado", navegar a PedidosAgregarPage y pasar el nombreUsuario
                        PedidosAgregarPage pedidosPage = new PedidosAgregarPage(nombreUsuario);
                        // Asignar el nombre al TextBlock de la vista
                        principal.nombreDelPersonal.Text = nombreUsuario;

                        principal.btnPersonal.Visibility = Visibility.Collapsed;
                        principal.btnPrecios.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        if (rango == "Jefe")
                        {
                            Principal principal = new Principal(); // Pasar el DNI al constructor
                            principal.Show();
                            // Si el rango es "Empleado", navegar a PedidosAgregarPage y pasar el nombreUsuario
                            PedidosAgregarPage pedidosPage = new PedidosAgregarPage(nombreUsuario);
                            // Asignar el nombre al TextBlock de la vista
                            principal.nombreDelPersonal.Text = nombreUsuario;
                        }
                    }
                }

                    // Cerrar la ventana de login
                    this.Close();
            }
            else
            {
                System.Windows.MessageBox.Show("Credenciales incorrectas.");
            }
        }


        private bool ValidarLogin(string dni, string contraseña)
        {
            // Instanciamos la clase Seguridad para poder desencriptar la contraseña
            Seguridad seguridad = new Seguridad();
            Conexion conexion = new Conexion();
            using (MySqlConnection conn = conexion.conexion())
            {
                string query = "SELECT contraseña FROM register_login WHERE dni = @dni";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dni", dni);

                conn.Open();
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    // Desencriptamos la contraseña almacenada en la base de datos
                    string contraseñaEncriptada = result.ToString();
                    string contraseñaDesencriptada = seguridad.Decrypt(contraseñaEncriptada);

                    // Comparamos la contraseña ingresada con la desencriptada
                    return contraseña == contraseñaDesencriptada;
                }
                return false; // Si no se encuentra el DNI, devolvemos false
            }
        }

        private string ObtenerRango(string dni)
        {
            Conexion conexion = new Conexion();
            // Consulta el rango del usuario
            using (MySqlConnection conn = conexion.conexion())
            {
                string query = "SELECT rango FROM register_login WHERE dni = @dni";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dni", dni);

                conn.Open();
                var result = cmd.ExecuteScalar();
                return result?.ToString(); // Devuelve el rango (por ejemplo, "Jefe", "Empleado")
            }
        }
        private string ObtenerNombreUsuario(string dni)
        {
            string nombreCompleto = string.Empty;
            Conexion conexion = new Conexion();
            // Asumimos que tienes una conexión a la base de datos
            using (MySqlConnection conn = conexion.conexion())
            {
                string query = "SELECT nombre, apellido FROM register_login WHERE dni = @dni";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dni", dni);

                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string nombre = reader["nombre"].ToString();
                        string apellido = reader["apellido"].ToString();

                        // Concatenamos nombre y apellido
                        nombreCompleto = nombre + " " + apellido;
                    }
                }
            }

            return nombreCompleto;
        }

        private void txtDNI_LostFocus(object sender, RoutedEventArgs e)
        {
            // Si la longitudad del DNI es menor a 8 entonces miestra que error en el textbox (marcando en rojo este)
            if (txtDNI.Text.Length < 8)
            {
                var borde = (Border)txtDNI.Template.FindName("bordeTextBox", txtDNI);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Red; // Borde Rojo
                    borde.BorderThickness = new Thickness(1);
                }
            }
            else
            {
                var borde = (Border)txtDNI.Template.FindName("bordeTextBox", txtDNI);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Black; // Borde Negro
                    borde.BorderThickness = new Thickness(0.5);
                }
            }
        }

        private void txtDNI_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void txtDNI_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Validar si el campo se esta llenando y si es asi desaparece los bordes rojos por negros
            if (!string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                var borde = (Border)txtDNI.Template.FindName("bordeTextBox", txtDNI);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Black; // Borde negro
                    borde.BorderThickness = new Thickness(0.5);
                }
            }
        }

        private void txtDNI_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validaciones.ValidarDigitos(sender, e);
            //arreglar esta validacion
            if (txtDNI.Text.Length >= 8)
            {
                e.Handled = true;  // Evitar que se ingrese el nuevo carácter
            }
        }

        private void txtContraseñaVisible_LostFocus(object sender, RoutedEventArgs e)
        {
            txtContraseñaVisible.Text = txtContraseñaVisible.Text.Trim();
        }

        private void txtContraseñaVisible_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtContraseñaVisible.Visibility == Visibility.Visible)
            {
                txtContraseña.Password = txtContraseñaVisible.Text;
            }
            if (!string.IsNullOrWhiteSpace(txtContraseñaVisible.Text))
            {
                var borde = (Border)txtContraseñaVisible.Template.FindName("bordeTextBox", txtContraseñaVisible);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Black;
                    borde.BorderThickness = new Thickness(0.5);
                }
            }
            
        }

        private void txtContraseña_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtContraseñaVisible.Visibility == Visibility.Visible)
            {
                txtContraseñaVisible.Text = txtContraseña.Password;
            }
            if (!string.IsNullOrWhiteSpace(txtContraseña.Password))
            {
                var borde = (Border)txtContraseña.Template.FindName("bordePassword", txtContraseña);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Black; // Borde rojo
                    borde.BorderThickness = new Thickness(0.5);
                }
            }
            txtContraseña.Password = txtContraseña.Password.Trim();
        }
    }
}