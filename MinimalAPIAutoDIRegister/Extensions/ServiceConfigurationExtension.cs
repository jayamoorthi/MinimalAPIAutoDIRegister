using Domain.Interfaces;
using Infrastructure.Repositories;

namespace MinimalAPIAutoDIRegister.Extensions
{
    public static class SericeConfigurationExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
          //  services.AddTransient<IUserRepository, UserRepository>();

        }
    }
}
