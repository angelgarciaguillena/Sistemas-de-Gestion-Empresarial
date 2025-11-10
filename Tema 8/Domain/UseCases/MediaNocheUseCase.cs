using Domain.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    public class MediaNocheUseCase : ListadoMisionesUseCase
    {
        public MediaNocheUseCase() { 
            
            if(DateTime.Now.Hour < 0 || DateTime.Now.Hour >= 24)
            {
                throw new ArgumentOutOfRangeException("La hora actual no es válida.");
            }
        }
        

    }
}
