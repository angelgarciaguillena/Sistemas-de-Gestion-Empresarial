using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Departamento
    {
        #region Atributos privados
        private int _id;
        private string _nombre;
        #endregion

        #region Getters y Setters
        public int Id
        {
            get { return _id; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        #endregion

        #region Constructores
        public Departamento() {}

        public Departamento(int id, string nombre)
        {
            _id = id;
            _nombre = nombre;
        }
        #endregion
    }
}