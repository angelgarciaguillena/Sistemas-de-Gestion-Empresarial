using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// Representa un departamento
    /// </summary>
    public class Departamento
    {
        #region Atributos privados
        /// <summary>
        /// Id del departamento
        /// </summary>
        private int _id;

        /// <summary>
        /// Nombre del departamento
        /// </summary>
        private string _nombre;
        #endregion

        #region Getters y Setters
        /// <summary>
        /// Get y Set del id del departamento
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Get y Set del nombre del departamento
        /// </summary>
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de Departamento
        /// </summary>
        public Departamento() { }

        /// <summary>
        /// Constructor con parámetros de Departamento
        /// </summary>
        /// <param name="id">Identificador del departamento</param>
        /// <param name="nombre">Nombre del departamento</param>
        public Departamento(int id, string nombre)
        {
            _id = id;
            _nombre = nombre;
        }
        #endregion
    }
}