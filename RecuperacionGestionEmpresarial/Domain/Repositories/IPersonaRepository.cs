using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    /// <summary>
    /// Interfaz del repositorio para gestionar las personas
    /// </summary>
    public interface IPersonaRepository
    {
        /// <summary>
        /// Devuelve una lista con todas las personas
        /// </summary>
        /// <returns>Lista de personas</returns>
        public List<Persona> getPersonas();
    }
}