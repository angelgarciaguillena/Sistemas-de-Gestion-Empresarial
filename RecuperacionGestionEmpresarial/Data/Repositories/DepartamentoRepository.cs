using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    /// <summary>
    /// Repositorio que gestiona el acceso a datos de los departamentos
    /// </summary>
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private List<Departamento> departamentos;

        /// <summary>
        /// Constructor que inicializa los datos del repositorio de departamentos
        /// </summary>
        public DepartamentoRepository()
        {
            departamentos = new List<Departamento>
            {
                new Departamento(1, "Comercial"),
                new Departamento(2, "Ventas"),
                new Departamento(3, "Recursos Humanos"),
                new Departamento(4, "Finanzas")
            };
        }

        /// <summary>
        /// Devuelve una lista con todos los departamentos
        /// </summary>
        /// <returns>Lista de departamentos</returns>
        public List<Departamento> getDepartamentos()
        {
            return departamentos;
        }
    }
}