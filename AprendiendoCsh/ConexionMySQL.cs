using AprendiendoCsh.Objetos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AprendiendoCsh
{

    internal class ConexionMySQL : Conexion
    {
        private MySqlConnection connection;
        private string DatosConexion;
        public ConexionMySQL()
        {
            DatosConexion = "Database=" + database +
                "; DataSource=" + server +
                "; User Id= " + user +
                "; Password=" + password + "";
            connection = new MySqlConnection(DatosConexion);
        }
        public List<Persona> Get()
        {
            List<Persona> listapersonas = new List<Persona>();

            string query = "select Nombre, ApellidoP, ApellidoM, Edad from persona";

            using (connection)
            {
                MySqlCommand consulta1 = new MySqlCommand(query,connection);
                connection.Open();
                MySqlDataReader reader = consulta1.ExecuteReader();
                while (reader.Read())
                {
                    string Nombre = reader.GetString(0);
                    string ApellidoP = reader.GetString(1);
                    string ApellidoM = reader.GetString(2);
                    int Edad = reader.GetInt32(3);
                    Persona persona = new Persona(Nombre,ApellidoP,ApellidoM,Edad);
                    listapersonas.Add(persona);
                }
                reader.Close();
                connection.Close();
            }
            return listapersonas;
        }
    }
}
