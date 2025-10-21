using Ejercicio4.Models.Entities;
using System;
using System.Collections.Generic;

namespace Ejercicio4.Models.DAL
{
    public class clsPersonaDAL
    {
        public static List<clsPersona> ObtenerPersonas()
        {
            var departamentos = clsDepartamentoDAL.ObtenerDepartamentos();
            var rand = new Random();
            return new List<clsPersona>
            {
                new clsPersona { Nombre="Ana", Apellidos="García", Edad=28, Departamento=departamentos[rand.Next(departamentos.Count)] },
                new clsPersona { Nombre="Luis", Apellidos="Martínez", Edad=32, Departamento=departamentos[rand.Next(departamentos.Count)] },
                new clsPersona { Nombre="Marta", Apellidos="López", Edad=21, Departamento=departamentos[rand.Next(departamentos.Count)] },
                new clsPersona { Nombre="Carlos", Apellidos="Fernández", Edad=40, Departamento=departamentos[rand.Next(departamentos.Count)] },
                new clsPersona { Nombre="Sofía", Apellidos="Torres", Edad=35, Departamento=departamentos[rand.Next(departamentos.Count)] }
            };
        }
    }
}