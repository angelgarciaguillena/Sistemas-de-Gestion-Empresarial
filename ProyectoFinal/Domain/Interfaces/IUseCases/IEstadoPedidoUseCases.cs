using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IUseCases
{
    public interface IEstadoPedidoUseCases
    {
        Task<List<EstadoPedido>> GetAllAsync();
        Task<EstadoPedido?> GetByIdAsync(int id);
    }
}
