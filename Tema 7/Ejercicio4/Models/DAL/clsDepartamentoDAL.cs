using Ejercicio4.Models.Entities;
using System;
using System.Collections.Generic;

namespace Ejercicio4.Models.DAL
{
    public class clsDepartamentoDAL
    {
        public static List<clsDepartamento> ObtenerDepartamentos()
        {
            return new List<clsDepartamento>
            {
                new clsDepartamento{ IdDepartamento=1, NombreDepartamento="RRHH"},
                new clsDepartamento{ IdDepartamento=2, NombreDepartamento="Finanzas"},
                new clsDepartamento{ IdDepartamento=3, NombreDepartamento="IT"},
                new clsDepartamento{ IdDepartamento=4, NombreDepartamento="Marketing"}
            };
        }
    }
}