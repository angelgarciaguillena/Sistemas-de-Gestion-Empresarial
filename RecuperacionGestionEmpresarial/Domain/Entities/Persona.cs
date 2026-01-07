using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// Representa a una persona
    /// </summary>
    public class Persona
    {
        #region Atributos privados
        /// <summary>
        /// Id de la persona
        /// </summary>
        private int _id;

        /// <summary>
        /// Nombre de la persona
        /// </summary>
        private string _nombre;

        /// <summary>
        /// Apellidos de la persona
        /// </summary>
        private string _apellidos;

        /// <summary>
        /// Id del departamento al que pertenece la persona
        /// </summary>
        private int _idDepartamento;
        #endregion

        #region Getters y Setters
        /// <summary>
        /// Get y Set del id de la persona
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Get y Set del nombre de la persona
        /// </summary>
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        /// <summary>
        /// Get y Set de los apellidos de la persona
        /// </summary>
        public string Apellidos
        {
            get { return _apellidos; }
            set { _apellidos = value; }
        }

        /// <summary>
        /// Get y Set del id del departamento al que pertenece la persona
        /// </summary>
        public int IdDepartamento
        {
            get { return _idDepartamento; }
            set { _idDepartamento = value; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de Persona
        /// </summary>
        public Persona() { }

        /// <summary>
        /// Constructor con parámetros de Persona
        /// </summary>
        /// <param name="id">Id de la persona</param>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellidos">Apellidos de la persona</param>
        /// <param name="idDepartamento">Id del departamento</param>
        public Persona(int id, string nombre, string apellidos, int idDepartamento)
        {
            _id = id;
            _nombre = nombre;
            _apellidos = apellidos;
            _idDepartamento = idDepartamento;
        }
        #endregion
    }
}