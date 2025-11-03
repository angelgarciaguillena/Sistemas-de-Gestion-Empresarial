using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompositionRoot
{
    public static class InversifyConfig
    {
        public static IServiceCollection AddCompositionRoot(this IServiceCollection services, IConfiguration configuration)
        {
            // Domain Use Cases
            services.AddTransient<Domain.Interfaces.IGetListaPersonasUseCase, Domain.UseCase.DefaultGetListaPersonasUseCase>();
            // Domain Repositories
            services.AddTransient<Domain.Repositories.IGetListaPersonas, Data.RepositorioVacio.RepositorioVacio>();
            return services;
        }
    }
}
