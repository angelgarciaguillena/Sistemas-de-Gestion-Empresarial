using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    /// <summary>
    /// Interfaz del caso de uso para gestionar la lógica de negocio de departamentos
    /// </summary>
    public interface IDepartamentoUseCase
    {
        /// <summary>
        /// Devuelve una lista con todos los departamentos
        /// </summary>
        /// <returns>Lista de departamentos</returns>
        public List<Departamento> getDepartamentos();
    }
}