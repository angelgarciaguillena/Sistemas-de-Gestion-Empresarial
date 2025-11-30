using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Domain.Repositorios;
using Data.Repositorios;
using Domain.UseCases;
using Domain.Interfaces;

namespace CompositionRoot
{
    public static class InversifyConfig
    {
        public static IServiceCollection AddCompositionRoot(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPersonaRepositorio, PersonasRepositorio>();
            services.AddScoped<IDepartamentoRepositorio, DepartamentosRepositorio>();
            services.AddScoped<IPersonaUseCase, PersonaUseCase>();
            services.AddScoped<IDepartamentoUseCase, DepartamentoUseCase>();

            return services;
        }
    }
}