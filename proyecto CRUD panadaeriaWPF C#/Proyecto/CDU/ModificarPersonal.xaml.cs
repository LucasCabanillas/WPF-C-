using FontAwesome.Sharp;
using MySql.Data.MySqlClient;
using Mysqlx;
using Proyecto.Clases;
using Proyecto.Viws;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Proyecto.CDU
{
    /// <summary>
    /// Lógica de interacción para Register.xaml
    /// </summary>
    public partial class ModificarPersonal 
    {
        private bool iconOjoContraseña = false;
        private bool iconOjoRepetirContraseña = false;
        private DataRowView usuarioSeleccionado;
        Seguridad codificar = new Seguridad();
        public ModificarPersonal(DataRowView usuario)
        {
            InitializeComponent();
            tipoDeContrato.Items.Add("Prueba");
            tipoDeContrato.Items.Add("Efectivo");
            rango.Items.Add("Empleado");
            rango.Items.Add("Gerente");
            rango.Items.Add("Jefe");
            usuarioSeleccionado = usuario; // Guarda la referencia al usuario seleccionado
            txtNombre.Text = usuario["nombre"].ToString();
            txtApellido.Text = usuario["apellido"].ToString();
            txtEmail.Text = usuario["email"].ToString();
            txtTelefono.Text = usuario["telefono"].ToString();
            txtDNI.Text = usuario["dni"].ToString();
            txtLocalidad.Text = usuario["localidad"].ToString();
            txtDomicilio.Text = usuario["domicilio"].ToString();
            txtProvincia.Text = usuario["provincia"].ToString();
            txtContraseña.Password = codificar.Decrypt(usuario["contraseña"].ToString());
            txtRepetirContraseña.Password = codificar.Decrypt(usuario["contraseña"].ToString());
            //txtContraseña.Password = usuario["contraseña"].ToString();
            tipoDeContrato.Text = usuario["tipoDeContrato"].ToString();
            rango.Text = usuario["rango"].ToString();
            fechaDeNacimiento.Text = usuario["fechaDeNacimiento"].ToString();
            fechaDeContratacion.Text = usuario["fechaDeContratacion"].ToString();


        }
        public static bool ValidarEmail(string email)
        {
            // Expresión regular que asegura que se ingrese solo digitos y un caracter especial
            Regex regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return regex.IsMatch(email);
        }



        private void EyeIcon_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            iconOjoContraseña = !iconOjoContraseña; // Alternar estado
            if (iconOjoContraseña)
            {
                // Cambiar el ícono a "Eye"
                ojoContraseña.Icon = FontAwesome.Sharp.IconChar.EyeSlash;
                // Mostrar contraseña en el TextBox
                txtContraseñaPrimariaVisible.Text = txtContraseña.Password;
                txtContraseñaPrimariaVisible.Visibility = Visibility.Visible;
                txtContraseña.Visibility = Visibility.Collapsed;
                txtContraseñaPrimariaVisible.IsReadOnly = false;

            }
            else
            {
                ojoContraseña.Icon = FontAwesome.Sharp.IconChar.Eye;
                txtContraseña.Visibility = Visibility.Visible;
                txtContraseñaPrimariaVisible.Visibility = Visibility.Collapsed;
                txtContraseñaPrimariaVisible.IsReadOnly = true;
            }
        }

        private void txtContraseñaPrimariaVisible_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtContraseñaPrimariaVisible.Visibility == Visibility.Visible)
            {
                txtContraseña.Password = txtContraseñaPrimariaVisible.Text;
            }
            if (!string.IsNullOrWhiteSpace(txtContraseñaPrimariaVisible.Text))
            {
                var borde = (Border)txtContraseñaPrimariaVisible.Template.FindName("bordeTextBox", txtContraseñaPrimariaVisible);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Black;
                    borde.BorderThickness = new Thickness(0.5);
                }

            }
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {

        }


        private void txtNombre_LostFocus(object sender, RoutedEventArgs e)
        {
            // Borro el comienzo y final con espacios
            txtNombre.Text = txtNombre.Text.Trim();

            // Acceder al texto del TextBox
            string texto = txtNombre.Text;

            // Obtener el TextInfo de la cultura actual (Obtiene el objeto TextInfo para la cultura actual del sistema.)
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            // Convierte todo a minuscula
            string textoEnMinuscula = textInfo.ToLower(texto);

            // Convierte la primera letra de cada texto en mayuscula
            string textoEnMayusculas = textInfo.ToTitleCase(textoEnMinuscula);

            // Asignar el texto modificado de vuelta al TextBox
            txtNombre.Text = textoEnMayusculas;

            if (txtNombre.Text.Length < 3)
            {

            }
        }

        private void txtNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Validar si el campo se esta llenando y si es asi desaparece los bordes rojos por negros
            if (!string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                var borde = (Border)txtNombre.Template.FindName("bordeTextBox", txtNombre);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Black; // Borde negro
                    borde.BorderThickness = new Thickness(0.5);
                }
            }
        }

        private void txtNombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validaciones.ValidarCaracteres(sender, e);
        }

        private void txtApellido_LostFocus(object sender, RoutedEventArgs e)
        {
            // Borro el comienzo y final con espacios
            txtApellido.Text = txtApellido.Text.Trim();

            // Acceder al texto del TextBox
            string texto = txtApellido.Text;

            // Obtener el TextInfo de la cultura actual (Obtiene el objeto TextInfo para la cultura actual del sistema.)
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            // Convierte el texto en minusculas
            string textoEnMinusculas = textInfo.ToLower(texto);

            // Convierte la primera letra de cada texto en mayuscula
            string textoEnMayusculas = textInfo.ToTitleCase(textoEnMinusculas);

            // Asignar el texto modificado de vuelta al TextBox
            txtApellido.Text = textoEnMayusculas;

        }

        private void txtApellido_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Validar si el campo se esta llenando y si es asi desaparece los bordes rojos por negros
            if (!string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                var borde = (Border)txtApellido.Template.FindName("bordeTextBox", txtApellido);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Black; // Borde negro
                    borde.BorderThickness = new Thickness(0.5);
                }
            }
        }

        private void txtApellido_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validaciones.ValidarCaracteres(sender, e);
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

        private void txtDNI_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // Validar si quiere ingresar un espacio no lo deje
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void fechaDeNacimiento_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void fechaDeNacimiento_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validaciones.ValidarFehcas(sender, e);
        }

        private void fechaDeNacimiento_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void fechaDeNacimiento_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // Si la fecha ingresada conincide con la actual entonces 
            if (fechaDeNacimiento.SelectedDate.HasValue)
            {
                DateTime fechaSeleccionada = fechaDeNacimiento.SelectedDate.Value;
                DateTime fechaActual = DateTime.Now.Date;

                if (fechaSeleccionada >= fechaActual)
                {
                    fechaDeNacimiento.SelectedDate = null;
                    var borde = (Border)fechaDeNacimiento.Template.FindName("bordeDatePicker", fechaDeNacimiento);
                    if (borde != null)
                    {
                        borde.BorderBrush = Brushes.Red; // Borde rojo
                        borde.BorderThickness = new Thickness(0.5);
                    }

                }
                else
                {
                    // Si es menor de edad
                    if (fechaSeleccionada.AddYears(18) >= fechaActual)
                    {
                        fechaDeNacimiento.SelectedDate = null;
                        var borde = (Border)fechaDeNacimiento.Template.FindName("bordeDatePicker", fechaDeNacimiento);
                        if (borde != null)
                        {
                            borde.BorderBrush = Brushes.Red; // Borde rojo
                            borde.BorderThickness = new Thickness(1);
                        }


                    }
                    // Si es mayor de edad
                    else
                    {
                        var borde = (Border)fechaDeNacimiento.Template.FindName("bordeDatePicker", fechaDeNacimiento);
                        if (borde != null)
                        {
                            borde.BorderBrush = Brushes.Black; // Borde negro
                            borde.BorderThickness = new Thickness(0.5);
                        }
                    }

                }

            }
        }

        private void txtTelefono_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtTelefono.Text.Length < 10)
            {
                var borde = (Border)txtTelefono.Template.FindName("bordeTextBox", txtTelefono);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Red; // Borde Negro
                    borde.BorderThickness = new Thickness(1);
                }
                return;
            }
            else
            {
                var borde = (Border)txtTelefono.Template.FindName("bordeTextBox", txtTelefono);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Black; // Borde Negro
                    borde.BorderThickness = new Thickness(0.5);
                }
            }
        }

        private void txtTelefono_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
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
        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (!ValidarEmail(txtEmail.Text))
            {
                var borde = (Border)txtEmail.Template.FindName("bordeTextBox", txtEmail);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Red; // Borde rojo
                    borde.BorderThickness = new Thickness(1);
                }
            }
            else
            {
                var borde = (Border)txtEmail.Template.FindName("bordeTextBox", txtEmail);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Black; // Borde rojo
                    borde.BorderThickness = new Thickness(0.5);
                }
            }

        }

        private void txtEmail_LostFocus(object sender, RoutedEventArgs e)
        {

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

        private void txtDomicilio_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void txtLocalidad_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validaciones.ValidarAlphanumericos(sender, e);
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

        private void txtProvincia_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validaciones.ValidarCaracteres(sender, e);
        }

        private void txtContraseña_LostFocus(object sender, RoutedEventArgs e)
        {
            txtContraseña.Password = txtContraseña.Password.Trim();
        }

        private void txtContraseña_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txtContraseñaPrimariaVisible.Visibility == Visibility.Visible)
            {
                txtContraseñaPrimariaVisible.Text = txtContraseña.Password;
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
            txtContraseñaPrimariaVisible.Text = txtContraseña.Password;
        }

        private void txtRepetirContraseña_LostFocus(object sender, RoutedEventArgs e)
        {
            txtRepetirContraseña.Password = txtRepetirContraseña.Password.Trim();
        }

        private void txtRepetirContraseña_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txtContraseñaVisible.Visibility == Visibility.Visible)
            {
                txtContraseñaVisible.Text = txtRepetirContraseña.Password;
            }
            if (!string.IsNullOrWhiteSpace(txtRepetirContraseña.Password))
            {
                var borde = (Border)txtRepetirContraseña.Template.FindName("bordePassword", txtRepetirContraseña);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Black; // Borde rojo
                    borde.BorderThickness = new Thickness(0.5);
                }
            }
            txtContraseñaVisible.Text = txtRepetirContraseña.Password;
        }

        private void txtContraseñaVisible_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtContraseñaVisible.Visibility == Visibility.Visible)
            {
                txtRepetirContraseña.Password = txtContraseñaVisible.Text;
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

        private void EyeIconRepetir_Click(object sender, MouseButtonEventArgs e)
        {
            iconOjoRepetirContraseña = !iconOjoRepetirContraseña; // Alternar estado
            if (iconOjoRepetirContraseña)
            {
                // Cambiar el ícono a "Eye"
                ojoRepetirContraseña.Icon = FontAwesome.Sharp.IconChar.EyeSlash;
                // Mostrar contraseña en el TextBox
                txtContraseñaVisible.Text = txtRepetirContraseña.Password;
                txtContraseñaVisible.Visibility = Visibility.Visible;
                txtRepetirContraseña.Visibility = Visibility.Collapsed;
                txtContraseñaVisible.IsReadOnly = false;
            }
            else
            {
                // Cambiar el ícono a "EyeSlash"
                ojoRepetirContraseña.Icon = FontAwesome.Sharp.IconChar.Eye;
                // Volver a ocultar la contraseña en el PasswordBox
                txtRepetirContraseña.Visibility = Visibility.Visible;
                txtContraseñaVisible.Visibility = Visibility.Collapsed;
                txtContraseñaVisible.IsReadOnly = true;

            }
            // Actualizar el TextBox cuando el PasswordBox cambie
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            // Crear una lista de los TextBox que quieres validar
            System.Windows.Controls.TextBox[] textBoxes = { txtNombre, txtDNI, txtApellido, txtEmail, txtTelefono, txtDomicilio, txtLocalidad, txtProvincia };
            System.Windows.Controls.DatePicker[] datePickers = { fechaDeNacimiento, fechaDeContratacion };
            System.Windows.Controls.PasswordBox[] passwordBoxes = { txtContraseña, txtRepetirContraseña };
            System.Windows.Controls.ComboBox[] comboBoxes = { rango, tipoDeContrato };

            // Bandera para verificar si hay errores
            bool hayError = false;
            
            foreach (var textBox in textBoxes)
            {
                // Verificar si el TextBox está vacío
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    hayError = true;
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
            foreach (var datePicker in datePickers)
            {
                // Verificar si el TextBox está vacío
                if (datePicker.SelectedDate == null)
                {
                    hayError = true;
                    // Acceder al borde dentro del Template
                    var borde = (Border)datePicker.Template.FindName("bordeDatePicker", datePicker);
                    if (borde != null)
                    {
                        borde.BorderBrush = Brushes.Red; // Cambiar el borde a rojo
                        borde.BorderThickness = new Thickness(1);
                    }
                }
                else
                {
                    // Restaurar el borde si no está vacío
                    var borde = (Border)datePicker.Template.FindName("bordeDatePicker", datePicker);
                    if (borde != null)
                    {
                        borde.BorderBrush = Brushes.Black; // Restaurar el borde
                        borde.BorderThickness = new Thickness(0.5);
                    }
                }
            }
            foreach (var passwordBox in passwordBoxes)
            {
                // Verificar si el TextBox está vacío
                if (string.IsNullOrWhiteSpace(passwordBox.Password))
                {
                    hayError = true;
                    // Acceder al borde dentro del Template
                    var borde = (Border)passwordBox.Template.FindName("bordePassword", passwordBox);
                    if (borde != null)
                    {
                        borde.BorderBrush = Brushes.Red; // Cambiar el borde a rojo
                        borde.BorderThickness = new Thickness(1);
                    }
                }
                else
                {
                    // Restaurar el borde si no está vacío
                    var borde = (Border)passwordBox.Template.FindName("bordePassword", passwordBox);
                    if (borde != null)
                    {
                        borde.BorderBrush = Brushes.Black; // Restaurar el borde
                        borde.BorderThickness = new Thickness(0.5);
                    }
                }
            }
            foreach (var comboBox in comboBoxes)
            {
                // Verificar si el TextBox está vacío
                if (comboBox.SelectedItem == null)
                {
                    hayError = true;
                    // Acceder al borde dentro del Template
                    var borde = (Border)comboBox.Template.FindName("bordeComboBox", comboBox);
                    if (borde != null)
                    {
                        borde.BorderBrush = Brushes.Red; // Cambiar el borde a rojo
                        borde.BorderThickness = new Thickness(1);
                    }
                }
                else
                {
                    // Restaurar el borde si no está vacío
                    var borde = (Border)comboBox.Template.FindName("bordeComboBox", comboBox);
                    if (borde != null)
                    {
                        borde.BorderBrush = Brushes.Black; // Restaurar el borde
                        borde.BorderThickness = new Thickness(0.5);
                    }
                }
            }
            if (txtDNI.Text.Length < 8)
            {
                hayError = true;
                // Acceder al borde dentro del Template
                var borde = (Border)txtDNI.Template.FindName("bordeTextBox", txtDNI);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Red; // Cambiar el borde a rojo
                    borde.BorderThickness = new Thickness(1);
                }
            }
            else
            {
                // Acceder al borde dentro del Template
                var borde = (Border)txtDNI.Template.FindName("bordeTextBox", txtDNI);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Black; // Cambiar el borde a negro
                    borde.BorderThickness = new Thickness(0.5);
                }
            }
            if (txtTelefono.Text.Length < 8)
            {
                hayError = true;
                // Acceder al borde dentro del Template
                var borde = (Border)txtTelefono.Template.FindName("bordeTextBox", txtTelefono);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Red; // Cambiar el borde a rojo
                    borde.BorderThickness = new Thickness(1);
                }
            }
            else
            {
                // Acceder al borde dentro del Template
                var borde = (Border)txtTelefono.Template.FindName("bordeTextBox", txtTelefono);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Black; // Cambiar el borde a negro
                    borde.BorderThickness = new Thickness(0.5);
                }
            }

            if (txtRepetirContraseña.Password != txtContraseña.Password)
            {
                hayError = true;
                // Acceder al borde dentro del Template
                var borde = (Border)txtRepetirContraseña.Template.FindName("bordePassword", txtRepetirContraseña);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Red; // Cambiar el borde a rojo
                    borde.BorderThickness = new Thickness(1);
                }
            }
            else
            {
                var borde = (Border)txtRepetirContraseña.Template.FindName("bordePassWord", txtRepetirContraseña);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Black; // Cambiar el borde a rojo
                    borde.BorderThickness = new Thickness(0.5);
                }
            }

            //arreglar
            if (txtContraseñaVisible != txtContraseñaPrimariaVisible)
            {
                // Acceder al borde dentro del Template
                var borde = (Border)txtContraseñaVisible.Template.FindName("bordeTextBox", txtContraseñaVisible);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Red; // Cambiar el borde a rojo
                    borde.BorderThickness = new Thickness(1);
                }
            }
            else
            {
                var borde = (Border)txtContraseñaVisible.Template.FindName("bordeTextBox", txtContraseñaVisible);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Black; // Cambiar el borde a rojo
                    borde.BorderThickness = new Thickness(0.5);
                }
            }


            // Validación para permitir hasta 3 nombres
            string[] nombres = txtNombre.Text.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] apellido = txtApellido.Text.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            // Verificar si hay más de 3 nombres
            if (nombres.Length > 3)
            {
                hayError = true;
                // Opcional: Resaltar el TextBox con un borde rojo
                var borde = (Border)txtNombre.Template.FindName("bordeTextBox", txtNombre);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Red;
                    borde.BorderThickness = new Thickness(1);
                }
                System.Windows.MessageBox.Show("Por favor, ingrese hasta 3 nombres como máximo.", "Error de Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                // Restaurar el borde si está correcto
                var borde = (Border)txtNombre.Template.FindName("bordeTextBox", txtNombre);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Black;
                    borde.BorderThickness = new Thickness(0.5);
                }
            }
            if (txtNombre.Text.Length < 3)
            {
                var borde = (Border)txtNombre.Template.FindName("bordeTextBox", txtNombre);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Red;
                    borde.BorderThickness = new Thickness(1);
                }
            }
            else
            {
                // Restaurar el borde si está correcto
                var borde = (Border)txtNombre.Template.FindName("bordeTextBox", txtNombre);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Black;
                    borde.BorderThickness = new Thickness(0.5);
                }
            }
            if (apellido.Length > 2)
            {
                hayError = true;
                // Opcional: Resaltar el TextBox con un borde rojo
                var borde = (Border)txtApellido.Template.FindName("bordeTextBox", txtApellido);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Red;
                    borde.BorderThickness = new Thickness(1);
                }
                System.Windows.MessageBox.Show("Por favor, ingrese hasta 2 apellidos como máximo.", "Error de Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                // Restaurar el borde si está correcto
                var borde = (Border)txtApellido.Template.FindName("bordeTextBox", txtApellido);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Black;
                    borde.BorderThickness = new Thickness(0.5);
                }
            }

            if (txtApellido.Text.Length < 3)
            {
                // Opcional: Resaltar el TextBox con un borde rojo
                var borde = (Border)txtApellido.Template.FindName("bordeTextBox", txtApellido);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Red;
                    borde.BorderThickness = new Thickness(1);
                }
            }
            else
            {
                // Restaurar el borde si está correcto
                var borde = (Border)txtApellido.Template.FindName("bordeTextBox", txtApellido);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Black;
                    borde.BorderThickness = new Thickness(0.5);
                }
            }

            if (txtRepetirContraseña.Password != txtContraseña.Password || txtContraseñaVisible.Text != txtContraseñaPrimariaVisible.Text)
            {
                // Restaurar el borde si está correcto
                var borde = (Border)txtRepetirContraseña.Template.FindName("bordePassWord", txtRepetirContraseña);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Red;
                    borde.BorderThickness = new Thickness(1);
                }
                // Restaurar el borde si está correcto
                var bordetxtVisible = (Border)txtContraseñaVisible.Template.FindName("bordeTextBox", txtContraseñaVisible);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Red;
                    borde.BorderThickness = new Thickness(1);
                }
                System.Windows.MessageBox.Show("Las contraseñas no coinciden.", "Error de Contraseñas", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //cambio todo el email a minuscula
            txtEmail.Text = txtEmail.Text.ToLower();

            if (hayError == true)
            {
                System.Windows.MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error de Validación", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                // Creamos una instancia de la clase Conexion
                Conexion conexion = new Conexion();
                //Creamos una instacia de la clase codificacionContraseña
                Seguridad encriptar = new Seguridad();
                // Contructor para datos
                BotonRegistrar botonRegistrar = new BotonRegistrar();
                botonRegistrar.Nombre = txtNombre.Text;
                botonRegistrar.Apellido = txtApellido.Text;
                botonRegistrar.Email = txtEmail.Text;
                botonRegistrar.Domicilio = txtDomicilio.Text;
                botonRegistrar.Localidad = txtLocalidad.Text;
                botonRegistrar.Provincia = txtProvincia.Text;
                botonRegistrar.Contraseña = encriptar.Encrypt(txtContraseña.Password);
                botonRegistrar.TipoDeContrato = tipoDeContrato.Text;
                botonRegistrar.Rango = rango.Text;
                botonRegistrar.Dni = int.Parse(txtDNI.Text);
                botonRegistrar.Telefono = int.Parse(txtTelefono.Text);
                botonRegistrar.FechaDeNacimiento = DateTime.Parse(fechaDeNacimiento.Text);
                botonRegistrar.FechaDeContratacion = DateTime.Parse(fechaDeContratacion.Text);

                using (MySqlConnection conexionBD = conexion.conexion())
                {
                    conexionBD.Open();
                    //Instruccion sql
                    // Proceder con la inserción si el DNI no existe
                    var query = @"UPDATE register_login SET nombre = @nombre, apellido = @apellido, email = @email, domicilio = @domicilio, localidad = @localidad, provincia = @provincia, contraseña = @contraseña, tipoDeContrato = @tipoDeContrato, rango = @rango, telefono = @telefono,  fechaDeNacimiento = @fechaDeNacimiento, fechaDeContratacion = @fechaDeContratacion WHERE dni = @dni; ";
                    using (MySqlCommand cmd = new MySqlCommand(query, conexionBD))
                    {
                        cmd.Parameters.AddWithValue("@dni", botonRegistrar.Dni);
                        cmd.Parameters.AddWithValue("@nombre", botonRegistrar.Nombre);
                        cmd.Parameters.AddWithValue("@apellido", botonRegistrar.Apellido);
                        cmd.Parameters.AddWithValue("@fechaDeNacimiento", botonRegistrar.FechaDeNacimiento.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@telefono", botonRegistrar.Telefono);
                        cmd.Parameters.AddWithValue("@email", botonRegistrar.Email);
                        cmd.Parameters.AddWithValue("@domicilio", botonRegistrar.Domicilio);
                        cmd.Parameters.AddWithValue("@localidad", botonRegistrar.Localidad);
                        cmd.Parameters.AddWithValue("@provincia", botonRegistrar.Provincia);
                        cmd.Parameters.AddWithValue("@contraseña", botonRegistrar.Contraseña);
                        cmd.Parameters.AddWithValue("@fechaDeContratacion", botonRegistrar.FechaDeContratacion.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@tipoDeContrato", botonRegistrar.TipoDeContrato);
                        cmd.Parameters.AddWithValue("@rango", botonRegistrar.Rango);

                        // Ejecutar la consulta
                        cmd.ExecuteNonQuery();
                        // Mostrar un mensaje de éxito
                        System.Windows.MessageBox.Show("Datos registrados exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch(Exception ex) { System.Windows.MessageBox.Show($"Error al guardar los datos.{ex.Message} ", "Error", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            // Cargar el UserControl de Usuarios en el Frame
            Content = new Usuarios();
        }

        private void txtContraseñaPrimariaVisible_LostFocus(object sender, RoutedEventArgs e)
        {
            txtContraseñaPrimariaVisible.Text = txtContraseñaPrimariaVisible.Text.Trim();
        }

        private void txtContraseñaVisible_LostFocus(object sender, RoutedEventArgs e)
        {
            txtContraseñaVisible.Text = txtContraseñaVisible.Text.Trim();
        }

        private void fechaDeContratacion_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (fechaDeNacimiento.SelectedDate.HasValue) // Verifica si hay una fecha seleccionada
            {
                DateTime fechaescrita = fechaDeNacimiento.SelectedDate.Value; // Extrae el valor seguro

                var borde = (Border)fechaDeContratacion.Template.FindName("datePickerBorde", fechaDeContratacion);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Red;
                    borde.BorderThickness = new Thickness(1);
                }
            }
            else
            {
                var borde = (Border)fechaDeContratacion.Template.FindName("datePickerBorde", fechaDeContratacion);
                if (borde != null)
                {
                    borde.BorderBrush = Brushes.Black;
                    borde.BorderThickness = new Thickness(1);
                }
            }
        }

        private void fechaDeContratacion_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void fechaDeContratacion_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Validaciones.ValidarFehcas(sender, e);
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            // Cargar el UserControl de Usuarios en el Frame
            Content = new Usuarios();
        }
    }
}
