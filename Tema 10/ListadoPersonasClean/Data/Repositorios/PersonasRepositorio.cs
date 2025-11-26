using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repositories;
using Microsoft.Data.SqlClient;

namespace Data.Repositories
{
    public class PersonasRepositorio : IPersonasRepositorio
    {
        private SqlConnection miConexion = new SqlConnection();
        private List<Persona> listadoPersonas = new List<Persona>();
        private SqlCommand miComando = new SqlCommand();
        private SqlDataReader miLector;
        private Persona oPersona;

        public List<Persona> obtenerListadoPersonas()
        {
            // Establecemos la cadena de conexión
            miConexion.ConnectionString = "server=angelgarcia.database.windows.net;database=PersonasDB;uid=angel;pwd=abc1234_;trustServerCertificate=true;";

            try
            {
                // Abrimos la conexión a la base de datos
                miConexion.Open();

                // Creamos el comando para ejecutar la consulta
                miComando.CommandText = "SELECT * FROM personas";
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
                        oPersona = new Persona();

                        // Asignamos los valores a la instancia de Persona
                        oPersona.Id = (int)miLector["ID"];
                        oPersona.Nombre = (string)miLector["Nombre"];
                        oPersona.Apellidos = (string)miLector["Apellidos"];

                        // Si sospechamos que el campo puede ser Null en la base de datos
                        if (miLector["FechaNacimiento"] != DBNull.Value)
                        {
                            oPersona.FechaNac = (DateTime)miLector["FechaNacimiento"];
                        }

                        oPersona.Direccion = (string)miLector["Direccion"];
                        oPersona.Telefono = (string)miLector["Telefono"];
                        oPersona.Foto = (string)miLector["Foto"];

                        // Añadimos la persona a la lista
                        listadoPersonas.Add(oPersona);
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
    }
}