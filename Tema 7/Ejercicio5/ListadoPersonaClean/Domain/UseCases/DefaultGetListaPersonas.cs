using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase
{
    public class DefaultGetListaPersonasUseCase : IGetListaPersonasUseCase
    {
        private readonly IGetListaPersonas _repository;

        public DefaultGetListaPersonasUseCase(IGetListaPersonas getListaPersonas)
        {
            _repository = getListaPersonas;
        }

        public Persona[] getListaPersonas()
        {
            return _repository.getListaPersonas();
        }
    }
}