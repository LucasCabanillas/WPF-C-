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
using Proyecto.Clases;

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

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            //Creamos una instacia de la clase codificacionContraseña
            Seguridad encriptar = new Seguridad();

            //Instruccion sql
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