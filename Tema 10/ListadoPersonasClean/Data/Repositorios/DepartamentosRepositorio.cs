using Domain.Entities;
using Domain.Repositorios;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorios
{
    public class DepartamentosRepositorio : IDepartamentoRepositorio
    {
        private SqlConnection miConexion = new SqlConnection();
        private List<Departamento> listadoDepartamentos = new List<Departamento>();
        private SqlCommand miComando = new SqlCommand();
        private SqlDataReader miLector;
        private Departamento departamento;

        public List<Departamento> getDepartamentos()
        {
            miConexion.ConnectionString = "server=angelgarcia.database.windows.net;database=PersonasDB;uid=angel;pwd=abc1234_;trustServerCertificate=true;";

            try
            {
                // Abrimos la conexión a la base de datos
                miConexion.Open();

                // Creamos el comando para ejecutar la consulta
                miComando.CommandText = "SELECT * FROM Departamentos";
                miComando.Connection = miConexion;

                // Ejecutamos la consulta y obtenemos el lector de datos
                miLector = miComando.ExecuteReader();

                // Si hay filas en el lector
                if (miLector.HasRows)
                {
                    // Leemos las filas
                    while (miLector.Read())
                    {
                        // Creamos una nueva instancia de Departamento
                        departamento = new Departamento();

                        // Asignamos los valores a la instancia de Departamento
                        departamento.Id = (int)miLector["ID"];
                        departamento.Nombre = (string)miLector["Nombre"];

                        // Añadimos el departamento a la lista
                        listadoDepartamentos.Add(departamento);
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

            // Devolvemos la lista de departamentos
            return listadoDepartamentos;
        }

        public Departamento getDepartamento(int id)
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
                miComando.CommandText = "SELECT * FROM Departamentos WHERE ID = @id";

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
                        departamento = new Departamento();

                        // Asignamos los valores
                        departamento.Id = (int)miLector["ID"];
                        departamento.Nombre = (string)miLector["Nombre"];
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

            // Devolvemos el departamento
            return departamento;
        }

        public int agregarDepartamento(Departamento departamento)
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
                miComando.CommandText = "INSERT INTO Departamentos (Nombre) VALUES (@Nombre)";

                // Asignamos el parámetro a la consulta
                miComando.Parameters.AddWithValue("@Nombre", departamento.Nombre);

                // Ejecutamos la consulta y devolvemos el resultado de filas afectadas
                return miComando.ExecuteNonQuery();

            }
            catch (SqlException exSql)
            {
                // En caso de error, lanzamos la excepción
                throw exSql;
            }
        }

        public int actualizarDepartamento(Departamento departamento)
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
                miComando.CommandText = "UPDATE Departamentos SET Nombre = @Nombre WHERE ID = @id";

                // Asignamos los parámetros a la consulta
                miComando.Parameters.AddWithValue("@Nombre", departamento.Nombre);
                miComando.Parameters.AddWithValue("@id", departamento.Id);

                // Ejecutamos la consulta y devolvemos el resultado de filas afectadas
                return miComando.ExecuteNonQuery();

            }
            catch (SqlException exSql)
            {
                // En caso de error, lanzamos la excepción
                throw exSql;
            }
        }

        public int eliminarDepartamento(int id)
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
                miComando.CommandText = "DELETE FROM Departamentos WHERE ID = @id";

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