using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repositorios;
using Microsoft.Data.SqlClient;

namespace Data.Repositorios
{
    public class PersonasRepositorio : IPersonaRepositorio
    {
        private SqlConnection miConexion = new SqlConnection();
        private List<Persona> listadoPersonas = new List<Persona>();
        private SqlCommand miComando = new SqlCommand();
        private SqlDataReader miLector;
        private Persona persona;

        public List<Persona> getPersonas()
        {
            // Establecemos la cadena de conexión
            miConexion.ConnectionString = "server=angelgarcia.database.windows.net;database=PersonasDB;uid=angel;pwd=abc1234_;trustServerCertificate=true;";

            try
            {
                // Abrimos la conexión a la base de datos
                miConexion.Open();

                // Creamos el comando para ejecutar la consulta
                miComando.CommandText = "SELECT * FROM Personas";
                miComando.Connection = miConexion;

                // Ejecutamos la consulta y obtenemos el lector de datos
                miLector = miComando.ExecuteReader();

                // Si hay filas en el lector
                if (miLector.HasRows)
                {
                    // Leemos las filas
                    while (miLector.Read())
                    {
                        // Creamos una nueva instancia de Persona
                        persona = new Persona();

                        // Asignamos los valores a la instancia de Persona
                        persona.Id = (int)miLector["ID"];
                        persona.Nombre = (string)miLector["Nombre"];
                        persona.Apellidos = (string)miLector["Apellidos"];
                        persona.FechaNacimiento = (DateTime)miLector["FechaNacimiento"];
                        persona.Direccion = (string)miLector["Direccion"];
                        persona.Telefono = (string)miLector["Telefono"];
                        persona.Foto = (string)miLector["Foto"];
                        persona.IdDepartamento = (int)miLector["IDDepartamento"];

                        // Añadimos la persona a la lista
                        listadoPersonas.Add(persona);
                    }
                }

                // Cerramos el lector y la conexión
                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                // En caso de error, lanzamos la excepción
                throw exSql;
            }

            // Devolvemos la lista de personas
            return listadoPersonas;
        }

        public Persona getPersona(int id)
        {
            // Obtenemos la cadena de conexión
            miConexion.ConnectionString = "server=angelgarcia.database.windows.net;database=PersonasDB;uid=angel;pwd=abc1234_;trustServerCertificate=true;";

            try
            {
                // Abrimos la conexión
                miConexion.Open();

                // Asociamos el comando a la conexión
                miComando.Connection = miConexion;

                // Cremos la consulta Sql
                miComando.CommandText = "SELECT * FROM Personas WHERE ID = @id";

                // Asignamos el parámetro a la consulta
                miComando.Parameters.AddWithValue("@id", id);

                // Ejecutamos y obtenemos el resultado de la consulta
                miLector = miComando.ExecuteReader();

                // Si la consulta devuelve algo
                if (miLector.HasRows)
                {
                    // Recorremos el resultado
                    while (miLector.Read())
                    {
                        // Creamos una nueva instancia de Departamento
                        persona = new Persona();

                        // Asignamos los valores
                        persona.Id = (int)miLector["ID"];
                        persona.Nombre = (string)miLector["Nombre"];
                        persona.Apellidos = (string)miLector["Apellidos"];
                        persona.FechaNacimiento = (DateTime)miLector["FechaNacimiento"];
                        persona.Direccion = (string)miLector["Direccion"];
                        persona.Telefono = (string)miLector["Telefono"];
                        persona.Foto = (string)miLector["Foto"];
                        persona.IdDepartamento = (int)miLector["IDDepartamento"];
                    }
                }

                // Cerramos el lector y la conexión
                miLector.Close();
                miConexion.Close();


            }
            catch (SqlException exSql)
            {
                // En caso de error, lanzamos la excepción
                throw exSql;
            }

            // Devolvemos la persona
            return persona;
        }

