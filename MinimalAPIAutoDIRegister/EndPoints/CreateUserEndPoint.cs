using AutoMapper;
using Domain.BaseDomain.DomainModels;
using Domain.ModelDtos;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MinimalAPIAutoDIRegister.CommonEndPoint;
using MinimalAPIAutoDIRegister.CommonEndPoint.User;
using System.Diagnostics;

namespace MinimalAPIAutoDIRegister.EndPoints
{
    public class CreateUserEndPoint : IEndPoint
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CreateUserEndPoint> _mapper2;
       
      
        public async Task MapEndPointAsync(IEndpointRouteBuilder app)
        {
            app.MapPost("users", async ([FromBody]UserDto user, IMapper mapper , IValidator<UserDto> userValidator ,
           ISender sender, ILogger<CreateUserEndPoint> logger) =>
            {
                var watch = new Stopwatch();
                watch.Start();
                logger.LogWarning($"endpoint user : {@user}");
                var valid = userValidator.Validate(user);
                if(!valid.IsValid)
                {
                    return Results.BadRequest(valid.Errors);
                }
                var query = mapper.Map<CreateUserCommand>(user);

                var result = await sender.Send(query);
                watch.Stop();
                logger.LogInformation($" request : {@user} response: {@result}  time: {watch.ElapsedMilliseconds}");
                return Results.Ok(result);
            });
        }
    }
}
