using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Proyecto.Clases
{
    public class BotonRegistrar
    {
        private string nombre;
        private string apellido;
        private int dni;
        private DateTime fechaDeNacimiento;
        private int telefono;
        private string email;
        private string domicilio;
        private string localidad;
        private string provincia;
        private string contraseña;
        private DateTime fechaDeContratacion;
        private string tipoDeContrato;
        private string rango;

        private string preductos;
        private int cantidad;
        private decimal peso;
        private decimal precio;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Dni { get => dni; set => dni = value; }
        public DateTime FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }
        public string Localidad { get => localidad; set => localidad = value; }
        public string Provincia { get => provincia; set => provincia = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public DateTime FechaDeContratacion { get => fechaDeContratacion; set => fechaDeContratacion = value; }
        public string TipoDeContrato { get => tipoDeContrato; set => tipoDeContrato = value; }
        public string Rango { get => rango; set => rango = value; }
        public string Preductos { get => preductos; set => preductos = value; }
        public decimal Peso { get => peso; set => peso = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
    }
}
