using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Proyecto.Clases
{
    public static class Validaciones
    {

        // Método para validar solo letras
        public static void ValidarCaracteres(object sender, TextCompositionEventArgs e)
        {
            // Expresión regular que asegura que no haya espacios al principio ni al final
            Regex regex = new Regex("^[a-zA-Z]+( [a-zA-Z]+)*$");
            e.Handled = !regex.IsMatch(e.Text);  // Bloquea el ingreso del carácter si no coincide con la regex
        }

        public static void ValidarDigitos(object sender, TextCompositionEventArgs e)
        {
            // Expresión regular que asegura que solo ingrese digitos
            Regex regex = new Regex("^[0-9]*$");
            e.Handled = !regex.IsMatch(e.Text);  // Bloquea el ingreso del carácter si no coincide con la regex
        }

        public static void ValidarDecimales(object sender, TextCompositionEventArgs e)
        {
            // Expresión regular que asegura que solo ingrese digitos
            Regex regex = new Regex("^[0-9,]*$");
            e.Handled = !regex.IsMatch(e.Text);  // Bloquea el ingreso del carácter si no coincide con la regex
        }

        public static void ValidarFehcas(object sender, TextCompositionEventArgs e)
        {
            // Expresión regular que asegura que se ingrese solo digitos y un caracter especial
            Regex regex = new Regex("^[0-9/]*$");
            e.Handled = !regex.IsMatch(e.Text);  // Bloquea el ingreso del carácter si no coincide con la regex
        }

        public static void ValidarAlphanumericos(object sender, TextCompositionEventArgs e)
        {
            // Expresión regular que asegura que se ingrese solo digitos y un caracter especial
            Regex regex = new Regex("^[a-zA-Z0-9]*$");
            e.Handled = !regex.IsMatch(e.Text);  // Bloquea el ingreso del carácter si no coincide con la regex
        }



    }
}
