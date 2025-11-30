using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositorios
{
    public interface IDepartamentoRepositorio
    {
        List<Departamento> getDepartamentos();

        Departamento getDepartamento(int id);

        int agregarDepartamento(Departamento departamento);

        int actualizarDepartamento(Departamento departamento);

        int eliminarDepartamento(int id);
    }
}