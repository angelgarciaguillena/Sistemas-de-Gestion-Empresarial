using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.PersonasRepositorio
{
    public class PersonasRepositorio : IGetListaPersonas
    {
        public Persona[] getListaPersonas()
        {
            return [
                new Persona(1, "Elena", "Alcalde García"),
                new Persona(2, "Luis", "Cerrato Vela"),
                new Persona(3, "María", "Díaz Fernández"),
                new Persona(4, "Javier", "Gómez Pérez"),
                new Persona(5, "Laura", "Martínez López"),
                new Persona(6, "Carlos", "Sánchez Ruiz"),
                new Persona(7, "Ana", "Romero Torres"),
                new Persona(8, "Miguel", "Navarro Díaz"),
                new Persona(9, "Lucía", "Hernández Rojas"),
                new Persona(10, "David", "Castro Medina"),
                new Persona(11, "Sofía", "Moreno García"),
                new Persona(12, "Andrés", "López Salazar"),
                new Persona(13, "Valeria", "Núñez Cabrera"),
                new Persona(14, "Tomás", "Blanco Romero"),
                new Persona(15, "Paula", "Paredes León"),
                new Persona(16, "Ignacio", "Ruiz Herrera"),
                new Persona(17, "Daniela", "Santos Molina"),
                new Persona(18, "Hugo", "Delgado Cruz"),
                new Persona(19, "Martina", "Campos Suárez"),
                new Persona(20, "Emilio", "Fernández Bravo"),
                ];
        }
    }
}