using MinimalAPIAutoDIRegister.PipeLineBehaviour;

namespace MinimalAPIAutoDIRegister.Extensions
{
    public static class AddPipeLineBehaviourExtension
    {
        public static  IServiceCollection AddPipeLineBehaviourConfig(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.AddOpenBehavior(typeof(IdempotencyPipeLineBehaviour<,>));
                //config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>
                //    >();

            });
            return services;
        }
            
            
    }
}
