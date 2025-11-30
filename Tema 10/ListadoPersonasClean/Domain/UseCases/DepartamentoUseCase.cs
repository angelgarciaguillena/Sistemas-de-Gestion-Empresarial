using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositorios;

namespace Domain.UseCases
{
    public class DepartamentoUseCase : IDepartamentoUseCase
    {
        private readonly IDepartamentoRepositorio _departamentoRepositorio;

        public DepartamentoUseCase(IDepartamentoRepositorio departamentoRepositorio)
        {
            _departamentoRepositorio = departamentoRepositorio;
        }

        public List<Departamento> getDepartamentos()
        {
            return _departamentoRepositorio.getDepartamentos();
        }

        public Departamento getDepartamento(int id)
        {
            return _departamentoRepositorio.getDepartamento(id);
        }

        public int agregarDepartamento(Departamento departamento)
        {
            return _departamentoRepositorio.agregarDepartamento(departamento);
        }

        public int actualizarDepartamento(Departamento departamento)
        {
            return _departamentoRepositorio.actualizarDepartamento(departamento);
        }

        public int eliminarDepartamento(int id)
        {
            return _departamentoRepositorio.eliminarDepartamento(id);
        }
    }
}