        public int agregarPersona(Persona persona)
        {
            // Obtenemos la cadena de conexión
            miConexion.ConnectionString = "server=angelgarcia.database.windows.net;database=PersonasDB;uid=angel;pwd=abc1234_;trustServerCertificate=true;";

            try
            {
                // Abrimos la conexión
                miConexion.Open();

                // Asociamos el comando a la conexión
                miComando.Connection = miConexion;

                // Cremos la consulta Sql
                miComando.CommandText = "INSERT INTO Personas (Nombre, Apellidos, FechaNacimiento, Direccion, Telefono, Foto, IDDepartamento)" +
                                        "VALUES (@nombre, @apellidos, @fechaNacimiento, @direccion, @telefono, @foto, @idDepartamento)";

                // Asignamos los parámetros a la consulta
                miComando.Parameters.AddWithValue("@nombre", persona.Nombre);
                miComando.Parameters.AddWithValue("@apellidos", persona.Apellidos);
                miComando.Parameters.AddWithValue("@fechaNacimiento", persona.FechaNacimiento);
                miComando.Parameters.AddWithValue("@direccion", persona.Direccion);
                miComando.Parameters.AddWithValue("@telefono", persona.Telefono);
                miComando.Parameters.AddWithValue("@foto", persona.Foto);
                miComando.Parameters.AddWithValue("@idDepartamento", persona.IdDepartamento);

                // Ejecutamos la consulta y devolvemos el resultado de filas afectadas
                return miComando.ExecuteNonQuery();

            }
            catch (SqlException exSql)
            {
                // En caso de error, lanzamos la excepción
                throw exSql;
            }
        }

        public int actualizarPersona(Persona persona)
        {
            // Obtenemos la cadena de conexión
            miConexion.ConnectionString = "server=angelgarcia.database.windows.net;database=PersonasDB;uid=angel;pwd=abc1234_;trustServerCertificate=true;";

            try
            {
                // Abrimos la conexión
                miConexion.Open();

                // Asociamos el comando a la conexión
                miComando.Connection = miConexion;

                // Cremos la consulta Sql
                miComando.CommandText = "UPDATE Personas SET Nombre = @nombre, Apellidos = apellidos, FechaNacimiento = @fechaNacimiento, Direccion = @direccion, Telefono = @telefono, Foto = @foto, IDDepartamento = @idDepartamento WHERE ID = @id";

                // Asignamos los parámetros a la consulta
                miComando.Parameters.AddWithValue("@nombre", persona.Nombre);
                miComando.Parameters.AddWithValue("@apellidos", persona.Apellidos);
                miComando.Parameters.AddWithValue("@fechaNacimiento", persona.FechaNacimiento);
                miComando.Parameters.AddWithValue("@direccion", persona.Direccion);
                miComando.Parameters.AddWithValue("@telefono", persona.Telefono);
                miComando.Parameters.AddWithValue("@foto", persona.Foto);
                miComando.Parameters.AddWithValue("@idDepartamento", persona.IdDepartamento);
                miComando.Parameters.AddWithValue("@id", persona.Id);

                // Ejecutamos la consulta y devolvemos el resultado de filas afectadas
                return miComando.ExecuteNonQuery();

            }
            catch (SqlException exSql)
            {
                // En caso de error, lanzamos la excepción
                throw exSql;
            }
        }

        public int eliminarPersona(int id)
        {
            // Obtenemos la cadena de conexión
            miConexion.ConnectionString = "server=angelgarcia.database.windows.net;database=PersonasDB;uid=angel;pwd=abc1234_;trustServerCertificate=true;";

            try
            {
                // Abrimos la conexión
                miConexion.Open();

                // Asociamos el comando a la conexión
                miComando.Connection = miConexion;

                // Cremos la consulta Sql
                miComando.CommandText = "DELETE FROM Personas WHERE ID = @id";

                // Asignamos el parámetro a la consulta
                miComando.Parameters.AddWithValue("@id", id);

                // Ejecutamos la consulta y devolvemos el resultado de filas afectadas
                return miComando.ExecuteNonQuery();

            }
            catch (SqlException exSql)
            {
                // En caso de error, lanzamos la excepción
                throw exSql;
            }
        }
    }
}