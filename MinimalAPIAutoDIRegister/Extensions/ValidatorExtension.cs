using Domain.ModelDtos;
using Domain.Validators;
using FluentValidation;

namespace MinimalAPIAutoDIRegister.Extensions
{
    public static class ValidatorExtension
    {

        public static void AddFluentValidation(this IServiceCollection services)
        {
            services.AddScoped<IValidator<UserDto>, UserValidator>();
        }
            
    }
}
