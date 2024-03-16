using AutoMapper;
using Domain.BaseDomain.DomainModels;
using Domain.ModelDtos;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MinimalAPIAutoDIRegister.CommonEndPoint;
using MinimalAPIAutoDIRegister.CommonEndPoint.User;

namespace MinimalAPIAutoDIRegister.EndPoints
{
    public class CreateUserEndPoint : IEndPoint
    {
        public async Task MapEndPointAsync(IEndpointRouteBuilder app)
        {
            app.MapPost("users", async ([FromBody]UserDto user, IMapper mapper , IValidator<UserDto> userValidator ,
           ISender sender) =>
            {
                var valid = userValidator.Validate(user);
                if(!valid.IsValid)
                {
                    return Results.BadRequest(valid.Errors);
                }
                var query = mapper.Map<CreateUserCommand>(user);

                var result = await sender.Send(query);

                return Results.Ok(result);
            });
        }
    }
}
