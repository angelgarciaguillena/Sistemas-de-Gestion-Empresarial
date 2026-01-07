using Domain.Interfaces;
using Domain.Repositories;
using Domain.UseCases;
using Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionRoot
{
    /// <summary>
    /// Clase estática que configura la inyección de dependencias de la aplicación
    /// </summary>
    public static class InversifyConfig
    {
        /// <summary>
        /// Método de extensión que registra todas las dependencias de la aplicación
        /// </summary>
        /// <param name="services">Colección de servicios de ASP.NET Core</param>
        /// <param name="configuration">Configuracion de la aplicación</param>
        /// <returns>Colección de servicios actualizada</returns>
        public static IServiceCollection AddCompositionRoot(this IServiceCollection services, IConfiguration configuration)
        {
            //Repositorios 
            services.AddScoped<IPersonaRepository, PersonaRepository>();
            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();

            //Casos de Uso 
            services.AddScoped<IDepartamentoUseCase, DepartamentoUseCase>();
            services.AddScoped<IPersonaUseCase, PersonaUseCase>();

            return services;
        }
    }
}