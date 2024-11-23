namespace FinHub.API.Extensions
{
    public static class RepositoryDependencyInjectionForRepository
    {
        /// <sumary>
        /// Define a injeção de dependência para classes Repository.
        /// </sumary>
        /// <param name="services">Services</param>
        public static void AddDependencyInjectionForRepositories(this IServiceCollection services)
        {
            //services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();
        }
    }
}