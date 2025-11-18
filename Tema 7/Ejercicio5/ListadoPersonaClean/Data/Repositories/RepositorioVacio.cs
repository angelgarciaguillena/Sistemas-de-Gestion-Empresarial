
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.RepositorioVacio
{
    public class ListadoPersonasVacio : IGetListaPersonas
    {
        private List<Persona> _listadoPersonas;

        public ListadoPersonasVacio()
        {
            _listadoPersonas = new List<Persona>();
        }

        public List<Persona> obtenerListadoPersonas()
        {
            return _listadoPersonas;
        }
    }
}