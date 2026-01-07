using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    /// <summary>
    /// Caso de uso que implementa la lógica de negocio para los departamentos
    /// </summary>
    public class DepartamentoUseCase : IDepartamentoUseCase
    {

        /// <summary>
        /// Repositorio de departamentos
        /// </summary>
        private readonly IDepartamentoRepository _departamentoRepository;

        /// <summary>
        /// Constructor que inyecta el repositorio de departamentos
        /// </summary>
        /// <param name="departamentoRepository">Repositorio de departamentos</param>
        public DepartamentoUseCase(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }

        /// <summary>
        /// Obtiene la lista completa de departamentos
        /// </summary>
        /// <returns>Lista de departamentos</returns>
        public List<Departamento> getDepartamentos()
        {
            return _departamentoRepository.getDepartamentos();
        }
    }
}
