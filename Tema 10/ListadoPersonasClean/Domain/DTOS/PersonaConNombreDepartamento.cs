using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOS
{
    public class PersonaConNombreDepartamento
    {
        public Persona _persona { get; set; }
        public string _nombreDepartamento { get; set; }

        // Constructor parameterless para model binder
        public PersonaConNombreDepartamento()
        {
            _persona = new Persona();
            _nombreDepartamento = string.Empty;
        }

        public PersonaConNombreDepartamento(Persona persona, string nombreDepartamento)
        {
            _persona = persona;
            _nombreDepartamento = nombreDepartamento;
        }
    }
}