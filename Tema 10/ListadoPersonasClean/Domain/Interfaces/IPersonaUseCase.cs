using Domain.DTOS;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPersonaUseCase
    {
           
        List<PersonaConNombreDepartamento> getPersonas();

        PersonaConNombreDepartamento getPersona(int id);

        PersonaConListadoDepartamento getPersonaEditar(int id);

        PersonaConListadoDepartamento getPersonaAgregar();

        List<Departamento> getDepartamentos();

        int agregarPersona(Persona persona);

        int actualizarPersona(Persona persona);

        int eliminarPersona(int id);
    }
}