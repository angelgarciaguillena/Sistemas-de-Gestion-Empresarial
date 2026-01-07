using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    /// <summary>
    /// Interfaz del repositorio para gestionar los departamentos
    /// </summary>
    public interface IDepartamentoRepository
    {
        /// <summary>
        /// Devuelve una lista con todos los departamentos
        /// </summary>
        /// <returns>Lista de departamentos</returns>
        public List<Departamento> getDepartamentos();
    }
}