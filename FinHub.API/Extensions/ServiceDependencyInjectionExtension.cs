using FinHub.Gastos.Domain.Transacoes.Interfaces;
using FinHub.Gastos.Domain.Transacoes.Services;

namespace FinHub.API.Extensions
{
    public static class ServiceDependencyInjectionExtension
    {
        /// <summary>
        /// Define a injeção de dependência para classes Service.
        /// </summary>
        /// <param name="services">Services</param>
        public static void AddDependencyInjectionForServices(this IServiceCollection services)
        {
            services.AddScoped<ICentralGastosService, CentralGastosService>();
            services.AddScoped<IInfoGastosService, InfoGastosService>();
        }
    }
}