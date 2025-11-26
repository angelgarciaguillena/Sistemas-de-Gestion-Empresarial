using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.DTO
{
    public class PersonaConListadoDepartamento
    {
        Persona _persona;
        List<Departamento> _listadoDepartamentos;

        PersonaConListadoDepartamento()
        {
            _persona = new Persona();
            _listadoDepartamentos = new List<Departamento>();
        }
    }
}