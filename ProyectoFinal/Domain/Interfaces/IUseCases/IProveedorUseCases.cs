using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IUseCases
{
    public interface IProveedorUseCases
    {
        Task<List<Proveedor>> ObtenerActivosAsync();
        Task<List<Proveedor>> ObtenerTodosAsync();
    }
}
