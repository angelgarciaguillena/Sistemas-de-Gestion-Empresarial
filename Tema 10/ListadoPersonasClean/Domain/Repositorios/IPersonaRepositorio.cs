using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositorios
{
    public interface IPersonaRepositorio
    {
        List<Persona> getPersonas();

        Persona getPersona(int id);

        int agregarPersona(Persona persona);

        int actualizarPersona(Persona persona);

        int eliminarPersona(int id);
    }
}