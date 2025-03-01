using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.Types;
using MySql.Data.MySqlClient;

namespace Proyecto.Clases
{
    class Conexion
    {
        public MySqlConnection conexion()
        {
            string server = "127.0.0.1";
            string port = "3306";
            string database = "bd_proyecto_final22";
            string uid = "root";
            string password = "root";

            string cadenaConexion = $"server={server}; port={port}; database={database}; uid={uid}; password={password};";

            try
            {
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
                return conexionBD;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error de conexion." + ex.Message);
                return null;
            }


        }
    }
}
