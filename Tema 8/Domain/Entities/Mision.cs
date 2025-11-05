using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Mision
    {
        private int _id;
        private string _titulo;
        private string _descripcion;
        private double _recompensa;

        public int id { get { return _id; } }

        public string nombre
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public double recompensa
        {
            get { return _recompensa; }
            set { _recompensa = value; }
        }

        public Mision() { }

        public Mision(int id, string titulo, string descripcion, double recompensa)
        {
            _id = id;
            _titulo = titulo;
            _descripcion = descripcion;
            _recompensa = recompensa;
        }
    }
}
