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
    /// Repositorio que gestiona el acceso a datos de las personas
    /// </summary>
    public class PersonaRepository : IPersonaRepository
    {
        private List<Persona> personas;

        /// <summary>
        /// Constructor que inicializa los datos del repositorio de personas
        /// </summary>
        public PersonaRepository()
        {
            personas = new List<Persona>
            {
                new Persona(1, "Geneva", "Bambrick", 3),
                new Persona(2, "Blondelle", "Hadley", 2),
                new Persona(3, "Tandi", "Fowley", 3),
                new Persona(4, "Renelle", "Izod", 3),
                new Persona(5, "Rici", "Moryson", 3),
                new Persona(6, "Kiele", "Sture", 4),
                new Persona(7, "Druci", "Henden", 3),
                new Persona(8, "Forbes", "Prime", 3),
                new Persona(9, "Sonni", "Fagg", 2),
                new Persona(10, "Lidia", "Jannaway", 2),
                new Persona(11, "Celisse", "Dach", 2),
                new Persona(12, "Amalea", "Donohue", 1),
                new Persona(13, "Jemimah", "Borman", 4),
                new Persona(14, "Yetty", "Haythorne", 1),
                new Persona(15, "Phedra", "Higford", 3),
                new Persona(16, "Savina", "Croasdale", 1),
                new Persona(17, "Pippa", "Thursfield", 4),
                new Persona(18, "Marris", "Sivell", 4),
                new Persona(19, "Anita", "St Leger", 4),
                new Persona(20, "Joanne", "Heare", 3),
                new Persona(21, "Jeannette", "Moyles", 4),
                new Persona(22, "Dall", "Gainforth", 2),
                new Persona(23, "Cameron", "Maren", 4),
                new Persona(24, "Genovera", "Garthside", 1),
                new Persona(25, "Torrance", "Panton", 1),
                new Persona(26, "Humberto", "Mcllwraith", 4),
                new Persona(27, "Elisabetta", "Stickley", 4),
                new Persona(28, "Rachael", "Weber", 3),
                new Persona(29, "Amandie", "Linnitt", 3),
                new Persona(30, "Pavel", "Mansel", 2)
            };
        }

        /// <summary>
        /// Devuelve una lista con todas las personas
        /// </summary>
        /// <returns>Lista de personas</returns>
        public List<Persona> getPersonas()
        {
            return personas;
        }
    }
}