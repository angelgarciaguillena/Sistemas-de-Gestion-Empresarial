using Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces;
using Domain.Repositories;
using Domain.UseCase;


namespace CompositionRoot
{
    public static class InversifyConfig
    {
        public static IServiceCollection AddCompositionRoot(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGetListaPersonas, PersonasRepositoryAzure>();
            services.AddScoped<IGetListaPersonasUseCase, DefaultGetListaPersonasUseCase>();

            return services;
        }
    }
}