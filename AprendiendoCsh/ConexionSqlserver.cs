using AprendiendoCsh.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AprendiendoCsh
{

    internal class ConexionSqlserver : Conexion
    {
        
        private string DatosConexion;
        public ConexionSqlserver()//constructor para la conexión
        {
            DatosConexion = "Data Source=" + server +
                "; Initial Catalog=" + database +
                "; User= " + user +
                "; Password=" + password + "";
            
            
        }
        //Consulta en forma de lista
        public List<Persona> Get()
        {
            List<Persona> listapersonas = new List<Persona>();
            
            string query = "select Nombre, ApellidoP, ApellidoM, Edad from Persona";
            
            using (var connection = new SqlConnection(DatosConexion))
            {
                SqlCommand consulta = new SqlCommand(query,connection);
                connection.Open();
                SqlDataReader reader = consulta.ExecuteReader();
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
        //Consulta individual
        public Persona Get1(int id)
        {
            Persona verpersona = new Persona("", "", "",0) ;

            string query = "select Nombre, ApellidoP, ApellidoM, Edad from Persona where IdPersona = "+id;

            using (var connection = new SqlConnection(DatosConexion))
            {
                SqlCommand consulta = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = consulta.ExecuteReader();
                reader.Read();
                    string Nombre = reader.GetString(0);
                    string ApellidoP = reader.GetString(1);
                    string ApellidoM = reader.GetString(2);
                    int Edad = reader.GetInt32(3);
                    Persona persona = new Persona(Nombre, ApellidoP, ApellidoM, Edad);
                    verpersona=persona;
                
                reader.Close();
                connection.Close();
            }
            return verpersona;

        }
        //Insertar persona
        public void InsertarPersona(Persona persona)
        {
            string query = "Insert into Persona(Nombre,ApellidoP,ApellidoM,Edad) "+
                "values(@nombre,@apellidop,@apellidom,@edad)";
            using (var connection = new SqlConnection(DatosConexion))
            {
                var consulta = new SqlCommand(query, connection);
                consulta.Parameters.AddWithValue("@nombre", persona.Nombre);
                consulta.Parameters.AddWithValue("@apellidop", persona.ApellidoP);
                consulta.Parameters.AddWithValue("@apellidom", persona.ApellidoM);
                consulta.Parameters.AddWithValue("@edad", persona.Edad);
                connection.Open();
                consulta.ExecuteNonQuery();

                connection.Close();
            }
        }
        //Editar persona
        public void EditarPersona(Persona persona,int id)
        {
            string query = "Update Persona Set Nombre=@nombre, ApellidoP=@apellidop, " +
                "ApellidoM=@apellidom, Edad=@edad Where IdPersona=@idpersona";
            using (var connection = new SqlConnection(DatosConexion))
            {
                var consulta = new SqlCommand(query, connection);
                consulta.Parameters.AddWithValue("@nombre", persona.Nombre);
                consulta.Parameters.AddWithValue("@apellidop", persona.ApellidoP);
                consulta.Parameters.AddWithValue("@apellidom", persona.ApellidoM);
                consulta.Parameters.AddWithValue("@edad", persona.Edad);
                consulta.Parameters.AddWithValue("@idpersona",id);
                connection.Open();
                consulta.ExecuteNonQuery();

                connection.Close();
            }
        }
        //Eliminar persona
        public void EliminarPersona(int id)
        {
            string query = "Delete from Persona Where IdPersona = @idpersona";
            using (var connection = new SqlConnection(DatosConexion))
            {
                var consulta = new SqlCommand(query, connection);
                
                consulta.Parameters.AddWithValue("@idpersona", id);
                connection.Open();
                consulta.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}
